namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Bundles", "Type_Id", "dbo.Types");
            DropIndex("dbo.Bundles", new[] { "Type_Id" });
            AddColumn("dbo.Bundles", "TypeId", c => c.Byte(nullable: false));
            AlterColumn("dbo.Bundles", "Type_Id", c => c.Int());
            CreateIndex("dbo.Bundles", "Type_Id");
            AddForeignKey("dbo.Bundles", "Type_Id", "dbo.Types", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bundles", "Type_Id", "dbo.Types");
            DropIndex("dbo.Bundles", new[] { "Type_Id" });
            AlterColumn("dbo.Bundles", "Type_Id", c => c.Int(nullable: false));
            DropColumn("dbo.Bundles", "TypeId");
            CreateIndex("dbo.Bundles", "Type_Id");
            AddForeignKey("dbo.Bundles", "Type_Id", "dbo.Types", "Id", cascadeDelete: true);
        }
    }
}
