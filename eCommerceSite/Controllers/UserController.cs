using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using eCommerceSite.Models;
using eCommerceSite.ViewModels;
using Microsoft.AspNet.Identity;
using System.Web.Http;


namespace eCommerceSite.Controllers
{
    public class UserController : Controller
    {
        private ApplicationDbContext _context;
        //protected UserManager<ApplicationUser> UserManager { get; set; }

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: User
        public ActionResult Details(string id = "")
        {
            var currentUser = User.Identity.GetUserId();
            var user = _context.Users.SingleOrDefault(c => c.Email == System.Web.HttpContext.Current.User.Identity.Name);
            if (user == null)
                return HttpNotFound();

            return View(user);
        }
        
        public ActionResult Edit(string id = "")
        {
            var user = _context.Users.SingleOrDefault(b => b.Id == id);

            if (user == null)
                return HttpNotFound();

            return View("UserInfoUpdateForm");
        }


        [System.Web.Http.HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("UserInfoUpdateForm");
            }

            if (user.Id == "" || user.Id == null)
            {
                _context.Users.Add(user);
            }
            else
            {
                var currentUserInDb = _context.Users.Single(m => m.Id == user.Id);
                currentUserInDb.Name = user.Name;
                currentUserInDb.Billing = user.Billing;
                currentUserInDb.Shipping = user.Shipping;
                currentUserInDb.Payment = user.Payment;
            }

            _context.SaveChanges();

            return RedirectToAction("Details", "User");
        }

    }
}