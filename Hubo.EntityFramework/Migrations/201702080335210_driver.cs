namespace Hubo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class driver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "PhoneNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Drivers", "LicenceNumber", c => c.String());
            AddColumn("dbo.Drivers", "LicenceVersion", c => c.String());
            AddColumn("dbo.Drivers", "LicenceEndorsement", c => c.String());
            AddColumn("dbo.Drivers", "Address1", c => c.String());
            AddColumn("dbo.Drivers", "Address2", c => c.String());
            AddColumn("dbo.Drivers", "Address3", c => c.String());
            AddColumn("dbo.Drivers", "PostCode", c => c.String());
            AddColumn("dbo.Drivers", "City", c => c.String());
            AddColumn("dbo.Drivers", "Country", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "Country");
            DropColumn("dbo.Drivers", "City");
            DropColumn("dbo.Drivers", "PostCode");
            DropColumn("dbo.Drivers", "Address3");
            DropColumn("dbo.Drivers", "Address2");
            DropColumn("dbo.Drivers", "Address1");
            DropColumn("dbo.Drivers", "LicenceEndorsement");
            DropColumn("dbo.Drivers", "LicenceVersion");
            DropColumn("dbo.Drivers", "LicenceNumber");
            DropColumn("dbo.Drivers", "PhoneNumber");
        }
    }
}
