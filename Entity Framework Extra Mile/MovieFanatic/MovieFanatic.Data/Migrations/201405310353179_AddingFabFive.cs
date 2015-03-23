namespace MovieFanatic.Data.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class AddingFabFive : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Actors", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Actors", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Actors", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Actors", "UpdatedBy", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Actors", "AddedBy", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Characters", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Characters", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Characters", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Characters", "UpdatedBy", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Characters", "AddedBy", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Movies", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Movies", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Movies", "UpdatedBy", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Movies", "AddedBy", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.MovieGenres", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.MovieGenres", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MovieGenres", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.MovieGenres", "UpdatedBy", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.MovieGenres", "AddedBy", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Genres", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.Genres", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Genres", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Genres", "UpdatedBy", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.Genres", "AddedBy", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.ProductionCompanyMovies", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductionCompanyMovies", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductionCompanyMovies", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductionCompanyMovies", "UpdatedBy", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.ProductionCompanyMovies", "AddedBy", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.ProductionCompanies", "IsDeleted", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProductionCompanies", "UpdatedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductionCompanies", "AddedDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProductionCompanies", "UpdatedBy", c => c.String(nullable: false, maxLength: 50));
            AddColumn("dbo.ProductionCompanies", "AddedBy", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProductionCompanies", "AddedBy");
            DropColumn("dbo.ProductionCompanies", "UpdatedBy");
            DropColumn("dbo.ProductionCompanies", "AddedDate");
            DropColumn("dbo.ProductionCompanies", "UpdatedDate");
            DropColumn("dbo.ProductionCompanies", "IsDeleted");
            DropColumn("dbo.ProductionCompanyMovies", "AddedBy");
            DropColumn("dbo.ProductionCompanyMovies", "UpdatedBy");
            DropColumn("dbo.ProductionCompanyMovies", "AddedDate");
            DropColumn("dbo.ProductionCompanyMovies", "UpdatedDate");
            DropColumn("dbo.ProductionCompanyMovies", "IsDeleted");
            DropColumn("dbo.Genres", "AddedBy");
            DropColumn("dbo.Genres", "UpdatedBy");
            DropColumn("dbo.Genres", "AddedDate");
            DropColumn("dbo.Genres", "UpdatedDate");
            DropColumn("dbo.Genres", "IsDeleted");
            DropColumn("dbo.MovieGenres", "AddedBy");
            DropColumn("dbo.MovieGenres", "UpdatedBy");
            DropColumn("dbo.MovieGenres", "AddedDate");
            DropColumn("dbo.MovieGenres", "UpdatedDate");
            DropColumn("dbo.MovieGenres", "IsDeleted");
            DropColumn("dbo.Movies", "AddedBy");
            DropColumn("dbo.Movies", "UpdatedBy");
            DropColumn("dbo.Movies", "AddedDate");
            DropColumn("dbo.Movies", "UpdatedDate");
            DropColumn("dbo.Movies", "IsDeleted");
            DropColumn("dbo.Characters", "AddedBy");
            DropColumn("dbo.Characters", "UpdatedBy");
            DropColumn("dbo.Characters", "AddedDate");
            DropColumn("dbo.Characters", "UpdatedDate");
            DropColumn("dbo.Characters", "IsDeleted");
            DropColumn("dbo.Actors", "AddedBy");
            DropColumn("dbo.Actors", "UpdatedBy");
            DropColumn("dbo.Actors", "AddedDate");
            DropColumn("dbo.Actors", "UpdatedDate");
            DropColumn("dbo.Actors", "IsDeleted");
        }
    }
}
