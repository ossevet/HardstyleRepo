namespace HardstyleFestivals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addServiceProviderAndNullableServiceProviderIdToFestivalsModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Festivals", "ServiceProviderId", c => c.Int());
            CreateIndex("dbo.Festivals", "ServiceProviderId");
            AddForeignKey("dbo.Festivals", "ServiceProviderId", "dbo.ServiceProviders", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Festivals", "ServiceProviderId", "dbo.ServiceProviders");
            DropIndex("dbo.Festivals", new[] { "ServiceProviderId" });
            DropColumn("dbo.Festivals", "ServiceProviderId");
        }
    }
}
