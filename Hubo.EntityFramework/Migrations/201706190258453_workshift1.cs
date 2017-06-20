namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workshift1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.WorkShifts", "DriverId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkShifts", "DriverId", c => c.Long(nullable: false));
        }
    }
}
