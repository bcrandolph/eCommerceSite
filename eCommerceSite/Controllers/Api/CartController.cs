using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using System.Data.Entity;
using eCommerceSite.Models;
using eCommerceSite.Dtos;
using AutoMapper;

namespace eCommerceSite.Controllers.Api
{
    public class CartController : ApiController
    {
        private ApplicationDbContext _context;

        public CartController()
        {
            _context = new ApplicationDbContext();
        }
        public IEnumerable<CartItemsDto> GetCarts(string query = null)
        {
            var userQuery = _context.Users.SingleOrDefault(u => u.Email == HttpContext.Current.User.Identity.Name);
            var cartQuery = _context.CartItems
                .Include(m => m.Bundle)
                .Include(m => m.Cart)
                .Where(m => m.CartId == userQuery.CartId);

            if (!String.IsNullOrWhiteSpace(query))
                cartQuery = cartQuery.Where(m => m.Bundle.Name.Contains(query));

            return cartQuery
                .ToList()
                .Select(Mapper.Map<CartItem, CartItemsDto>);
        }

        public IHttpActionResult GetCart(int id)
        {
            var cart = _context.CartItems.SingleOrDefault(c => c.Cart_Id == id);

            if (cart == null)
                return NotFound();

            return Ok(Mapper.Map<CartItem, CartItemsDto>(cart));
        }

        [System.Web.Mvc.HttpDelete]
        public IHttpActionResult DeleteFromCart(int id)
        {
            var cartInDb = _context.CartItems.SingleOrDefault(c => c.Cart_Id == id);

            if (cartInDb == null)
                return NotFound();

            if(cartInDb.Quantity > 1)
            {
                cartInDb.Quantity--;
            }
            else
            {
                _context.CartItems.Remove(cartInDb);
            }
            _context.SaveChanges();

            return Ok();
        }
    }
}
