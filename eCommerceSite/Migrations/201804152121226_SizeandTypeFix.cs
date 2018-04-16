namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SizeandTypeFix : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bundles", "Size_Id", "dbo.Sizes");
            DropForeignKey("dbo.Bundles", "Type_Id", "dbo.Types");
            DropIndex("dbo.Bundles", new[] { "Size_Id" });
            DropIndex("dbo.Bundles", new[] { "Type_Id" });
            RenameColumn(table: "dbo.Bundles", name: "Size_Id", newName: "SizeId");
            RenameColumn(table: "dbo.Bundles", name: "Type_Id", newName: "TypeId");
            DropPrimaryKey("dbo.Sizes");
            DropPrimaryKey("dbo.Types");
            AlterColumn("dbo.Bundles", "SizeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Bundles", "TypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Sizes", "Id", c => c.Byte(nullable: false));
            AlterColumn("dbo.Types", "Id", c => c.Byte(nullable: false));
            AddPrimaryKey("dbo.Sizes", "Id");
            AddPrimaryKey("dbo.Types", "Id");
            CreateIndex("dbo.Bundles", "TypeId");
            CreateIndex("dbo.Bundles", "SizeId");
            AddForeignKey("dbo.Bundles", "SizeId", "dbo.Sizes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Bundles", "TypeId", "dbo.Types", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bundles", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Bundles", "SizeId", "dbo.Sizes");
            DropIndex("dbo.Bundles", new[] { "SizeId" });
            DropIndex("dbo.Bundles", new[] { "TypeId" });
            DropPrimaryKey("dbo.Types");
            DropPrimaryKey("dbo.Sizes");
            AlterColumn("dbo.Types", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Sizes", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Bundles", "TypeId", c => c.Int());
            AlterColumn("dbo.Bundles", "SizeId", c => c.Int());
            AddPrimaryKey("dbo.Types", "Id");
            AddPrimaryKey("dbo.Sizes", "Id");
            RenameColumn(table: "dbo.Bundles", name: "TypeId", newName: "Type_Id");
            RenameColumn(table: "dbo.Bundles", name: "SizeId", newName: "Size_Id");
            AddColumn("dbo.Bundles", "TypeId", c => c.Byte(nullable: false));
            AddColumn("dbo.Bundles", "SizeId", c => c.Byte(nullable: false));
            CreateIndex("dbo.Bundles", "Type_Id");
            CreateIndex("dbo.Bundles", "Size_Id");
            AddForeignKey("dbo.Bundles", "Type_Id", "dbo.Types", "Id");
            AddForeignKey("dbo.Bundles", "Size_Id", "dbo.Sizes", "Id");
        }
    }
}
