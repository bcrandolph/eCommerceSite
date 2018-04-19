namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CartId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        BillingAddress = c.String(),
                        ShippingAddress = c.String(),
                        Total = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShoppingCarts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.CartId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "CartId", "dbo.ShoppingCarts");
            DropIndex("dbo.Orders", new[] { "UserId" });
            DropIndex("dbo.Orders", new[] { "CartId" });
            DropTable("dbo.Orders");
        }
    }
}
