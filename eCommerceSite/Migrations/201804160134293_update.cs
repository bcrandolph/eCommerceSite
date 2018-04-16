namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Bundles", "Revenue");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Bundles", "Revenue", c => c.Single(nullable: false));
        }
    }
}
