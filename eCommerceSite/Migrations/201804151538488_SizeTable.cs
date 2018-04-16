namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SizeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bundles", "Type_Id", "dbo.Types");
            DropIndex("dbo.Bundles", new[] { "Type_Id" });
            DropIndex("dbo.Bundles", new[] { "Size_Id" });
            DropColumn("dbo.Bundles", "TypeId");
            DropColumn("dbo.Bundles", "SizeId");
            DropColumn("dbo.Bundles", "Size_Id");
            CreateTable(
                "dbo.Sizes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false, maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Bundles", "TypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Bundles", "SizeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Bundles", "Size_Id", c => c.Int());
            AlterColumn("dbo.Bundles", "Type_Id", c => c.Int());
            CreateIndex("dbo.Bundles", "Size_Id");
            CreateIndex("dbo.Bundles", "Type_Id");
        }
        
        public override void Down()
        {
            
            AddColumn("dbo.Bundles", "Size", c => c.String(nullable: false, maxLength: 255));
            DropForeignKey("dbo.Bundles", "Type_Id", "dbo.Types");
            DropForeignKey("dbo.Bundles", "Size_Id", "dbo.Sizes");
            DropIndex("dbo.Bundles", new[] { "Type_Id" });
            DropIndex("dbo.Bundles", new[] { "Size_Id" });
            AlterColumn("dbo.Bundles", "Type_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Bundles", "Size_Id");
            DropColumn("dbo.Bundles", "SizeId");
            DropColumn("dbo.Bundles", "TypeId");
            DropTable("dbo.Sizes");
            CreateIndex("dbo.Bundles", "Type_Id");
            AddForeignKey("dbo.Bundles", "Type_Id", "dbo.Types", "Id", cascadeDelete: true);
        }
    }
}
