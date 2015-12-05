using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace LapTimes.Models
{
  public class LapTimeRepository : ILapTimeRepository
  {
    private readonly LapTimesContext _context = new LapTimesContext();

    public List<List<Racer>> GetCurrentLeaderBoards()
    {
      var racers = _context.Racers.Include(r => r.League).Include(r => r.ClassName);

      var leagues = new List<List<Racer>>();

      foreach (var league in _context.Leagues)
      {
        var driversInLeague = racers.Where(r => r.LeagueId == league.LeagueId && r.RawBestTime > 0).OrderBy(r => r.RawBestTime).Take(10).ToList();

        leagues.Add(driversInLeague);
      }

      return leagues;
    }

    public Race CurrentRace()
    {
      IOrderedQueryable<Race> races = _context.Races;

      var currentRace = (from race in races where !race.IsComplete select race).FirstOrDefault();
//      var currentRace = (from race in races orderby race.EndTime descending select race).FirstOrDefault();
      loadOrderedDrivers(currentRace);

      return currentRace;
    }

    public Race GetRace(int id)
    {
      IOrderedQueryable<Race> races = _context.Races;

      var currentRace = (from race in races where race.RaceId == id select race).FirstOrDefault();
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

    public IOrderedQueryable<Racer> GetRacersStartingWith(string query)
    {
      return
        _context.Racers
                .Include(r => r.League)
                .Include(r => r.ClassName)
                .Where(r => r.Name.StartsWith(query))
                .OrderBy(r => r.Name);
    }

    public int DeleteRace(int id)
    {
      return DeleteRace(GetRace(id));
    }

    public int DeleteRace(Race race)
    {
      var drivers = race.Drivers.ToList();
      foreach (var driver in drivers)
      {
        if (driver.Racer.RawBestTime == driver.RawRaceTime)
        {
          // This is the drivers best race, and we're deleting it :(
          // Update their best time to their next highest race:

          int driverId = driver.RacerId;
          var nextBest = _context.CurrentDrivers.Where(d => d.RacerId == driverId && d.RaceId != race.RaceId).OrderBy(d => d.RawRaceTime).FirstOrDefault();

          driver.Racer.RawBestTime = null != nextBest ? nextBest.RawRaceTime : 0;
        }

        _context.CurrentDrivers.Remove(driver);
      }

      _context.Races.Remove(race);

      return Save();
    }

    public int Save()
    {
      int ret = _context.SaveChanges();

      RaceServer.Instance.BroadcastUpdatedLeagues(GetCurrentLeaderBoards());

      return ret;
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

    public int AddLeague(League league)
    {
      _context.Leagues.Add(league);
      return Save();
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