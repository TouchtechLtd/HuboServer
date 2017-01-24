namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class breaks3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Breaks", "StartBreakTime", c => c.DateTime());
            AlterColumn("dbo.Breaks", "EndBreakTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Breaks", "EndBreakTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Breaks", "StartBreakTime", c => c.DateTime(nullable: false));
        }
    }
}
