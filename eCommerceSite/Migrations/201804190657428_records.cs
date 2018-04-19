namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class records : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "CartId", "dbo.ShoppingCarts");
            DropForeignKey("dbo.Orders", "UserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "CartId" });
            DropIndex("dbo.Orders", new[] { "UserId" });
            CreateTable(
                "dbo.Records",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        CartId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ShoppingCarts", t => t.CartId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.CartId)
                .Index(t => t.UserId);
            
            DropTable("dbo.Orders");
        }
        
        public override void Down()
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
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.Records", "UserId", "dbo.Users");
            DropForeignKey("dbo.Records", "CartId", "dbo.ShoppingCarts");
            DropIndex("dbo.Records", new[] { "UserId" });
            DropIndex("dbo.Records", new[] { "CartId" });
            DropTable("dbo.Records");
            CreateIndex("dbo.Orders", "UserId");
            CreateIndex("dbo.Orders", "CartId");
            AddForeignKey("dbo.Orders", "UserId", "dbo.Users", "Id");
            AddForeignKey("dbo.Orders", "CartId", "dbo.ShoppingCarts", "Id", cascadeDelete: true);
        }
    }
}
