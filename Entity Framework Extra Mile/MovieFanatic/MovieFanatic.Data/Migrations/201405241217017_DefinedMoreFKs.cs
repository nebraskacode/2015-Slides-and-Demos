namespace MovieFanatic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DefinedMoreFKs : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Characters", "Actor_Id", "dbo.Actors");
            DropForeignKey("dbo.MovieGenres", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.ProductionCompanyMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.MovieGenres", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.ProductionCompanyMovies", "ProductionCompany_Id", "dbo.ProductionCompanies");
            DropIndex("dbo.Characters", new[] { "Actor_Id" });
            DropIndex("dbo.MovieGenres", new[] { "Genre_Id" });
            DropIndex("dbo.MovieGenres", new[] { "Movie_Id" });
            DropIndex("dbo.ProductionCompanyMovies", new[] { "Movie_Id" });
            DropIndex("dbo.ProductionCompanyMovies", new[] { "ProductionCompany_Id" });
            AlterColumn("dbo.Characters", "Actor_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieGenres", "Genre_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.MovieGenres", "Movie_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductionCompanyMovies", "Movie_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.ProductionCompanyMovies", "ProductionCompany_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Characters", "Actor_Id");
            CreateIndex("dbo.MovieGenres", "Genre_Id");
            CreateIndex("dbo.MovieGenres", "Movie_Id");
            CreateIndex("dbo.ProductionCompanyMovies", "Movie_Id");
            CreateIndex("dbo.ProductionCompanyMovies", "ProductionCompany_Id");
            AddForeignKey("dbo.Characters", "Actor_Id", "dbo.Actors", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovieGenres", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductionCompanyMovies", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.MovieGenres", "Genre_Id", "dbo.Genres", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductionCompanyMovies", "ProductionCompany_Id", "dbo.ProductionCompanies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductionCompanyMovies", "ProductionCompany_Id", "dbo.ProductionCompanies");
            DropForeignKey("dbo.MovieGenres", "Genre_Id", "dbo.Genres");
            DropForeignKey("dbo.ProductionCompanyMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.MovieGenres", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.Characters", "Actor_Id", "dbo.Actors");
            DropIndex("dbo.ProductionCompanyMovies", new[] { "ProductionCompany_Id" });
            DropIndex("dbo.ProductionCompanyMovies", new[] { "Movie_Id" });
            DropIndex("dbo.MovieGenres", new[] { "Movie_Id" });
            DropIndex("dbo.MovieGenres", new[] { "Genre_Id" });
            DropIndex("dbo.Characters", new[] { "Actor_Id" });
            AlterColumn("dbo.ProductionCompanyMovies", "ProductionCompany_Id", c => c.Int());
            AlterColumn("dbo.ProductionCompanyMovies", "Movie_Id", c => c.Int());
            AlterColumn("dbo.MovieGenres", "Movie_Id", c => c.Int());
            AlterColumn("dbo.MovieGenres", "Genre_Id", c => c.Int());
            AlterColumn("dbo.Characters", "Actor_Id", c => c.Int());
            CreateIndex("dbo.ProductionCompanyMovies", "ProductionCompany_Id");
            CreateIndex("dbo.ProductionCompanyMovies", "Movie_Id");
            CreateIndex("dbo.MovieGenres", "Movie_Id");
            CreateIndex("dbo.MovieGenres", "Genre_Id");
            CreateIndex("dbo.Characters", "Actor_Id");
            AddForeignKey("dbo.ProductionCompanyMovies", "ProductionCompany_Id", "dbo.ProductionCompanies", "Id");
            AddForeignKey("dbo.MovieGenres", "Genre_Id", "dbo.Genres", "Id");
            AddForeignKey("dbo.ProductionCompanyMovies", "Movie_Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.MovieGenres", "Movie_Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.Characters", "Actor_Id", "dbo.Actors", "Id");
        }
    }
}
