using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Dtos
{
    public class CartItemsDto
    {
        [Required]
        public int Cart_Id { get; set; }
        [Required]
        public int CartId { get; set; }
        [Required]
        public ShoppingCartDto Cart { get; set; }
        [Required]
        public BundleDto Bundle { get; set; }
        [Required]
        public int BundleID { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }
    }
}