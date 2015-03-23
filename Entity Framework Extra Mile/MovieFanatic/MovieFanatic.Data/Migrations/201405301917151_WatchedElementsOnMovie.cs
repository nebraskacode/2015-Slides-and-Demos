namespace MovieFanatic.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class WatchedElementsOnMovie : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "HaveWatched", c => c.Boolean(nullable: false));
            AddColumn("dbo.Movies", "WatchedOn", c => c.DateTime());
            AddColumn("dbo.Movies", "Review", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Movies", "Review");
            DropColumn("dbo.Movies", "WatchedOn");
            DropColumn("dbo.Movies", "HaveWatched");
        }
    }
}
