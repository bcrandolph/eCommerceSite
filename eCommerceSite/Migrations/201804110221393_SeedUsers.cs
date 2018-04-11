namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.BundleViewModels", "Type_Id", "dbo.Types");
            DropIndex("dbo.BundleViewModels", new[] { "Type_Id" });
           // DropTable("dbo.BundleViewModels");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.BundleViewModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 255),
                        NumberInStock = c.Byte(),
                        AmtSold = c.Int(nullable: false),
                        Cost = c.Single(nullable: false),
                        Size = c.String(nullable: false, maxLength: 255),
                        Revenue = c.Single(nullable: false),
                        Type_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.BundleViewModels", "Type_Id");
            AddForeignKey("dbo.BundleViewModels", "Type_Id", "dbo.Types", "Id", cascadeDelete: true);
        }
    }
}
