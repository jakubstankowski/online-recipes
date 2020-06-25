namespace OnlineRecipes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addrecipecategorytorecipemodel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "RecipeCategories_Id", c => c.Int());
            CreateIndex("dbo.Recipes", "RecipeCategories_Id");
            AddForeignKey("dbo.Recipes", "RecipeCategories_Id", "dbo.RecipeCategories", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "RecipeCategories_Id", "dbo.RecipeCategories");
            DropIndex("dbo.Recipes", new[] { "RecipeCategories_Id" });
            DropColumn("dbo.Recipes", "RecipeCategories_Id");
        }
    }
}
