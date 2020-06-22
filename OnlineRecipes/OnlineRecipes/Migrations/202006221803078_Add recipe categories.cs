namespace OnlineRecipes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addrecipecategories : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RecipeCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RecipeCategories");
        }
    }
}
