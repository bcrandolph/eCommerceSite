using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace eCommerceSite.Dtos
{
    public class SizeReportDto
    {
        public string SizeName { get; set; }
        public int SizeSold { get; set; }
        public int SizeStock { get; set; }
    }
}