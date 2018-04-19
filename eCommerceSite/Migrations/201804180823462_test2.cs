namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test2 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.CartItems", name: "Cart_Id2", newName: "CartId");
            RenameIndex(table: "dbo.CartItems", name: "IX_Cart_Id2", newName: "IX_CartId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.CartItems", name: "IX_CartId", newName: "IX_Cart_Id2");
            RenameColumn(table: "dbo.CartItems", name: "CartId", newName: "Cart_Id2");
        }
    }
}
