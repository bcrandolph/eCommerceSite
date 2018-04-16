using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using eCommerceSite.Models;
using eCommerceSite.ViewModels;

namespace eCommerceSite.Controllers
{
    public class ReportsController : Controller
    {
        private ApplicationDbContext _context;
        public ReportsController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Reports
        [Authorize(Roles = RoleName.CanViewReports)]
        public ActionResult Index()
        {
            
            return View("Reports");
        }
    }
}