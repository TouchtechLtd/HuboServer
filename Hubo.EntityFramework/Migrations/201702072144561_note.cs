namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class note : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Notes", "StandAloneNote", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Notes", "StandAloneNote");
        }
    }
}
