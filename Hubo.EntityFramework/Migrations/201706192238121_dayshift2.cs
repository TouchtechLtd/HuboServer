namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dayshift2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkShifts", "DriverId", c => c.Long(nullable: false));
            DropColumn("dbo.DayShifts", "driverId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.DayShifts", "driverId", c => c.Long(nullable: false));
            DropColumn("dbo.WorkShifts", "DriverId");
        }
    }
}
