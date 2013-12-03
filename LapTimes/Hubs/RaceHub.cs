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
      Clients.Caller.getCurrentRace(_repo.CurrentRace());
    }

  }
}