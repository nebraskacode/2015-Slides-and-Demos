namespace MovieFanatic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShortenMovieTitle : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "Title", c => c.String(nullable: false, maxLength: 100));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "Title", c => c.String());
        }
    }
}
