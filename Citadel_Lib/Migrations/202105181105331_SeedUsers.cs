namespace Citadel_Lib.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'f2e8f148-4abe-4df4-8e20-6af925c7fb38', N'admin@citadel.lib', 0, N'AGtkLzQ8cmFKm4t9/yq3oulbsyxyagHAuTzUBmUECI3S23yjaZGnEFJsV761GC9hYg==', N'09600c4e-0f20-4458-8720-724fd8c06176', NULL, 0, 0, NULL, 1, 0, N'admin@citadel.lib')
INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'bf86c163-943b-4485-a30a-fa5a922fb09c', N'CanManageRentals')
INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'f2e8f148-4abe-4df4-8e20-6af925c7fb38', N'bf86c163-943b-4485-a30a-fa5a922fb09c')
");

        }
        
        public override void Down()
        {
        }
    }
}
