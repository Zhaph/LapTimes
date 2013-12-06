using System;
using System.Collections.Generic;
using LapTimes.Hubs;
using LapTimes.Models;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace LapTimes
{
  public class RaceServer
  {
    private static readonly Lazy<RaceServer> _instance =
      new Lazy<RaceServer>(() => new RaceServer(GlobalHost.ConnectionManager.GetHubContext<RaceHub>().Clients));

    private IHubConnectionContext clients { get; set; }

    public static RaceServer Instance
    {
      get
      {
        return _instance.Value;
      }
    }

    private RaceServer(IHubConnectionContext clients)
    {
      this.clients = clients;
    }

    public void BroadcastUpdatedLeagues(List<List<Racer>> leagues)
    {
      clients.All.updateLeagues(leagues);
    }
  }
}