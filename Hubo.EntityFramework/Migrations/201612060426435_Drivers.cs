namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Drivers : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Drivers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        userName = c.String(),
                        firstName = c.String(),
                        lastName = c.String(),
                        email = c.String(),
                        licenceNo = c.String(),
                        mobilePh = c.String(),
                        companyCode = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
        }
    }
}
