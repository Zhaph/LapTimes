using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LapTimes.Models;
using Microsoft.AspNet.SignalR;

namespace LapTimes.Hubs
{
  public class RaceHub: Hub
  {
    private ILapTimeRepository _repo;

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
        }

        _repo.Save();

        Clients.All.updateRace(currentRace);
      }
    }

    public void FinishRace(int raceId, RaceTimes[] raceTimes)
    {
      Race currentRace = _repo.GetRace(raceId);

      currentRace.IsComplete = true;

      foreach (var driver in currentRace.Drivers)
      {
        driver.Racer.IsWaitingForRace = false;
        driver.RawRaceTime = raceTimes.Single(rt => rt.RacerId == driver.RacerId.ToString()).RaceTime;

        if (driver.RawRaceTime < driver.Racer.RawBestTime || driver.Racer.RawBestTime == 0)
        {
          driver.Racer.RawBestTime = driver.RawRaceTime;
        }
      }

      _repo.Save();

      GetAllLeagues();
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
}