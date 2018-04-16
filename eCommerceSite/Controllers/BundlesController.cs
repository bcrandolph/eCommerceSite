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
    public class BundlesController : Controller
    {
        private ApplicationDbContext _context;
        public BundlesController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Gallery
        public ViewResult Index()
        {
            if(User.IsInRole(RoleName.CanManageBundles))
                return View("ProductList");

            return View("ReadOnlyProductList");
        }

        public ActionResult Details(int id)
        {
            var bundle = _context.Bundles.Include(b => b.Type).SingleOrDefault(b => b.Id == id);

            if (bundle == null)
                return HttpNotFound();

            return View(bundle);
        }

        [Authorize(Roles = RoleName.CanManageBundles)]
        public ViewResult New()
        {
            var types = _context.Types.ToList();
            var sizes = _context.Sizes.ToList();

            var viewModel = new BundleViewModel
            {
                Types = types,
                Sizes = sizes
            };

            return View("BundleForm", viewModel);
        }

        [Authorize(Roles = RoleName.CanManageBundles)]
        public ActionResult Edit(int id)
        {
            var bundle = _context.Bundles.Include(b => b.Type).Include(b=> b.Size).SingleOrDefault(b => b.Id == id);

            if (bundle == null)
                return HttpNotFound();

            var viewModel = new BundleViewModel(bundle)
            {
                Types = _context.Types.ToList(),
                Sizes = _context.Sizes.ToList()
            };

            return View("BundleForm", viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageBundles)]
        public ActionResult Save(Bundle bundle)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new BundleViewModel(bundle)
                {
                    Types = _context.Types.ToList()
                };

                return View("BundleForm", viewModel);
            }

            if (bundle.Id == 0)
            {
                _context.Bundles.Add(bundle);
            }
            else
            {
                var bundleInDb = _context.Bundles.Single(m => m.Id == bundle.Id);
                bundleInDb.Name = bundle.Name;
                bundleInDb.TypeId = bundle.TypeId;
                bundleInDb.NumberInStock = bundle.NumberInStock;
                bundleInDb.Size = bundle.Size;
                bundleInDb.Cost = bundle.Cost;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Bundles");
        }
    }
}