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
    public class CheckoutController : Controller
    {
        ApplicationDbContext _context = new ApplicationDbContext();

        // GET: Checkout
        public ActionResult AddressAndPayment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddressAndPayment(FormCollection values)
        {
            var order = new Orders();
            var record = new Records();
            TryUpdateModel(order);

            try
            {
                order.Username = User.Identity.Name;
                order.OrderDate = DateTime.Now;

                //Save Order
                _context.Orders.Add(order);
                _context.SaveChanges();
                //Process the order
                var cart = CartHelper.GetCart(_context.Users.SingleOrDefault(u => u.Email == System.Web.HttpContext.Current.User.Identity.Name));
                cart.CreateOrder(record);
                return RedirectToAction("Complete", new { id = order.OrderId });
            }
            catch
            {
                //Invalid - redisplay with errors
                return View(order);
            }
        }
        // GET: /Checkout/Complete
        public ActionResult Complete(int id)
        {
            // Validate customer owns this order
            bool isValid = _context.Orders.Any(
                o => o.OrderId == id &&
                o.Email == User.Identity.Name);

            if (isValid)
            {
                return View(id);
            }
            else
            {
                return View("Error");
            }
        }
    }
}