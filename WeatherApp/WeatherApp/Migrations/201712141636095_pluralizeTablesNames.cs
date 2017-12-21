namespace WeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class pluralizeTablesNames : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.UserCity", newName: "UserCities");
            RenameTable(name: "dbo.User", newName: "Users");
            RenameTable(name: "dbo.Voting", newName: "Votings");
            RenameTable(name: "dbo.WeatherComment", newName: "WeatherComments");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.WeatherComments", newName: "WeatherComment");
            RenameTable(name: "dbo.Votings", newName: "Voting");
            RenameTable(name: "dbo.Users", newName: "User");
            RenameTable(name: "dbo.UserCities", newName: "UserCity");
        }
    }
}
