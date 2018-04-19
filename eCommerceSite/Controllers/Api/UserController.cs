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
    public class UserController : ApiController
    {
        private ApplicationDbContext _context;

        public UserController()
        {
            _context = new ApplicationDbContext();
        }

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
    }
}
