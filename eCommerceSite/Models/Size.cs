using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Models
{
    public class Size
    {
        public byte Id{ get; set; }

        [Required]
        [StringLength(255)]
        public string name { get; set; }


    }
}