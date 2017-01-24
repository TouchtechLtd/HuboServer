namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class breaks1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Breaks", "ShiftId", c => c.Int(nullable: false));
            AddColumn("dbo.Breaks", "StartBreak", c => c.DateTime(nullable: false));
            AddColumn("dbo.Breaks", "EndBreak", c => c.DateTime(nullable: false));
            AddColumn("dbo.Breaks", "StartNoteKey", c => c.Int(nullable: false));
            AddColumn("dbo.Breaks", "EndNoteKey", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Breaks", "EndNoteKey");
            DropColumn("dbo.Breaks", "StartNoteKey");
            DropColumn("dbo.Breaks", "EndBreak");
            DropColumn("dbo.Breaks", "StartBreak");
            DropColumn("dbo.Breaks", "ShiftId");
        }
    }
}
