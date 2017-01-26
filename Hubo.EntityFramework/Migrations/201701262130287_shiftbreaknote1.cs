namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shiftbreaknote1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ShiftBreakNotes", "IsBreak", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ShiftBreakNotes", "IsBreak");
        }
    }
}
