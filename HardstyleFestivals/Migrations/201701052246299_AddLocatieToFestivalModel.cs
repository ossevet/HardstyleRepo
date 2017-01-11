namespace HardstyleFestivals.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddLocatieToFestivalModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Festivals", "Locatie", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Festivals", "Locatie");
        }
    }
}
