namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CartItems", "Cart_Id1", "dbo.ShoppingCarts");
            DropIndex("dbo.CartItems", new[] { "Cart_Id1" });
            AddColumn("dbo.CartItems", "Cart_Id2", c => c.Int(nullable: false));
            CreateIndex("dbo.CartItems", "Cart_Id2");
            AddForeignKey("dbo.CartItems", "Cart_Id2", "dbo.ShoppingCarts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CartItems", "Cart_Id2", "dbo.ShoppingCarts");
            DropIndex("dbo.CartItems", new[] { "Cart_Id2" });
            DropColumn("dbo.CartItems", "Cart_Id2");
            CreateIndex("dbo.CartItems", "Cart_Id1");
            AddForeignKey("dbo.CartItems", "Cart_Id1", "dbo.ShoppingCarts", "Id", cascadeDelete: true);
        }
    }
}
