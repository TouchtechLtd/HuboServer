namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class driver : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Drivers", "CompanyId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "CompanyId", c => c.Long(nullable: false));
        }
    }
}
