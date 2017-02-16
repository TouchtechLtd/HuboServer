namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workshifts : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkShifts", "StartLocation", c => c.String());
            AddColumn("dbo.WorkShifts", "EndLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkShifts", "EndLocation");
            DropColumn("dbo.WorkShifts", "StartLocation");
        }
    }
}
