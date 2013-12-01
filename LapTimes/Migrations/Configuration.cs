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
        new ClassName {Name = "RHM"},
        new ClassName {Name = "RJB"},
        new ClassName {Name = "RJP"},
        new ClassName {Name = "1LD/GR"},
        new ClassName {Name = "1KF"},
        new ClassName {Name = "1AT"},
        new ClassName {Name = "2H"},
        new ClassName {Name = "2JO"},
        new ClassName {Name = "2GW"},
        new ClassName {Name = "3AC"},
        new ClassName {Name = "3DS"},
        new ClassName {Name = "3RS/SS"},
        new ClassName {Name = "4JC"},
        new ClassName {Name = "4JJ"},
        new ClassName {Name = "4JSp"},
        new ClassName {Name = "5MR"},
        new ClassName {Name = "5NS"},
        new ClassName {Name = "5SO"},
        new ClassName {Name = "6AS"},
        new ClassName {Name = "6CW"},
        new ClassName {Name = "6HW"}
        );
    }
  }
}