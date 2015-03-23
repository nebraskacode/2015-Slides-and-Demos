namespace MovieFanatic.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Infrastructure.Annotations;
    using System.Data.Entity.Migrations;
    
    public partial class AddedMovieStatus : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovieStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(nullable: false, maxLength: 50),
                        IsDeleted = c.Boolean(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        AddedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false, maxLength: 50),
                        AddedBy = c.String(nullable: false, maxLength: 50),
                    },
                annotations: new Dictionary<string, object>
                {
                    { "globalFilter_SoftDelete", "EntityFramework.Filters.FilterDefinition" },
                    { "SoftDeleteColumnName", "IsDeleted" },
                })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Movies", "Status_Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Movies", "Status_Id");
            AddForeignKey("dbo.Movies", "Status_Id", "dbo.MovieStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Movies", "Status_Id", "dbo.MovieStatus");
            DropIndex("dbo.Movies", new[] { "Status_Id" });
            DropColumn("dbo.Movies", "Status_Id");
            DropTable("dbo.MovieStatus",
                removedAnnotations: new Dictionary<string, object>
                {
                    { "globalFilter_SoftDelete", "EntityFramework.Filters.FilterDefinition" },
                    { "SoftDeleteColumnName", "IsDeleted" },
                });
        }
    }
}
