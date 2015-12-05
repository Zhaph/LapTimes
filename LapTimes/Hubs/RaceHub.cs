using System;
using System.Globalization;
using System.Linq;
using LapTimes.Models;
using Microsoft.AspNet.SignalR;

namespace LapTimes.Hubs
{
  public class RaceHub: Hub
  {
    private readonly ILapTimeRepository _repo;

    public RaceHub(): this(new LapTimeRepository())
    {}

    public RaceHub(ILapTimeRepository repo)
    {
      _repo = repo;
    }

    public void StartRace(int raceId)
    {
      var currentRace = _repo.GetRace(raceId);

      if (currentRace != null)
      {
        currentRace.StartTime = DateTime.Now;
        _repo.Save();
        
        Clients.All.updateRace(currentRace);
      }
    }

    public void StopRace(int raceId, bool aborted)
    {
      var currentRace = _repo.GetRace(raceId);

      if (currentRace != null)
      {
        if (!aborted)
        {
          currentRace.EndTime = DateTime.Now;
//          currentRace.IsComplete = true;
        }
        else
        {
          currentRace.StartTime = null;
          currentRace.StartTime = null;
        }

        _repo.Save();

        Clients.All.updateRace(currentRace);
      }
    }

    public void FinishRace(int raceId, RaceTimes[] raceTimes)
    {
      Race currentRace = saveRaceDetails(raceId, raceTimes);

      Clients.Caller.RedirectToRace();
      Clients.Others.getAllLeagues(_repo.GetCurrentLeaderBoards(), currentRace);
    }

    public void FinishRaceString(int raceId, RaceTimesString[] raceTimes)
    {
      var newRaceTimes = new RaceTimes[raceTimes.Length];

      for (int i = 0; i < raceTimes.Length; i++)
      {
        string timeString = raceTimes[i].RaceTime;

        while (timeString.ToCharArray().Count(c => c == ':') < 2)
        {
          timeString = "00:" + timeString;
        }

        var raceTime = TimeSpan.Parse(timeString);
        newRaceTimes[i] = new RaceTimes{ RacerId = raceTimes[i].RacerId, RaceTime = (int)Math.Round(raceTime.TotalMilliseconds)};
      }

      Race currentRace = saveRaceDetails(raceId, newRaceTimes);

      Clients.Caller.RedirectToRace();
      Clients.Others.getAllLeagues(_repo.GetCurrentLeaderBoards(), currentRace);
    }

    private Race saveRaceDetails(int raceId, RaceTimes[] raceTimes)
    {
       var currentRace = _repo.GetRace(raceId);

      currentRace.IsComplete = true;

      var winningTime = raceTimes.Min(r => r.RaceTime);

      foreach (var driver in currentRace.Drivers)
      {
        driver.Racer.IsWaitingForRace = false;
        driver.RawRaceTime = raceTimes.Single(rt => rt.RacerId == driver.RacerId.ToString(CultureInfo.InvariantCulture)).RaceTime;

        driver.Winner = driver.RawRaceTime == winningTime;

        if (driver.RawRaceTime < driver.Racer.RawBestTime || driver.Racer.RawBestTime == 0)
        {
          driver.NewPersonalBest = true;
          driver.Racer.RawBestTime = driver.RawRaceTime;
        }
      }

      _repo.Save();

      return currentRace;
    }

    public void UpdateRace(Race currentRace)
    {
      Clients.All.updateRace(currentRace);
    }

    public void GetAllLeagues()
    {
      Clients.Caller.getAllLeagues(_repo.GetCurrentLeaderBoards(), _repo.CurrentRace());
    }

    public void GetCurrentRace()
    {
      Race currentRace = _repo.CurrentRace();

      Clients.Caller.getCurrentRace(currentRace);
      Clients.All.updateRace(currentRace);
    }

  }

  public class RaceTimes
  {
    public string RacerId { get; set; }
    public int RaceTime { get; set; }
  }

  public class RaceTimesString
  {
    public string RacerId { get; set; }
    public string RaceTime { get; set; }
  }
}