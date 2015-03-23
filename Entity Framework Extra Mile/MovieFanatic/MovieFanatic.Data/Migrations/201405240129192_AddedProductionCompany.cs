namespace MovieFanatic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedProductionCompany : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProductionCompanyMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductionCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProductionCompanyMovieMovies",
                c => new
                    {
                        ProductionCompanyMovie_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductionCompanyMovie_Id, t.Movie_Id })
                .ForeignKey("dbo.ProductionCompanyMovies", t => t.ProductionCompanyMovie_Id, cascadeDelete: true)
                .ForeignKey("dbo.Movies", t => t.Movie_Id, cascadeDelete: true)
                .Index(t => t.ProductionCompanyMovie_Id)
                .Index(t => t.Movie_Id);
            
            CreateTable(
                "dbo.ProductionCompanyProductionCompanyMovies",
                c => new
                    {
                        ProductionCompany_Id = c.Int(nullable: false),
                        ProductionCompanyMovie_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ProductionCompany_Id, t.ProductionCompanyMovie_Id })
                .ForeignKey("dbo.ProductionCompanies", t => t.ProductionCompany_Id, cascadeDelete: true)
                .ForeignKey("dbo.ProductionCompanyMovies", t => t.ProductionCompanyMovie_Id, cascadeDelete: true)
                .Index(t => t.ProductionCompany_Id)
                .Index(t => t.ProductionCompanyMovie_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProductionCompanyProductionCompanyMovies", "ProductionCompanyMovie_Id", "dbo.ProductionCompanyMovies");
            DropForeignKey("dbo.ProductionCompanyProductionCompanyMovies", "ProductionCompany_Id", "dbo.ProductionCompanies");
            DropForeignKey("dbo.ProductionCompanyMovieMovies", "Movie_Id", "dbo.Movies");
            DropForeignKey("dbo.ProductionCompanyMovieMovies", "ProductionCompanyMovie_Id", "dbo.ProductionCompanyMovies");
            DropIndex("dbo.ProductionCompanyProductionCompanyMovies", new[] { "ProductionCompanyMovie_Id" });
            DropIndex("dbo.ProductionCompanyProductionCompanyMovies", new[] { "ProductionCompany_Id" });
            DropIndex("dbo.ProductionCompanyMovieMovies", new[] { "Movie_Id" });
            DropIndex("dbo.ProductionCompanyMovieMovies", new[] { "ProductionCompanyMovie_Id" });
            DropTable("dbo.ProductionCompanyProductionCompanyMovies");
            DropTable("dbo.ProductionCompanyMovieMovies");
            DropTable("dbo.ProductionCompanies");
            DropTable("dbo.ProductionCompanyMovies");
        }
    }
}
