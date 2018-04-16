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
    public class SizeReportController : ApiController
    {
        private ApplicationDbContext _context;

        public SizeReportController()
        {
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetSizeReports(string query = null)
        {
            List<SizeReportDto> reportDto = new List<SizeReportDto>();
            var bundleQuery = _context.Bundles
                              .Include(m => m.Size)
                              .Include(m => m.Type);

            SizeReportDto reportSmall = new SizeReportDto();
            SizeReportDto reportMedium = new SizeReportDto();
            SizeReportDto reportLarge = new SizeReportDto();
            foreach (var obj in bundleQuery)
            {
                if (obj.SizeId == 1)
                    reportSizeHelper(reportSmall, obj);
                else if (obj.SizeId == 2)
                    reportSizeHelper(reportMedium, obj);
                else if (obj.SizeId == 3)
                    reportSizeHelper(reportLarge, obj);
            }

            reportDto.Add(reportSmall);
            reportDto.Add(reportMedium);
            reportDto.Add(reportLarge);

            if (!String.IsNullOrWhiteSpace(query))
                bundleQuery = bundleQuery.Where(m => m.Name.Contains(query));

            return Ok(reportDto);
        }
            
        public void reportSizeHelper(SizeReportDto report, Bundle obj)
        {
            report.SizeName = obj.Size.name;
            report.SizeSold += obj.AmtSold;
            report.SizeStock += obj.NumberInStock;
        }
    }
}