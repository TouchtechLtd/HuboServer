namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class shiftbreaknote : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ShiftBreakNotes", "NoteId", c => c.Long(nullable: false));
            AlterColumn("dbo.ShiftBreakNotes", "BreakShiftId", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ShiftBreakNotes", "BreakShiftId", c => c.Int(nullable: false));
            AlterColumn("dbo.ShiftBreakNotes", "NoteId", c => c.Int(nullable: false));
        }
    }
}
