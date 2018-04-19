using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Validation;

namespace eCommerceSite.Models
{
    public partial class CartHelper
    {

        private ApplicationDbContext _context = new ApplicationDbContext();
        int ShoppingCartId { get; set; }
        public static CartHelper GetCart(User user)
        {
            var cart = new CartHelper();
            cart.ShoppingCartId = user.CartId;
            return cart;
        }
        public void AddToCart(Bundle bundle)
        {
            // Get the matching cart and album instances
            var cartItem = _context.CartItems.SingleOrDefault(
                c => c.CartId == ShoppingCartId
                && c.BundleID == bundle.Id);

            if (cartItem == null)
            {
                // Create a new cart item if no cart item exists
                cartItem = new CartItem
                {
                    BundleID = bundle.Id,
                    CartId = ShoppingCartId,
                    Quantity = 1
                };
                _context.CartItems.Add(cartItem);
            }
            // Save changes
            try
            {
                _context.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                // Retrieve the error messages as a list of strings.
                var errorMessages = ex.EntityValidationErrors
                        .SelectMany(x => x.ValidationErrors)
                        .Select(x => x.ErrorMessage);

                // Join the list to a single string.
                var fullErrorMessage = string.Join("; ", errorMessages);

                // Combine the original exception message with the new one.
                var exceptionMessage = string.Concat(ex.Message, " The validation errors are: ", fullErrorMessage);

                // Throw a new DbEntityValidationException with the improved exception message.
                throw new DbEntityValidationException(exceptionMessage, ex.EntityValidationErrors);
            }

        }
        public int RemoveFromCart(int id)
        {
            // Get the cart
            var cartItem = _context.CartItems.Single(
                cart => cart.CartId == ShoppingCartId);

            int itemCount = 0;

            if (cartItem != null)
            {
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                    itemCount = cartItem.Quantity;
                }
                else
                {
                    _context.CartItems.Remove(cartItem);
                }
                // Save changes
                _context.SaveChanges();
            }
            return itemCount;
        }

        public void NewCart(User user)
        {
            ShoppingCart Cart = new ShoppingCart();
            Cart.CartTotal = 0;
            _context.ShoppingCart.Add(Cart);
            int cartId = _context.ShoppingCart.AsEnumerable().Last().Id;
            var userQuery = _context.Users.SingleOrDefault(u => u.Id == user.Id);

            userQuery.CartId = cartId;

            // Save changes
            _context.SaveChanges();
        }

        public List<CartItem> GetCartItems()
        {
            return _context.CartItems.Where(
                cart => cart.CartId== ShoppingCartId).ToList();
        }

        public int GetCount()
        {
            // Get the count of each item in the cart and sum them up
            int? count = (from cartItems in _context.CartItems
                          where cartItems.CartId == ShoppingCartId
                          select (int?)cartItems.Quantity).Sum();
            // Return 0 if all entries are null
            return count ?? 0;
        }
        public decimal GetTotal()
        {
            // Multiply album price by count of that album to get 
            // the current price for each of those albums in the cart
            // sum all album price totals to get the cart total
            float? total = (from cartItems in _context.CartItems
                              where cartItems.CartId == ShoppingCartId
                              select (int?)cartItems.Quantity *
                              cartItems.Bundle.Cost).Sum();
            decimal? temp = Convert.ToDecimal(total);
            return temp ?? decimal.Zero;
        }
        public Guid CreateOrder(Records record)
        {
            decimal orderTotal = 0;

            var cartItems = GetCartItems();
            // Iterate over the items in the cart, 
            // adding the order details for each
            foreach (var item in cartItems)
            {
                // Set the order total of the shopping cart
                orderTotal += (decimal)(item.Quantity * item.Bundle.Cost);
                record.CartId = item.CartId;
            }
            // Set the order's total to the orderTotal count
            record.Total = orderTotal;

            // Save the order
            _context.SaveChanges();
            // Empty the shopping cart
            var user = _context.Users.SingleOrDefault(u => u.Email == HttpContext.Current.User.Identity.Name);
            NewCart(user);
            // Return the OrderId as the confirmation number
            return record.Id;
        }
    }

}