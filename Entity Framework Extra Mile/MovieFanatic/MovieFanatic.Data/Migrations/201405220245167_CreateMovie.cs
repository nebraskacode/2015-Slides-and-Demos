namespace MovieFanatic.Data.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class CreateMovie : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);

        }

        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
