namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.CartItems", "Cart_Id1");
        }
        
        public override void Down()
        {
        }
    }
}
