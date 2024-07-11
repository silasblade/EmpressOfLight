using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpressOfLight.Models
{
    public class ProductImage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductImageId { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }

        public string ProductImageUrl { get; set; }

        public Product Product { get; set; }
    }
}
