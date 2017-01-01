namespace HardstyleFestivals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changecolumntypeserviceprovider : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Festivals", "ServiceProvider_Id", c => c.Int());
            CreateIndex("dbo.Festivals", "ServiceProvider_Id");
            AddForeignKey("dbo.Festivals", "ServiceProvider_Id", "dbo.ServiceProviders", "Id");
            DropColumn("dbo.Festivals", "ServiceProvider");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Festivals", "ServiceProvider", c => c.String());
            DropForeignKey("dbo.Festivals", "ServiceProvider_Id", "dbo.ServiceProviders");
            DropIndex("dbo.Festivals", new[] { "ServiceProvider_Id" });
            DropColumn("dbo.Festivals", "ServiceProvider_Id");
        }
    }
}
