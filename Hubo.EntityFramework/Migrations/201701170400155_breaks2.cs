namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class breaks2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Breaks", "StartBreakTime", c => c.DateTime(nullable: false));
            AddColumn("dbo.Breaks", "EndBreakTime", c => c.DateTime(nullable: false));
            DropColumn("dbo.Breaks", "StartBreak");
            DropColumn("dbo.Breaks", "EndBreak");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Breaks", "EndBreak", c => c.DateTime(nullable: false));
            AddColumn("dbo.Breaks", "StartBreak", c => c.DateTime(nullable: false));
            DropColumn("dbo.Breaks", "EndBreakTime");
            DropColumn("dbo.Breaks", "StartBreakTime");
        }
    }
}
