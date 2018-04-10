using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using eCommerceSite.Models;

namespace eCommerceSite.ViewModels
{
    public class BundleViewModel
    {
        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Type")]
        [Required]

        public Models.Type Type { get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        public int AmtSold { get; set; }

        [Display(Name = "Cost")]
        [Required]
        public float? Cost { get; set; }

        [Required]
        [StringLength(255)]
        public string Size { get; set; }

        public float Revenue { get; set; }

        public BundleViewModel()
        {
            Id = 0;
        }

        public BundleViewModel(Bundle bundle)
        {
            Id = bundle.Id;
            Name = bundle.Name;
            Type = bundle.Type;
            NumberInStock = bundle.NumberInStock;
            AmtSold = bundle.AmtSold;
            Cost = bundle.Cost;
            Size = bundle.Size;
            Revenue = bundle.Revenue;
        }
    }
}