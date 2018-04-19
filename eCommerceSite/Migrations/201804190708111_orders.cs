namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class orders : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Address = c.String(),
                        City = c.String(),
                        State = c.String(),
                        PostalCode = c.String(),
                        Country = c.String(),
                        Phone = c.String(),
                        Email = c.String(),
                        CreditCart = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId);
            
            AddColumn("dbo.Records", "OrderId", c => c.Int(nullable: false));
            AddColumn("dbo.Records", "Total", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            CreateIndex("dbo.Records", "OrderId");
            AddForeignKey("dbo.Records", "OrderId", "dbo.Orders", "OrderId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Records", "OrderId", "dbo.Orders");
            DropIndex("dbo.Records", new[] { "OrderId" });
            DropColumn("dbo.Records", "Total");
            DropColumn("dbo.Records", "OrderId");
            DropTable("dbo.Orders");
        }
    }
}
