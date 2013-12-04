using System.Collections.Generic;
using LapTimes.Models;

namespace LapTimes.Areas.ManageRacers.Models
{
  public class RacersHomeModel
  {
    public string Filter { get; set; }
    public IEnumerable<Racer> Racers { get; set; } 
  }
}