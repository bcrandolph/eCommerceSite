using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Models
{
    public class Bundle
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public Type Type { get; set; }

        [Display(Name = "Type")]
        [Required]
        public byte TypeId { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1,20)]
        public byte NumberInStock { get; set; }

        public int AmtSold { get; set; }

        [Display(Name = "Cost")]
        [Required]
        public float Cost { get; set; }

        public Size Size { get; set; }

        [Display(Name = "Size")]
        [Required]
        public byte SizeId { get; set; }

    }
}