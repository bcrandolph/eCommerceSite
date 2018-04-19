namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ea046978-3dae-41bc-9a5c-374d4c315152', N'f4dda828-09df-4099-983c-005e1e2c162f')
                    INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ea046978-3dae-41bc-9a5c-374d4c315152', N'2ceec619-1c22-4c56-93a4-1ead7fb501a3')");


        }
        
        public override void Down()
        {
        }
    }
}
