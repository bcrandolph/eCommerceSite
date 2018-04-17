namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
            INSERT INTO[dbo].[AspNetUsers]([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [SizeId]) VALUES(N'9892c2c7-3a3d-4199-9342-f50b6bbc55ad', N'admin@gradeaboxco.com', 0, N'AAvAZT4BWFMwyofZ9zomm0AktfgyDaTCdADvuFcwV6/AGiqIWpkFkJ4Sk0Ymj9JnPg==', N'82453bc8-2ff9-4351-a83f-6fdd85a00ef7', NULL, 0, 0, NULL, 1, 0, N'admin@gradeaboxco.com', 3)
            ");
        }
        
        public override void Down()
        {
        }
    }
}
