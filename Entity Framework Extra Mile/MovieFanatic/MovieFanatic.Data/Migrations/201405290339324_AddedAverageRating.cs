namespace MovieFanatic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedAverageRating : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "AverageRating", c => c.Decimal(precision: 4, scale: 2));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "AverageRating");
        }
    }
}
