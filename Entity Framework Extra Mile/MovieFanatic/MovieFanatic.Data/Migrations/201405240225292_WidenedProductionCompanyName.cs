namespace MovieFanatic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WidenedProductionCompanyName : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ProductionCompanies", "Name", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ProductionCompanies", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
