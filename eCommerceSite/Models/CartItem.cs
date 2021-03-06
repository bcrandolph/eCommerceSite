﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.Design;
using System.Web.Mvc;

namespace eCommerceSite.Models
{
    public class CartItem
    {
        [Required] 
        [Key]
        public int Cart_Id { get; set; }
        public virtual ShoppingCart Cart { get; set; }
        [Required]
        public int  CartId { get; set; }
        public virtual Bundle Bundle { get; set; }
        [Required]
        public int BundleID { get; set; }

        [Required]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }

        

    }
}