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
    public class BundlesController : ApiController
    {
        private ApplicationDbContext _context;

        public BundlesController()
        {
            _context = new ApplicationDbContext();
        }


        public IEnumerable<BundleDto> GetBundles(string query = null)
        {
            var bundleQuery = _context.Bundles
                .Include(m => m.Size)
                .Include(m => m.Type)
                .Where(m => m.NumberInStock > 0);

            if (!String.IsNullOrWhiteSpace(query))
                bundleQuery = bundleQuery.Where(m => m.Name.Contains(query));

            return bundleQuery
                .ToList()
                .Select(Mapper.Map<Bundle, BundleDto>);
        }

        public IHttpActionResult GetBundle(int id)
        {
            var bundle = _context.Bundles.SingleOrDefault(b => b.Id == id);

            if (bundle == null)
                return NotFound();

            return Ok(Mapper.Map<Bundle, BundleDto>(bundle));
        }

        [System.Web.Mvc.HttpPost]
        [System.Web.Mvc.Authorize(Roles = RoleName.CanManageBundles)]
        public IHttpActionResult CreateBundle(BundleDto bundleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var bundle = Mapper.Map<BundleDto, Bundle>(bundleDto);
            _context.Bundles.Add(bundle);
            _context.SaveChanges();

            bundleDto.Id = bundle.Id;
            return Created(new Uri(Request.RequestUri + "/" + bundle.Id), bundleDto);
        }

        [System.Web.Mvc.HttpPut]
        [System.Web.Mvc.Authorize(Roles = RoleName.CanManageBundles)]
        public IHttpActionResult UpdateBundle(int id, BundleDto bundleDto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var bundleInDb = _context.Bundles.SingleOrDefault(c => c.Id == id);

            if (bundleInDb == null)
                return NotFound();

            Mapper.Map(bundleDto, bundleInDb);

            _context.SaveChanges();

            return Ok();
        }

        [System.Web.Mvc.HttpDelete]
        [System.Web.Mvc.Authorize(Roles = RoleName.CanManageBundles)]
        public IHttpActionResult DeleteBundle(int id)
        {
            var bundleInDb = _context.Bundles.SingleOrDefault(c => c.Id == id);

            if (bundleInDb == null)
                return NotFound();

            _context.Bundles.Remove(bundleInDb);
            _context.SaveChanges();

            return Ok();
        }
    }
}
