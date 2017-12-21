namespace WeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.User",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Voting",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        WeatherCommentID = c.Int(nullable: false),
                        Vote = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserID, t.WeatherCommentID })
                .ForeignKey("dbo.User", t => t.UserID, cascadeDelete: true)
                .ForeignKey("dbo.WeatherComment", t => t.WeatherCommentID, cascadeDelete: true)
                .Index(t => t.UserID)
                .Index(t => t.WeatherCommentID);
            
            CreateTable(
                "dbo.WeatherComment",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        DateComment = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Voting", "WeatherCommentID", "dbo.WeatherComment");
            DropForeignKey("dbo.Voting", "UserID", "dbo.User");
            DropIndex("dbo.Voting", new[] { "WeatherCommentID" });
            DropIndex("dbo.Voting", new[] { "UserID" });
            DropTable("dbo.WeatherComment");
            DropTable("dbo.Voting");
            DropTable("dbo.User");
        }
    }
}
