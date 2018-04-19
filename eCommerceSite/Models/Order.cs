using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Models
{
    public class Order
    {
        [Required]
        [Key]
        public Guid Id { get; set; }

        [Required]
        public int CartId { get; set; }
        public ShoppingCart Cart { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public string BillingAddress { get; set; }
        public string ShippingAddress { get; set; }
        public float Total { get; set; }

    }
}