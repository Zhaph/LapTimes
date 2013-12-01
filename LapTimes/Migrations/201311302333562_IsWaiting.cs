namespace LapTimes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class IsWaiting : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Racers", "IsWaitingForRace", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Racers", "IsWaitingForRace");
        }
    }
}
