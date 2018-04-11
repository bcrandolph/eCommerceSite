using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eCommerceSite.Controllers
{
    public class HomeController : Controller
    {
        //[AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        //public ActionResult Gallery()
        //{
        //    ViewBag.Message = "Gallery";

        //    return View();
        //}

        //public ActionResult Cart()
        //{
        //    ViewBag.Message = "Cart";

        //    return View();
        //}

    }
}