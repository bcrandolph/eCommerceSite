namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class images : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Bundles", "ImageLink", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Bundles", "ImageLink");
        }
    }
}
