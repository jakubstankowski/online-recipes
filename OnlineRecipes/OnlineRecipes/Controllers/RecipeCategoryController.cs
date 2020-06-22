using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineRecipes.Controllers
{
    public class RecipeCategoryController : Controller
    {
        // GET: RecipeCategory
        public ActionResult Index()
        {
            return View();
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
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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
