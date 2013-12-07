namespace LapTimes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WinnerToCurrentDriver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RaceDrivers", "Winner", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RaceDrivers", "Winner");
        }
    }
}
