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
        public IEnumerable<Models.Type> Types { get; set; }
        public IEnumerable<Size> Sizes { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        [Display(Name = "Type")]
        [Required]
        public int? TypeId{ get; set; }

        [Display(Name = "Number in Stock")]
        [Range(1, 20)]
        public byte? NumberInStock { get; set; }

        public int AmtSold { get; set; }

        [Required]
        public float? Cost { get; set; }

        [Display(Name = "Size")]
        [StringLength(255)]
        public byte? SizeId { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Bundle" : "New Bundle";
            }
        }

        public BundleViewModel()
        {
            Id = 0;
        }

        public BundleViewModel(Bundle bundle)
        {
            Id = bundle.Id;
            Name = bundle.Name;
            TypeId = bundle.TypeId;
            SizeId = bundle.SizeId;
            NumberInStock = bundle.NumberInStock;
            AmtSold = bundle.AmtSold;
            Cost = bundle.Cost;
        }
    }
}