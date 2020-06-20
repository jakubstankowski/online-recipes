using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineRecipes.Models;


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World!");
    }
}

namespace OnlineRecipes.Controllers
{
    public class RecipeController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
       

        // GET: Recipe
        public ActionResult Index()
        {
            var recipes = db.Recipe.ToList();

            return View(recipes);
        }

        // GET: Recipe/Details/5
        public ActionResult Details(int? id)
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

        // GET: Recipe/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Recipe/Create
        [HttpPost]
        public ActionResult Create(Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Recipe.Add(recipe);
                db.SaveChanges();

                return RedirectToAction("Index");
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

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Recipe/Delete/5
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
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipe.Find(id);

            if (recipe == null)
            {
                return HttpNotFound();
            }

            db.Recipe.Remove(recipe);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
