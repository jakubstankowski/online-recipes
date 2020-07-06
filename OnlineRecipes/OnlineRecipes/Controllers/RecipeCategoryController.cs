using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineRecipes.Models;

namespace OnlineRecipes.Controllers
{
    public class RecipeCategoryController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RecipeCategory
        [Authorize]
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var recipeCategory = db.RecipeCategories.ToList();
            return View(recipeCategory);
        }

     
        // GET: RecipeCategory/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RecipeCategory/Create
        [HttpPost]
        public ActionResult Create(RecipeCategory recipeCategory)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.RecipeCategories.Add(recipeCategory);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }


            }
            catch
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(recipeCategory);
        }

        // GET: RecipeCategory/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RecipeCategory/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
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


            var recipeCategory = db.RecipeCategories.Find(id);

            if (recipeCategory == null)
            {
                return HttpNotFound();
            }

            return View(recipeCategory);


        }


        // GET: RecipeCategory/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult DeleteConfirmed(int id)
        {
            RecipeCategory recipeCategory = db.RecipeCategories.Find(id);

            if (recipeCategory == null)
            {
                return HttpNotFound();
            }

            db.RecipeCategories.Remove(recipeCategory);
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}