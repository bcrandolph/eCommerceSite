using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Models
{
    public class Records
    {
        [Required]
        [Key]
        public Guid Id { get; set; }
        public int OrderId { get; set; }
        public int CartId { get; set; }
        public ShoppingCart Cart { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Orders Order { get; set; }
        public decimal Total { get; set; }

    }
}