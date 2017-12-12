namespace Technoloshe20173CSeriesMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserFavourites : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Mail = c.String(nullable: false, maxLength: 128),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Mail);
            
            CreateTable(
                "dbo.Favourites",
                c => new
                    {
                        UserMail = c.String(nullable: false, maxLength: 128),
                        SerieId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserMail, t.SerieId })
                .ForeignKey("dbo.Users", t => t.UserMail, cascadeDelete: true)
                .ForeignKey("dbo.Series", t => t.SerieId, cascadeDelete: true)
                .Index(t => t.UserMail)
                .Index(t => t.SerieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Favourites", "SerieId", "dbo.Series");
            DropForeignKey("dbo.Favourites", "UserMail", "dbo.Users");
            DropIndex("dbo.Favourites", new[] { "SerieId" });
            DropIndex("dbo.Favourites", new[] { "UserMail" });
            DropTable("dbo.Favourites");
            DropTable("dbo.Users");
        }
    }
}
