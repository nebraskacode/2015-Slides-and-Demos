namespace MovieFanatic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedMovieGenres : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Genres", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.Genres", new[] { "Movie_Id" });
            CreateTable(
                "dbo.MovieGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Genre_Id = c.Int(),
                        Movie_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Genres", t => t.Genre_Id)
                .ForeignKey("dbo.Movies", t => t.Movie_Id)
                .Index(t => t.Genre_Id)
                .Index(t => t.Movie_Id);
            
            DropColumn("dbo.Genres", "Movie_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Movie_Id", c => c.Int());
            DropForeignKey("dbo.MovieGenres", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.MovieGenres", "Genre_Id", "dbo.Genres");
            DropIndex("dbo.MovieGenres", new[] { "Movie_Id" });
            DropIndex("dbo.MovieGenres", new[] { "Genre_Id" });
            DropTable("dbo.MovieGenres");
            CreateIndex("dbo.Genres", "Movie_Id");
            AddForeignKey("dbo.Genres", "Movie_Id", "dbo.Movies", "Id");
        }
    }
}
