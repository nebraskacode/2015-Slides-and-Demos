namespace MovieFanatic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixedProductionCompany : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProductionCompanyMovieMovies", "ProductionCompanyMovie_Id", "dbo.ProductionCompanyMovies");
            DropForeignKey("dbo.ProductionCompanyMovieMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.ProductionCompanyProductionCompanyMovies", "ProductionCompany_Id", "dbo.ProductionCompanies");
            DropForeignKey("dbo.ProductionCompanyProductionCompanyMovies", "ProductionCompanyMovie_Id", "dbo.ProductionCompanyMovies");
            DropIndex("dbo.ProductionCompanyMovieMovies", new[] { "ProductionCompanyMovie_Id" });
            DropIndex("dbo.ProductionCompanyMovieMovies", new[] { "Movie_Id" });
            DropIndex("dbo.ProductionCompanyProductionCompanyMovies", new[] { "ProductionCompany_Id" });
            DropIndex("dbo.ProductionCompanyProductionCompanyMovies", new[] { "ProductionCompanyMovie_Id" });
            AddColumn("dbo.ProductionCompanyMovies", "Movie_Id", c => c.Int());
            AddColumn("dbo.ProductionCompanyMovies", "ProductionCompany_Id", c => c.Int());
            CreateIndex("dbo.ProductionCompanyMovies", "Movie_Id");
            CreateIndex("dbo.ProductionCompanyMovies", "ProductionCompany_Id");
            AddForeignKey("dbo.ProductionCompanyMovies", "Movie_Id", "dbo.Movies", "Id");
            AddForeignKey("dbo.ProductionCompanyMovies", "ProductionCompany_Id", "dbo.ProductionCompanies", "Id");
            DropTable("dbo.ProductionCompanyMovieMovies");
            DropTable("dbo.ProductionCompanyProductionCompanyMovies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProductionCompanyProductionCompanyMovies",
                c => new
                    {
                        ProductionCompany_Id = c.Int(nullable: false),
                        ProductionCompanyMovie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductionCompany_Id, t.ProductionCompanyMovie_Id });
            
            CreateTable(
                "dbo.ProductionCompanyMovieMovies",
                c => new
                    {
                        ProductionCompanyMovie_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductionCompanyMovie_Id, t.Movie_Id });
            
            DropForeignKey("dbo.ProductionCompanyMovies", "ProductionCompany_Id", "dbo.ProductionCompanies");
            DropForeignKey("dbo.ProductionCompanyMovies", "Movie_Id", "dbo.Movies");
            DropIndex("dbo.ProductionCompanyMovies", new[] { "ProductionCompany_Id" });
            DropIndex("dbo.ProductionCompanyMovies", new[] { "Movie_Id" });
            DropColumn("dbo.ProductionCompanyMovies", "ProductionCompany_Id");
            DropColumn("dbo.ProductionCompanyMovies", "Movie_Id");
            CreateIndex("dbo.ProductionCompanyProductionCompanyMovies", "ProductionCompanyMovie_Id");
            CreateIndex("dbo.ProductionCompanyProductionCompanyMovies", "ProductionCompany_Id");
            CreateIndex("dbo.ProductionCompanyMovieMovies", "Movie_Id");
            CreateIndex("dbo.ProductionCompanyMovieMovies", "ProductionCompanyMovie_Id");
            AddForeignKey("dbo.ProductionCompanyProductionCompanyMovies", "ProductionCompanyMovie_Id", "dbo.ProductionCompanyMovies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductionCompanyProductionCompanyMovies", "ProductionCompany_Id", "dbo.ProductionCompanies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductionCompanyMovieMovies", "Movie_Id", "dbo.Movies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProductionCompanyMovieMovies", "ProductionCompanyMovie_Id", "dbo.ProductionCompanyMovies", "Id", cascadeDelete: true);
        }
    }
}
