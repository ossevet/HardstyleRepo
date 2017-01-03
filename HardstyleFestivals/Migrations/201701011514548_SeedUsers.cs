namespace HardstyleFestivals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        //We gebruiken deze migration om handmatig via sql users toe te voegen.
        //Toen ik deze migration via "add-migration" in de pm console 
        public override void Up()
        {
            Sql(@"
                    INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4e9d8db2-2209-4acb-91e8-e88cf1039ead', N'admin@hardstyle-festivals.nl', 0, N'AGcIGbXfNx7Va5v8MGBhrI4rpUkzD0eSpVDCAB96vXi187u2+5zYT42VTRzgxw1R+g==', N'14ff2888-2a38-4241-83bb-87353766e170', NULL, 0, 0, NULL, 1, 0, N'admin@hardstyle-festivals.nl')
                    INSERT [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'dd4d1e98-8108-4984-ab4c-5df2598f9a88', N'gast@hardstyle-festivals.nl', 0, N'ADVHLk9UruiV8VipPk3G44/SWwtgsOGoT1zjrl9RBpYsv25mpktAtfINnp+krBKw0A==', N'12ef7700-047a-4f14-b9a6-a8362d07509d', NULL, 0, 0, NULL, 1, 0, N'gast@hardstyle-festivals.nl')
                
                    INSERT [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'85c3a7ab-2ca1-43e9-8260-d0f6311a4834', N'CanManageFestivals')

                    INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'4e9d8db2-2209-4acb-91e8-e88cf1039ead', N'85c3a7ab-2ca1-43e9-8260-d0f6311a4834')
                ");
        }
        
        public override void Down()
        {
        }
    }
}
