namespace LapTimes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Races",
                c => new
                    {
                        RaceId = c.Int(nullable: false, identity: true),
                        IsComplete = c.Boolean(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.RaceId);
            
            CreateTable(
                "dbo.Racers",
                c => new
                    {
                        RacerId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        RawBestTime = c.Int(nullable: false),
                        ClassId = c.Int(nullable: false),
                        LeagueId = c.Int(nullable: false),
                        RaceId = c.Int(),
                        Lane = c.Int(),
                        CarId = c.Int(),
                        RawRaceTime = c.Int(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.RacerId)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .ForeignKey("dbo.ClassNames", t => t.ClassId, cascadeDelete: true)
                .ForeignKey("dbo.Leagues", t => t.LeagueId, cascadeDelete: true)
                .Index(t => t.RaceId)
                .Index(t => t.CarId)
                .Index(t => t.ClassId)
                .Index(t => t.LeagueId);
            
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        CarId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.CarId);
            
            CreateTable(
                "dbo.ClassNames",
                c => new
                    {
                        ClassId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ClassId);
            
            CreateTable(
                "dbo.Leagues",
                c => new
                    {
                        LeagueId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.LeagueId);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Racers", new[] { "LeagueId" });
            DropIndex("dbo.Racers", new[] { "ClassId" });
            DropIndex("dbo.Racers", new[] { "CarId" });
            DropIndex("dbo.Racers", new[] { "RaceId" });
            DropForeignKey("dbo.Racers", "LeagueId", "dbo.Leagues");
            DropForeignKey("dbo.Racers", "ClassId", "dbo.ClassNames");
            DropForeignKey("dbo.Racers", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Racers", "RaceId", "dbo.Races");
            DropTable("dbo.Leagues");
            DropTable("dbo.ClassNames");
            DropTable("dbo.Cars");
            DropTable("dbo.Racers");
            DropTable("dbo.Races");
        }
    }
}
