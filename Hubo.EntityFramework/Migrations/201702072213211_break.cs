namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _break : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Breaks", "DriveShiftId", c => c.Long(nullable: false));
            DropColumn("dbo.Breaks", "ShiftId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Breaks", "ShiftId", c => c.Long(nullable: false));
            DropColumn("dbo.Breaks", "DriveShiftId");
        }
    }
}
