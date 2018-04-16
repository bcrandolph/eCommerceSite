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
    public class ReportsController : ApiController
    {
        private ApplicationDbContext _context;

        public ReportsController()
        { 
            _context = new ApplicationDbContext();
        }

        public IHttpActionResult GetReports(string query = null) {
            List<ReportDto> reportDto = new List<ReportDto>();
            var bundleQuery = _context.Bundles
                              .Include(m => m.Size)
                              .Include(m => m.Type);

            ReportDto reportBasic = new ReportDto();
            ReportDto reportElementary = new ReportDto();
            ReportDto reportMiddle = new ReportDto();
            ReportDto reportHigh = new ReportDto();
            ReportDto reportCollege= new ReportDto();

            foreach (var obj in bundleQuery)
            {

                if (obj.TypeId == 1)
                    reportTypeHelper(reportBasic, obj);
                else if(obj.TypeId == 4)
                    reportTypeHelper(reportElementary, obj);
                else if (obj.TypeId == 5)
                    reportTypeHelper(reportMiddle, obj);
                else if (obj.TypeId == 6)
                    reportTypeHelper(reportHigh, obj);
                else if (obj.TypeId == 7)
                    reportTypeHelper(reportCollege, obj);

                reportBasic.TotalRevenue += obj.Cost * obj.AmtSold;
            }


            reportDto.Add(reportBasic);
            reportDto.Add(reportElementary);
            reportDto.Add(reportMiddle);
            reportDto.Add(reportHigh);
            reportDto.Add(reportCollege);

            if (!String.IsNullOrWhiteSpace(query))
                bundleQuery = bundleQuery.Where(m => m.Name.Contains(query));

            return Ok(reportDto);
        }

        public void reportTypeHelper(ReportDto report, Bundle obj)
        {
            report.TypeName = obj.Type.Name;
            report.TypeItems++;
            report.TypeRevenue += obj.Cost*obj.AmtSold;

        }
    }
}
