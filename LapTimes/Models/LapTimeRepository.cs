using System;
using System.Data.Entity;
using System.Linq;

namespace LapTimes.Models
{
  public class LapTimeRepository : ILapTimeRepository
  {
    private readonly LapTimesContext _context = new LapTimesContext();

    public IQueryable<IGrouping<League, Racer>> GetCurrentLeaderBoards()
    {
//      var leagues = _context.Leagues.Include(l => l.Racers).OrderBy(l=> l.LeagueId);

      IQueryable<IGrouping<League, Racer>> leagues = from r in _context.Racers
                    where r.RawBestTime != 0
                    orderby r.RawBestTime 
                    group r by r.League
                    into league
                    select league;

      return leagues;
    }


    public Race CurrentRace()
    {
      IOrderedQueryable<Race> races = _context.Races;

      var currentRace = (from race in races where !race.IsComplete select race).FirstOrDefault();
      loadOrderedDrivers(currentRace);

      return currentRace;
    }

    public Race GetRace(int id)
    {
      IOrderedQueryable<Race> races = _context.Races;

      var currentRace = (from race in races where !race.IsComplete && race.RaceId == id select race).FirstOrDefault();
      loadOrderedDrivers(currentRace);

      return currentRace;
    }

    public CurrentDriver GetWinner(int raceId)
    {
      return GetWinner(GetRace(raceId));
    }

    public CurrentDriver GetWinner(Race race)
    {
      if (race.IsComplete)
      {
        return race.Drivers.OrderBy(cr => cr.RawRaceTime).First();
      }

      return null;
    }

    public void Save()
    {
      _context.SaveChanges();
    }

    private void loadOrderedDrivers(Race currentRace)
    {
      if (null == currentRace)
      {
        return;
      }

      var drivers = _context.Entry(currentRace);
      drivers.Collection(e => e.Drivers).Query().OrderBy(d => d.Lane).Include(d => d.Car).Include(d => d.Racer).Load();
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
  }
}