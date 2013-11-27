using System.Data.Entity.Migrations;
using LapTimes.Models;

namespace LapTimes.Migrations
{
  internal sealed class Configuration : DbMigrationsConfiguration<LapTimesContext>
  {
    public Configuration()
    {
      AutomaticMigrationsEnabled = false;
    }

    protected override void Seed(LapTimesContext context)
    {
      //  This method will be called after migrating to the latest version.
      //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
      //  to avoid creating duplicate seed data.
      context.Leagues.AddOrUpdate(
        l => l.Name,
        new League {Name = "Infants", Description = "Up to Year 2 inclusive"},
        new League {Name = "Juniors", Description = "Years 3 through 6"},
        new League {Name = "Seniors", Description = "Year 7 and up"}
        );

      context.ClassNames.AddOrUpdate(
        c => c.Name,
        new ClassName { Name = "RJB" },
        new ClassName { Name = "1LD" },
        new ClassName { Name = "4JC" }
        );
    }
  }
}