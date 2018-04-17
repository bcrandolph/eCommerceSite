namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CartStuff : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Users", name: "Cart_Id", newName: "CartId");
            RenameIndex(table: "dbo.Users", name: "IX_Cart_Id", newName: "IX_CartId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Users", name: "IX_CartId", newName: "IX_Cart_Id");
            RenameColumn(table: "dbo.Users", name: "CartId", newName: "Cart_Id");
        }
    }
}
