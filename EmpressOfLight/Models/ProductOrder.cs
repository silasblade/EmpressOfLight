using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpressOfLight.Models
{
    public class ProductOrder
    {
        [Key]
        public string ProductOrderId { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }

        [ForeignKey("Size")]
        public string SizeId { get; set; }

        public int Quantity { get; set; }

        public float Price { get; set; }

        public Order Order { get; set; }

        public Size Size { get; set; }
    }
}
