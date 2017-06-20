namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class drivingshift : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DrivingShifts", "StartLocation", c => c.String());
            AddColumn("dbo.DrivingShifts", "EndLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DrivingShifts", "EndLocation");
            DropColumn("dbo.DrivingShifts", "StartLocation");
        }
    }
}
