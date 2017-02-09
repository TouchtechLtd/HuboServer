namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _break : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Breaks", "StartBreakLocation", c => c.String());
            AddColumn("dbo.Breaks", "StopBreakLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Breaks", "StopBreakLocation");
            DropColumn("dbo.Breaks", "StartBreakLocation");
        }
    }
}
