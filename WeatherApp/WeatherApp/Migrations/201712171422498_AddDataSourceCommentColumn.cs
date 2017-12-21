namespace WeatherApp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDataSourceCommentColumn : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.WeatherComments", "DataSourceComment", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.WeatherComments", "DataSourceComment");
        }
    }
}
