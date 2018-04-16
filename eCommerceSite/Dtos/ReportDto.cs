using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Dtos
{
    public class ReportDto
    {
        public string TypeName { get; set; }
        public int TypeItems { get; set; }
        public float TypeRevenue { get; set; }
        public float TotalRevenue { get; set; }

    }
}