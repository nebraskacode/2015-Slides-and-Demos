namespace MovieFanatic.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class ConfigureSoftDelete : DbMigration
    {
        public override void Up()
        {
            AlterTableAnnotations(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SoftDeleteColumnName",
                        new AnnotationValues(oldValue: null, newValue: "IsDeleted")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                        Actor_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SoftDeleteColumnName",
                        new AnnotationValues(oldValue: null, newValue: "IsDeleted")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        ApiId = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Overview = c.String(),
                        AverageRating = c.Decimal(precision: 4, scale: 2),
                        HaveWatched = c.Boolean(nullable: false),
                        WatchedOn = c.DateTime(),
                        Review = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SoftDeleteColumnName",
                        new AnnotationValues(oldValue: null, newValue: "IsDeleted")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.MovieGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                        Genre_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SoftDeleteColumnName",
                        new AnnotationValues(oldValue: null, newValue: "IsDeleted")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SoftDeleteColumnName",
                        new AnnotationValues(oldValue: null, newValue: "IsDeleted")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.ProductionCompanyMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                        Movie_Id = c.Int(nullable: false),
                        ProductionCompany_Id = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SoftDeleteColumnName",
                        new AnnotationValues(oldValue: null, newValue: "IsDeleted")
                    },
                });
            
            AlterTableAnnotations(
                "dbo.ProductionCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SoftDeleteColumnName",
                        new AnnotationValues(oldValue: null, newValue: "IsDeleted")
                    },
                });
            
        }
        
        public override void Down()
        {
            AlterTableAnnotations(
                "dbo.ProductionCompanies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SoftDeleteColumnName",
                        new AnnotationValues(oldValue: "IsDeleted", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.ProductionCompanyMovies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                        Movie_Id = c.Int(nullable: false),
                        ProductionCompany_Id = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SoftDeleteColumnName",
                        new AnnotationValues(oldValue: "IsDeleted", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Genres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SoftDeleteColumnName",
                        new AnnotationValues(oldValue: "IsDeleted", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.MovieGenres",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                        Genre_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SoftDeleteColumnName",
                        new AnnotationValues(oldValue: "IsDeleted", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        ApiId = c.Int(nullable: false),
                        ReleaseDate = c.DateTime(nullable: false),
                        Overview = c.String(),
                        AverageRating = c.Decimal(precision: 4, scale: 2),
                        HaveWatched = c.Boolean(nullable: false),
                        WatchedOn = c.DateTime(),
                        Review = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SoftDeleteColumnName",
                        new AnnotationValues(oldValue: "IsDeleted", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Characters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 400),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                        Actor_Id = c.Int(nullable: false),
                        Movie_Id = c.Int(nullable: false),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SoftDeleteColumnName",
                        new AnnotationValues(oldValue: "IsDeleted", newValue: null)
                    },
                });
            
            AlterTableAnnotations(
                "dbo.Actors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                    },
                annotations: new Dictionary<string, AnnotationValues>
                {
                    { 
                        "SoftDeleteColumnName",
                        new AnnotationValues(oldValue: "IsDeleted", newValue: null)
                    },
                });
            
        }
    }
}
