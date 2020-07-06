using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using OnlineRecipes.Models;

namespace OnlineRecipes.Controllers
{
    public class RoleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
       

        // GET: Role
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var roles = db.Roles.ToList();
            return View(roles);
        }

      

        // GET: Role/Create
        public ActionResult Create()
        {

            return View();
        }



        // POST: Role/Create
        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {
                    db.Roles.Add(role);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }

            }
            catch (Exception e)
            {
                throw e;
            }

            return View();
        }

     
    }
}
