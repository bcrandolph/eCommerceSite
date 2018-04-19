namespace eCommerceSite.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Seed : DbMigration
    {
        public override void Up()
        {
            Sql(@"
SET IDENTITY_INSERT [dbo].[ShoppingCarts] ON
INSERT INTO [dbo].[ShoppingCarts] ([Id], [CartTotal]) VALUES (3, 0)
INSERT INTO [dbo].[ShoppingCarts] ([Id], [CartTotal]) VALUES (4, 0)
INSERT INTO [dbo].[ShoppingCarts] ([Id], [CartTotal]) VALUES (5, 0)
INSERT INTO [dbo].[ShoppingCarts] ([Id], [CartTotal]) VALUES (6, 0)
SET IDENTITY_INSERT [dbo].[ShoppingCarts] OFF
INSERT INTO [dbo].[Sizes] ([Id], [name]) VALUES (1, N'Small')
INSERT INTO [dbo].[Sizes] ([Id], [name]) VALUES (2, N'Medium')
INSERT INTO [dbo].[Sizes] ([Id], [name]) VALUES (3, N'Large')
INSERT INTO [dbo].[Types] ([Id], [Name]) VALUES (1, N'Basic')
INSERT INTO [dbo].[Types] ([Id], [Name]) VALUES (4, N'Elementary')
INSERT INTO [dbo].[Types] ([Id], [Name]) VALUES (5, N'Middle')
INSERT INTO [dbo].[Types] ([Id], [Name]) VALUES (6, N'High School')
INSERT INTO [dbo].[Types] ([Id], [Name]) VALUES (7, N'College')
INSERT INTO [dbo].[Users] ([Id], [Name], [Billing], [Shipping], [Payment], [CartId], [Email]) VALUES (N'7e0ef034-78ca-41e4-a093-6b83242f84e2', N'Guest', NULL, NULL, NULL, 3, N'guest@gradeaboxco.com')
INSERT INTO [dbo].[Users] ([Id], [Name], [Billing], [Shipping], [Payment], [CartId], [Email]) VALUES (N'bed2670a-98f0-4250-a043-eef5c07a978d', N'Brenan', NULL, NULL, NULL, 6, N'test@box.com')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f4dda828-09df-4099-983c-005e1e2c162f', N'CanManageBundles')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'2ceec619-1c22-4c56-93a4-1ead7fb501a3', N'CanViewReports')
SET IDENTITY_INSERT [dbo].[Bundles] ON
INSERT INTO [dbo].[Bundles] ([Id], [Name], [NumberInStock], [AmtSold], [Cost], [TypeId], [SizeId]) VALUES (9, N'College Starter Kit', 5, 4, 1000, 7, 3)
INSERT INTO [dbo].[Bundles] ([Id], [Name], [NumberInStock], [AmtSold], [Cost], [TypeId], [SizeId]) VALUES (10, N'Elementary Starter Kit', 20, 2, 30, 4, 2)
INSERT INTO [dbo].[Bundles] ([Id], [Name], [NumberInStock], [AmtSold], [Cost], [TypeId], [SizeId]) VALUES (11, N'Middle School Starter Kit', 20, 3, 30, 5, 2)
INSERT INTO [dbo].[Bundles] ([Id], [Name], [NumberInStock], [AmtSold], [Cost], [TypeId], [SizeId]) VALUES (12, N'High School Starter Kit', 20, 7, 50, 6, 2)
INSERT INTO [dbo].[Bundles] ([Id], [Name], [NumberInStock], [AmtSold], [Cost], [TypeId], [SizeId]) VALUES (14, N'Pencil Set', 15, 4, 10, 1, 1)
INSERT INTO [dbo].[Bundles] ([Id], [Name], [NumberInStock], [AmtSold], [Cost], [TypeId], [SizeId]) VALUES (15, N'The College Music Bundle', 10, 0, 20, 7, 2)
SET IDENTITY_INSERT [dbo].[Bundles] OFF


                   
                                        ");
        }
        
        public override void Down()
        {
        }
    }
}
