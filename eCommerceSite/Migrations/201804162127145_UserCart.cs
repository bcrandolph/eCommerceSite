namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserCart : DbMigration
    {
        public override void Up()
        {
            AddForeignKey("dbo.AspNetUsers", "CartId", "dbo.ShoppingCarts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "CartId", "dbo.ShoppingCarts");
        }
    }
}
