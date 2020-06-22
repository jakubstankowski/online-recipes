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
        public ActionResult Index()
        {
            var recipeCategory = db.RecipeCategories.ToList();
            return View(recipeCategory);
        }

        // GET: RecipeCategory/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
            catch (DataException)
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

        // GET: RecipeCategory/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RecipeCategory/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
