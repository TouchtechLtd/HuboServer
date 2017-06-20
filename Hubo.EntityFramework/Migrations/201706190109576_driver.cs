namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class driver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "SupervisorId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "SupervisorId");
        }
    }
}
