namespace Technoloshe20173CSeriesMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Description = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Series",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Summary = c.String(),
                        CreationDate = c.DateTime(nullable: false),
                        Episodes = c.Int(nullable: false),
                        Genre_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Genres", t => t.Genre_ID)
                .Index(t => t.Genre_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Series", "Genre_ID", "dbo.Genres");
            DropIndex("dbo.Series", new[] { "Genre_ID" });
            DropTable("dbo.Series");
            DropTable("dbo.Genres");
        }
    }
}
