namespace MovieFanatic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMoreFieldsToMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ApiId", c => c.Int(nullable: false));
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "ReleaseDate");
            DropColumn("dbo.Movies", "ApiId");
        }
    }
}
