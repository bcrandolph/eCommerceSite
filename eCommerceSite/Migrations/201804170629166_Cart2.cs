namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Cart2 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.AspNetUsers", "SizeId");
            AddForeignKey("dbo.AspNetUsers", "SizeId", "dbo.ShoppingCarts");
        }
        
        public override void Down()
        {
            DropIndex("dbo.AspNetUsers", "SizeId");
            DropForeignKey("dbo.AspNetUsers", "SizeId", "dbo.ShoppingCarts");
        }
    }
}
