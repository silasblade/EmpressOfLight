using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpressOfLight.Models
{
    public class AccountInfo
    {
        [Key]
        [ForeignKey("IdentityUser")]
        public string Id { get; set; }
        public string Name { get; set; }
        public string AvatarUrl { get; set; }

        public IdentityUser IdentityUser { get; set; }


    }
}
