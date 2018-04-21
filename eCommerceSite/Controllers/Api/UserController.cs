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
using Microsoft.AspNet.Identity;

namespace eCommerceSite.Controllers.Api
{
    public class UserController : ApiController
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

        //public IHttpActionResult GetUsers()
        //{
        //    string id = User.Identity.GetUserId();
        //    var user = _context.Users.SingleOrDefault(b => b.Id == id);

        //    if (user == null)
        //        return NotFound();

        //    return Ok(Mapper.Map<User, UserDto>(user));
        //}

        //Get /api/User
        public IHttpActionResult GetUser(string query = null)
        {
                var userQuery = _context.Users
                    .Include(c => c.Cart);

                if (!String.IsNullOrWhiteSpace(query))
                    userQuery = userQuery.Where(c => c.Name.Contains(query));

                var userDto = userQuery
                    .ToList()
                    .Select(Mapper.Map<User, UserDto>);

                return Ok(userDto);
        }

        public IHttpActionResult GetCart(string id)
        {
            var user = _context.Users.SingleOrDefault(c => c.Email == HttpContext.Current.User.Identity.Name);

            if (user == null)
                return NotFound();

            return Ok(Mapper.Map<User, UserDto>(user));
        }

        [System.Web.Mvc.HttpPut]
        public IHttpActionResult UpdateUser(string id, UserDto userDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var currentUserInDb = _context.Users.SingleOrDefault(c => c.Id == id);

            if (currentUserInDb == null)
                return NotFound();

            Mapper.Map(userDto, currentUserInDb);

            _context.SaveChanges();

            return Ok();
        }
    }
}
