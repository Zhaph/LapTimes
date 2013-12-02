namespace LapTimes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullableRaceDateTimes : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Races", "StartTime", c => c.DateTime());
            AlterColumn("dbo.Races", "EndTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Races", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Races", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
