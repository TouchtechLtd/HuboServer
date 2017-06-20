namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dayshift1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DayShifts", "driverId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DayShifts", "driverId");
        }
    }
}
