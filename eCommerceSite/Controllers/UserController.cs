using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using eCommerceSite.Models;
using eCommerceSite.ViewModels;
using Microsoft.AspNet.Identity;

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

        // GET: User
        public ActionResult Details(String id = "")
        {
            var currentUser = User.Identity.GetUserId();
            var user = _context.Users.SingleOrDefault(c => c.Id == currentUser.ToString());

            if (user == null)
                return HttpNotFound();

            return View("Details");
        }
        
        public ActionResult Edit(string id = "")
        {
            id = User.Identity.GetUserId().ToString();
            var user = _context.Users.SingleOrDefault(b => b.Id == id);

            if (user == null)
                return HttpNotFound();

            return View("UserInfoUpdateForm");
        }


        [HttpPost]
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