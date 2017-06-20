namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class vehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "IsManuallyEntered", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "IsManuallyEntered");
        }
    }
}
