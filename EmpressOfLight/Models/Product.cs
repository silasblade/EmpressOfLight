using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpressOfLight.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        public string ProductName { get; set; }

        public string ProductImgPreview { get; set; }

        [Column(TypeName = "text")]
        public string ShortDescription { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public int Quantity { get; set; }

        public float PricePreview { get; set; }

        public Category Category { get; set; }
    }
}
