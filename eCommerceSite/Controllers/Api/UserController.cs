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

        public IHttpActionResult GetUserInfo(string id)
        {
            var user = _context.Users.SingleOrDefault(u => u.Id == id);

            if (user == null)
                return NotFound();

            return Ok(Mapper.Map<User, UserDto>(user));
        }
        ////Get /api/User
        //public IEnumerable<UserDto> GetUser(string id)
        //{

        //    //var userQuery = _context.Users;



        //    //return bundleQuery
        //    //    .ToList()
        //    //    .Select(Mapper.Map<Bundle, BundleDto>);
        //}
    }
}
