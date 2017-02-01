namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workshift : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WorkShifts", "TimeStamp", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.WorkShifts", "TimeStamp");
        }
    }
}
