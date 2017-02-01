namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class workshift1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.WorkShifts", "TimeStamp");
        }
        
        public override void Down()
        {
            AddColumn("dbo.WorkShifts", "TimeStamp", c => c.DateTime(nullable: false));
        }
    }
}
