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

    public class CartController : Controller
    {
        private ApplicationDbContext _context;
        public CartController()
        {
            _context = new ApplicationDbContext();
        }
        // GET: Cart
        public ActionResult Index()
        {
            
            var cart = CartHelper.GetCart(_context.Users.SingleOrDefault(u=> u.Email == System.Web.HttpContext.Current.User.Identity.Name));

            // Set up our ViewModel
            var viewModel = new ShoppingCartViewModel
            {
                CartItems = cart.GetCartItems(),
                CartTotal = cart.GetTotal()
            };
            // Return the view
            return View(viewModel);
        }

        // GET: /Store/AddToCart/5
        public ActionResult AddToCart(int id)
        {
            // Retrieve the album from the database
            var addedBundle = _context.Bundles
                .Single(bundle => bundle.Id == id);
            // Add it to the shopping cart
            var cart = CartHelper.GetCart(_context.Users.SingleOrDefault(u => u.Email == System.Web.HttpContext.Current.User.Identity.Name));

            cart.AddToCart(addedBundle);

            // Go back to the main store page for more shopping
            return RedirectToAction("Index");
        }

        // AJAX: /Cart/RemoveFromCart/5
        [HttpPost]
        public ActionResult RemoveFromCart(int id)
        {
            // Remove the item from the cart
            var cart = CartHelper.GetCart(_context.Users.SingleOrDefault(u => u.Email == System.Web.HttpContext.Current.User.Identity.Name));

            // Get the name of the album to display confirmation
            string albumName = _context.CartItems
                .Single(item => item.BundleID == id).Bundle.Name;

            // Remove from cart
            int itemCount = cart.RemoveFromCart(id);

            // Display the confirmation message
            var results = new ShoppingCartRemoveViewModel
            {
                Message = Server.HtmlEncode(albumName) +
                    " has been removed from your shopping cart.",
                CartTotal = cart.GetTotal(),
                CartCount = cart.GetCount(),
                BundleCount = itemCount,
                DeleteId = id
            };
            return Json(results);
        }
        // GET: /Cart/CartSummary
        [ChildActionOnly]
        public ActionResult CartSummary()
        {
            var cart = CartHelper.GetCart(_context.Users.SingleOrDefault(u => u.Email == System.Web.HttpContext.Current.User.Identity.Name));

            ViewData["CartCount"] = cart.GetCount();
            return PartialView("CartSummary");
        }
    }
}