using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpressOfLight.Models
{
    public class Cart
    {
        [Key]
        public string CartId { get; set; }

        [ForeignKey("IdentityUser")]
        public string Id { get; set; }

        [ForeignKey("Size")]
        public string SizeId { get; set; }
        public int Quantity { get; set; }
        public Size Size { get; set; }
        public IdentityUser IdentityUser {  get; set; }
    }
}
