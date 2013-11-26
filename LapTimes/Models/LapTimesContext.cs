using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LapTimes.Models
{
  public class LapTimesContext: DbContext
  {
    public DbSet<Race> Races { get; set; }
    public DbSet<CurrentDriver> CurrentDrivers { get; set; }
    public DbSet<Racer> Racers { get; set; }
    public DbSet<League> Leagues { get; set; }
    public DbSet<ClassName> ClassNames { get; set; }
    public DbSet<Car> Cars { get; set; }  
  }
}