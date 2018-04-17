using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Models
{
    public class CartItem
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public ShoppingCart Cart { get; set; }
        [Required]
        public Bundle bundle { get; set; }
        [Required]
        public int BundleID { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}