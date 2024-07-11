using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpressOfLight.Models
{
    public class Size
    {
        [Key]
        public string SizeId { get; set; }
        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string SizeName { get; set; }
        public int Quantity { get; set; }
        public float Price { get; set; }
        public Product Product { get; set; }
    }
}
