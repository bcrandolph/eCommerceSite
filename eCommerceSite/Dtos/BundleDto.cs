using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace eCommerceSite.Dtos
{
    public class BundleDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public TypeDto Type { get; set; }

        [Required]
        public byte TypeId { get; set; }

        [Range(1,20)]
        public byte NumberInStock { get; set; }

        public int AmtSold { get; set; }

    
        [Required]
        public float Cost { get; set; }

        public SizeDto Size { get; set; }
        [Required]
        public byte SizeId { get; set; }
    }
}