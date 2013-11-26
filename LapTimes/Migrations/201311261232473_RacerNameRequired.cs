namespace LapTimes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RacerNameRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Racers", "Name", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Racers", "Name", c => c.String());
        }
    }
}
