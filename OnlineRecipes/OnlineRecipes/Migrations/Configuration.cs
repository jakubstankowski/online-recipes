namespace OnlineRecipes.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using OnlineRecipes.Models;
    using Microsoft.AspNet.Identity;


    internal sealed class Configuration : DbMigrationsConfiguration<OnlineRecipes.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(OnlineRecipes.Models.ApplicationDbContext context)
        {

          /*  Recipe recipe = new Recipe("sandwich", "easy", 5, "f52e4f7c-b5b9-48bd-b0ec-2b88fd9fef31");
            context.Recipe.AddOrUpdate(recipe);
*/

           // students.ForEach(s => context.Students.AddOrUpdate(p => p.LastName, s));


            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
