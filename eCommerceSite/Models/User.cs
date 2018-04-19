using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Models
{
    public class User
    {
        [Required]
        [StringLength(128)]
        public string Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Email { get; set; }


        [StringLength(255)]
        public string Billing { get; set; }
        [StringLength(255)]
        public string Shipping { get; set; }
        [StringLength(255)]
        public string Payment { get; set; }

        [Required]
        public ShoppingCart Cart { get; set; }
        public int CartId { get; set; }

    }
}