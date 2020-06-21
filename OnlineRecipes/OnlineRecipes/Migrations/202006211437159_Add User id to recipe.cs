namespace OnlineRecipes.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUseridtorecipe : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Recipes", name: "User_Id", newName: "UserId");
            RenameIndex(table: "dbo.Recipes", name: "IX_User_Id", newName: "IX_UserId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Recipes", name: "IX_UserId", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Recipes", name: "UserId", newName: "User_Id");
        }
    }
}
