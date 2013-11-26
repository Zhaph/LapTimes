using System;
using System.Collections.Generic;
using System.Data.Objects;
using System.Linq;
using System.Web;

namespace LapTimes.Models
{
  public class LapTimeRepository : ILapTimeRepository
  {
    private readonly LapTimesContainer _container = new LapTimesContainer();

    public IOrderedQueryable<League> GetCurrentLeaderBoards()
    {
      ObjectQuery<League> leagues = _container.Leagues.Include("Racer");

      return leagues;
    }

    public Race CurrentRace()
    {
      ObjectQuery<Race> races = loadRaces();

      return (from race in races where !race.IsComplete select race).FirstOrDefault();
    }

    public Race GetRace(int id)
    {
      ObjectQuery<Race> races = loadRaces();

      return races.FirstOrDefault(r => r.Id == id);
    }

    public CurrentRacer GetWinner(int raceId)
    {
      return GetWinner(GetRace(raceId));
    }

    public CurrentRacer GetWinner(Race race)
    {
      if (race.IsComplete)
      {
        return race.CurrentRacers.OrderBy(cr => cr.RaceTime).First();
      }

      return null;
    }

    private ObjectQuery<Race> loadRaces()
    {
      return _container.Races.Include("CurrentRacers").Include("Leagues").Include("ClassNames");
    }
  }
}