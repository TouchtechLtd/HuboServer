namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class geodata : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.GeoDatas", "DrivingShiftId", c => c.Long(nullable: false));
            DropColumn("dbo.GeoDatas", "ShiftId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.GeoDatas", "ShiftId", c => c.Long(nullable: false));
            DropColumn("dbo.GeoDatas", "DrivingShiftId");
        }
    }
}
