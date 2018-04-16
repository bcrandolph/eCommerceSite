using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceSite.Models
{
    public class Report
    {
        public string TypeName { get; set; }
        public int TypeItems { get; set; }
        public float TypeRevenue{ get; set; }
        public float TotalRevenue { get; set; }
    }
}