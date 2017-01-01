namespace HardstyleFestivals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addServiceProviderTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceProviders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naam = c.String(nullable: false),
                        DefaultServiceCosts = c.Double(),
                        DefaultIdealCosts = c.Double(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServiceProviders");
        }
    }
}
