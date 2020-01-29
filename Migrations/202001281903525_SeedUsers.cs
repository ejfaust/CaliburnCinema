namespace Caliburn.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'5b37eccb-feb5-4977-955c-c9c93a48febc', N'admin@alliterativearts.com', 1, N'AAMLVBx/qU2PRfl/6nNmg4K4MOzGntg0yBlIpJnA/JMJnCvEozXkTLejEocMgqv/bA==', N'bb559b9d-08d8-4edd-bc61-8d3977205a67', NULL, 0, 0, NULL, 0, 0, N'admin@alliterativearts.com', N'123456', N'5555555555')
                INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName], [DrivingLicense], [Phone]) VALUES (N'bcd64c56-1ab5-4544-a1c2-86cae022fc03', N'guest@alliterativearts.com', 1, N'AGmWNXhigT+bmVa8vIUMHVgep0tGXEaBON9YPVAHzGPNc3b4MoeWUynWMgzDJDngvA==', N'ebb76c8d-d50e-4c42-82e9-c417e26b808f', NULL, 0, 0, NULL, 0, 0, N'guest@alliterativearts.com', N'234567', N'5555555555')
                INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'3f21104a-f10e-45e6-a038-2fa9fec38c33', N'CanManageMovies')
                INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'5b37eccb-feb5-4977-955c-c9c93a48febc', N'3f21104a-f10e-45e6-a038-2fa9fec38c33')
            ");
        }
        
        public override void Down()
        {
        }
    }
}
