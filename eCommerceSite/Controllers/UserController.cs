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
                return Content(currentUser.ToString());//HttpNotFound();

            return View(user);
        }

    }
}