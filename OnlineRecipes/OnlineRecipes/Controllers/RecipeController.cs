using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using OnlineRecipes.Models;



namespace OnlineRecipes.Controllers
{
    public class RecipeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
       

        // GET: Recipe
        public ActionResult Index()
        {
           /* var states = GetAllStates();
            
            var model = new Recipe();
            model.RecipeCategories = GetSelectListItems(states);*/
            
            var recipes = db.Recipe.ToList();


            return View(recipes);
        }


        private IEnumerable<string> GetAllStates()
        {
            return new List<string>
            {
                "ACT",
                "New South Wales",
                "Northern Territories",
                "Queensland",
                "South Australia",
                "Victoria",
                "Western Australia",
            };
        }

        private IEnumerable<SelectListItem> GetSelectListItems(IEnumerable<string> elements)
        {
            // Create an empty list to hold result of the operation
            var selectList = new List<SelectListItem>();

            // For each string in the 'elements' variable, create a new SelectListItem object
            // that has both its Value and Text properties set to a particular value.
            // This will result in MVC rendering each item as:
            //     <option value="State Name">State Name</option>
            foreach (var element in elements)
            {
                selectList.Add(new SelectListItem
                {
                    Value = element,
                    Text = element
                });
                Console.WriteLine("selector list", selectList);

            }


            return selectList;
        }


        [Authorize]
        public ActionResult UserRecipe()
        {
            var userId = User.Identity.GetUserId();
            var recipe = db.Recipe.Where(c => c.UserId == userId).ToList();
            return View(recipe);


        }

        // GET: Recipe/Details/5
        public ActionResult Details(int? id)
        {
            /*var states = GetAllStates();

            var model = new Recipe();
            model.RecipeCategories = GetSelectListItems(states);*/



            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            var recipe = db.Recipe.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }

            return View(recipe);

        }

        // GET: Recipe/Create
        public ActionResult Create()
        {
            var recipe = new Recipe();
            recipe.RecipeCategories = db.RecipeCategories.ToList();
           
            return View(recipe);
        }

        // POST: Recipe/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(Recipe recipe)
        {

           
       
            try
            {
                if (ModelState.IsValid)
                {
                    recipe.UserId = User.Identity.GetUserId();
                    db.Recipe.Add(recipe);
                    db.SaveChanges();

                    return RedirectToAction("UserRecipe");
                }
            } catch(Exception e)
            {
                throw e;
            }
            

            return View(recipe);

        }

        // GET: Recipe/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }


            var recipe = db.Recipe.Find(id);

            if (recipe == null)
            {
                return HttpNotFound();
            }

            return View(recipe);
        }

        // POST: Recipe/Edit/5
        [HttpPost]
        [Authorize]
        public ActionResult Edit(int? id, Recipe recipe)
        {
            try
            {
                var recipeToUpdate = db.Recipe.Find(id);

                if (recipeToUpdate == null)
                {
                    return HttpNotFound();
                }

                if (!ModelState.IsValid)
                {
                    return View("Edit", recipe);
                }


                TryUpdateModel(recipeToUpdate);
                db.SaveChanges();

                return RedirectToAction("UserRecipe");

            }
            catch
            {
                return View();
            }
        }

        // GET: Recipe/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }


            var recipe = db.Recipe.Find(id);

            if (recipe == null)
            {
                return HttpNotFound();
            }

            return View(recipe);


        }



        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipe.Find(id);

            if (recipe == null)
            {
                return HttpNotFound();
            }

            db.Recipe.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("UserRecipe");

        }
    }
}
