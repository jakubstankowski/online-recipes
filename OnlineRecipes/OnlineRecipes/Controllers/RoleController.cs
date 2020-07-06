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
        private ApplicationUserManager _userManager;

        // GET: Role
        public ActionResult Index()
        {
            var roles = db.Roles.ToList();
            return View(roles);
        }

        // GET: Role/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Role/Create
        public ActionResult Create()
        {

            return View();
        }

        

        // POST: Role/Create
        [HttpPost]
        public  ActionResult Create(IdentityRole role)
        {
            try
            {
                // TODO: Add insert logic here
                if (ModelState.IsValid)
                {

                    /*  var userId = User.Identity.GetUserId();
                      var user = await _userManager.FindByIdAsync(model.userId);


                      ApplicationUser user = db.Users.FirstOrDefault();
  */
                    var user = _userManager.FindById(User.Identity.GetUserId());

                   /* var account = new AccountController();
                    account.UserManager.AddToRoleAsync(user.Id, "Admin");*/

                    _userManager.AddToRole(user.Id, "Admin");

/*
                    db.Roles.Add(role);
                    db.SaveChanges();*/
                    return RedirectToAction("Index");
                }

                }
            catch(Exception e)
            {
                throw e;
            }

            return View();
        }

        // GET: Role/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Role/Edit/5
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

        // GET: Role/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Role/Delete/5
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
