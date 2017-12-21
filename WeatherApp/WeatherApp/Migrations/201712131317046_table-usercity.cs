namespace WeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableusercity : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserCity",
                c => new
                    {
                        UserID = c.Int(nullable: false),
                        Location = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserID, t.Location });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UserCity");
        }
    }
}
