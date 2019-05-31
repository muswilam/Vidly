namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'a0c627f2-71d2-4628-9aa6-d43c0c22c06e', N'guest@vidly.com', 0, N'AD3N4+7Qr+akrj+Guzd4zykrelnlFot7LyJTdE2V86Azzcm+AOwtzZP7ebObREdxlw==', N'70422aa1-0f5b-4434-81c2-eb88f6fb79c7', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'c2518d8e-c1ea-4666-b7e5-81ac89bc0654', N'admin@vidly.com', 0, N'AFX+U19+Df9ldvB310WQZ4XWcLQOKdpsUB4omC0dckqz7/RbZ89vg3BSplQagR5dIQ==', N'fc041411-421f-4713-9348-7b3d974d0761', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'f3b743c9-65f2-4f62-beec-ff5362060d03', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c2518d8e-c1ea-4666-b7e5-81ac89bc0654', N'f3b743c9-65f2-4f62-beec-ff5362060d03')

");
        }
        
        public override void Down()
        {
        }
    }
}
