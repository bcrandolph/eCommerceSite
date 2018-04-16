namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES(N'9892c2c7-3a3d-4199-9342-f50b6bbc55ad', N'admin@gradeaboxco.com', 0, N'AAvAZT4BWFMwyofZ9zomm0AktfgyDaTCdADvuFcwV6/AGiqIWpkFkJ4Sk0Ymj9JnPg==', N'82453bc8-2ff9-4351-a83f-6fdd85a00ef7', NULL, 0, 0, NULL, 1, 0, N'admin@gradeaboxco.com')
            INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f4dda828-09df-4099-983c-005e1e2c162f', N'CanManageBundles')
            INSERT INTO[dbo].[AspNetRoles] ([Id], [Name]) VALUES(N'2ceec619-1c22-4c56-93a4-1ead7fb501a3', N'CanViewReports')
            INSERT INTO[dbo].[AspNetUserRoles]([UserId], [RoleId]) VALUES(N'9892c2c7-3a3d-4199-9342-f50b6bbc55ad', N'2ceec619-1c22-4c56-93a4-1ead7fb501a3')
            INSERT INTO[dbo].[AspNetUserRoles]([UserId], [RoleId]) VALUES(N'9892c2c7-3a3d-4199-9342-f50b6bbc55ad', N'f4dda828-09df-4099-983c-005e1e2c162f')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
