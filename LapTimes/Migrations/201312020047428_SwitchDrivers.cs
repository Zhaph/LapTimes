namespace LapTimes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SwitchDrivers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drivers", "RacerId", "dbo.Racers");
            DropForeignKey("dbo.Drivers", "RaceId", "dbo.Races");
            DropForeignKey("dbo.Drivers", "CarId", "dbo.Cars");
            DropIndex("dbo.Drivers", new[] { "RacerId" });
            DropIndex("dbo.Drivers", new[] { "RaceId" });
            DropIndex("dbo.Drivers", new[] { "CarId" });
            CreateTable(
                "dbo.RaceDrivers",
                c => new
                    {
                        RacerId = c.Int(nullable: false),
                        RaceId = c.Int(nullable: false),
                        Lane = c.Int(nullable: false),
                        CarId = c.Int(nullable: false),
                        RawRaceTime = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RacerId, t.RaceId })
                .ForeignKey("dbo.Racers", t => t.RacerId, cascadeDelete: true)
                .ForeignKey("dbo.Races", t => t.RaceId, cascadeDelete: true)
                .ForeignKey("dbo.Cars", t => t.CarId, cascadeDelete: true)
                .Index(t => t.RacerId)
                .Index(t => t.RaceId)
                .Index(t => t.CarId);
            
            DropTable("dbo.Drivers");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.RacerId);
            
            DropIndex("dbo.RaceDrivers", new[] { "CarId" });
            DropIndex("dbo.RaceDrivers", new[] { "RaceId" });
            DropIndex("dbo.RaceDrivers", new[] { "RacerId" });
            DropForeignKey("dbo.RaceDrivers", "CarId", "dbo.Cars");
            DropForeignKey("dbo.RaceDrivers", "RaceId", "dbo.Races");
            DropForeignKey("dbo.RaceDrivers", "RacerId", "dbo.Racers");
            DropTable("dbo.RaceDrivers");
            CreateIndex("dbo.Drivers", "CarId");
            CreateIndex("dbo.Drivers", "RaceId");
            CreateIndex("dbo.Drivers", "RacerId");
            AddForeignKey("dbo.Drivers", "CarId", "dbo.Cars", "CarId", cascadeDelete: true);
            AddForeignKey("dbo.Drivers", "RaceId", "dbo.Races", "RaceId", cascadeDelete: true);
            AddForeignKey("dbo.Drivers", "RacerId", "dbo.Racers", "RacerId");
        }
    }
}
