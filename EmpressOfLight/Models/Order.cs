using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpressOfLight.Models
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderId { get; set; }

        [ForeignKey("IdentityUser")]
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Phone { get; set; }

        public string Address { get; set; }

        public float Total { get; set; }

        public string Payment { get; set; }
        public string Note { get; set; }

        //Checking, Confirmed, Delivering, Claimed, Canceled
        public string Status { get; set; }
        public string Email { get; set; }

        public DateTime DateTime { get; set; }

        public IdentityUser IdentityUser { get; set; }
    }
}
