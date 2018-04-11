namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers2 : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'eea8c93a-4379-4eaa-8f06-a81225cc8a58', N'admin@gradeaboxco.com', 0, N'AJLo96j94Tu1lstgBGuYmkIadsxB9EtAhbi77Xk9AcFvSTUeST5eN2fQuaGT7xkHNQ==', N'b6eea42b-8bb6-4692-aef6-e7ff1ef67154', NULL, 0, 0, NULL, 1, 0, N'admin@gradeaboxco.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f971fcfa-d956-48c4-9ed7-d040070da529', N'guest@gradeaboxco.com', 0, N'AJlsR5+wKb3k2I5WMK6MzgW6fqtlLguVAt0F6LaKOV7W2AyvH038AExttVpgqmKyWA==', N'5779d478-d85f-49e9-8da6-92eb799131be', NULL, 0, 0, NULL, 1, 0, N'guest@gradeaboxco.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'8fd18cf4-ab24-4b58-8399-8a2c8313b67a', N'CanManageGallery')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'eea8c93a-4379-4eaa-8f06-a81225cc8a58', N'8fd18cf4-ab24-4b58-8399-8a2c8313b67a')
");
        }
        
        public override void Down()
        {

        }
    }
}
