using System;
using System.Linq;

namespace LapTimes.Models
{
  public class LapTimeRepository : ILapTimeRepository
  {
    private readonly LapTimesContext _context = new LapTimesContext();

    public IOrderedQueryable<League> GetCurrentLeaderBoards()
    {
      var leagues = _context.Leagues.Include("Drivers");

      return leagues;
    }

    public void AddLeague(League league)
    {
      throw new NotImplementedException();
    }

    public void GetClass(string name)
    {
      throw new NotImplementedException();
    }

    public void GetClass(int id)
    {
      throw new NotImplementedException();
    }

    public void AddClass(ClassName className)
    {
      throw new NotImplementedException();
    }

    public IOrderedQueryable<ClassName> GetClasses()
    {
      throw new NotImplementedException();
    }

    public Race CurrentRace()
    {
      IOrderedQueryable<Race> races = loadRaces();

      return (from race in races where !race.IsComplete select race).FirstOrDefault();
    }

    public Race GetRace(int id)
    {
      IOrderedQueryable<Race> races = loadRaces();

      return races.FirstOrDefault(r => r.RaceId == id);
    }

    public void AddRace(Race race)
    {
      throw new NotImplementedException();
    }

    public void DeleteRace(int id)
    {
      throw new NotImplementedException();
    }

    public void DeleteRace(Race race)
    {
      throw new NotImplementedException();
    }

    public CurrentDriver GetWinner(int raceId)
    {
      return GetWinner(GetRace(raceId));
    }

    public CurrentDriver GetWinner(Race race)
    {
      if (race.IsComplete)
      {
        return race.Racers.OrderBy(cr => cr.RawRaceTime).First();
      }

      return null;
    }

    public Racer GetRacer(int id)
    {
      throw new NotImplementedException();
    }

    public IOrderedQueryable<Racer> GetRacers(string nameStartsWith)
    {
      throw new NotImplementedException();
    }

    public void AddRacer(Racer racer)
    {
      throw new NotImplementedException();
    }

    public void Save()
    {
      throw new NotImplementedException();
    }

    private IOrderedQueryable<Race> loadRaces()
    {
      return _context.Races.Include("Racers").Include("Leagues").Include("ClassNames");
    }
  }
}