using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EmpressOfLight.Models
{
    public class Review
    {
        [Key]
        public string ReviewId { get; set; }

        [ForeignKey("IdentityUser")]
        public string Id { get; set; }

        [ForeignKey("Product")]
        public int ProductId { get; set; }
        public string Content { get; set; }

        public int Star = 1;
        public IdentityUser IdentityUser { get; set; }
        public Product Product { get; set; }
    }
}
