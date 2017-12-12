namespace Technoloshe20173CSeriesMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CambioNombreFKGenreID : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Series", "Genre_ID", "dbo.Genres");
            DropIndex("dbo.Series", new[] { "Genre_ID" });
            AddColumn("dbo.Series", "GenreID", c => c.Int(nullable: false));
            DropColumn("dbo.Series", "Genre_ID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Series", "Genre_ID", c => c.Int());
            DropColumn("dbo.Series", "GenreID");
            CreateIndex("dbo.Series", "Genre_ID");
            AddForeignKey("dbo.Series", "Genre_ID", "dbo.Genres", "ID");
        }
    }
}
