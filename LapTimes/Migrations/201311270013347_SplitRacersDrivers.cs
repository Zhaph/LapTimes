namespace LapTimes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SplitRacersDrivers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Racers", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Racers", "CarId", "dbo.Cars");
            DropIndex("dbo.Racers", new[] { "RaceId" });
            DropIndex("dbo.Racers", new[] { "CarId" });
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        RacerId = c.Int(nullable: false),
                        RaceId = c.Int(nullable: false),
                        Lane = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        RawRaceTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RacerId)
                .ForeignKey("dbo.Racers", t => t.RacerId)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.RacerId)
                .Index(t => t.RaceId)
                .Index(t => t.CarId);
            
            DropColumn("dbo.Racers", "RaceId");
            DropColumn("dbo.Racers", "Lane");
            DropColumn("dbo.Racers", "CarId");
            DropColumn("dbo.Racers", "RawRaceTime");
            DropColumn("dbo.Racers", "Discriminator");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Racers", "Discriminator", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Racers", "RawRaceTime", c => c.Int());
            AddColumn("dbo.Racers", "CarId", c => c.Int());
            AddColumn("dbo.Racers", "Lane", c => c.Int());
            AddColumn("dbo.Racers", "RaceId", c => c.Int());
            DropIndex("dbo.Drivers", new[] { "CarId" });
            DropIndex("dbo.Drivers", new[] { "RaceId" });
            DropIndex("dbo.Drivers", new[] { "RacerId" });
            DropForeignKey("dbo.Drivers", "CarId", "dbo.Cars");
            DropForeignKey("dbo.Drivers", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Drivers", "RacerId", "dbo.Racers");
            DropTable("dbo.Drivers");
            CreateIndex("dbo.Racers", "CarId");
            CreateIndex("dbo.Racers", "RaceId");
            AddForeignKey("dbo.Racers", "CarId", "dbo.Cars", "CarId", cascadeDelete: true);
            AddForeignKey("dbo.Racers", "RaceId", "dbo.Races", "RaceId", cascadeDelete: true);
        }
    }
}
