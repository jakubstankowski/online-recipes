namespace OnlineRecipes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUsertorecipe : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "ApplicationUserId", c => c.String(nullable: false, maxLength: 128));
            CreateIndex("dbo.Recipes", "ApplicationUserId");
            AddForeignKey("dbo.Recipes", "ApplicationUserId", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "ApplicationUserId", "dbo.AspNetUsers");
            DropIndex("dbo.Recipes", new[] { "ApplicationUserId" });
            DropColumn("dbo.Recipes", "ApplicationUserId");
        }
    }
}
