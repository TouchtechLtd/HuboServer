namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _break : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Breaks", "GeoDataId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Breaks", "GeoDataId", c => c.Long(nullable: false));
        }
    }
}
