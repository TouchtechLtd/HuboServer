namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shift : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Shifts", "StartDateTime", c => c.DateTime());
            AlterColumn("dbo.Shifts", "EndDateTime", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Shifts", "EndDateTime", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Shifts", "StartDateTime", c => c.DateTime(nullable: false));
        }
    }
}
