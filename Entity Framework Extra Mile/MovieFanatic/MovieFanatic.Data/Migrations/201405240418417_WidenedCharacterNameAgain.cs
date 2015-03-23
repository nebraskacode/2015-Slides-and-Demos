namespace MovieFanatic.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WidenedCharacterNameAgain : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Characters", "Name", c => c.String(nullable: false, maxLength: 250));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Characters", "Name", c => c.String(nullable: false, maxLength: 150));
        }
    }
}
