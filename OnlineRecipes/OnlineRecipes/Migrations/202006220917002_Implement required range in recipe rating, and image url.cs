namespace OnlineRecipes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Implementrequiredrangeinreciperatingandimageurl : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "ImageUrl", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Recipes", "ImageUrl");
        }
    }
}
