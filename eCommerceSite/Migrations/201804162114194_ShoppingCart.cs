namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShoppingCart : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "CartId", c => c.Int(nullable:false));

        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "CartId");

        }
    }
}
