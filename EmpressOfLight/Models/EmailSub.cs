using System.ComponentModel.DataAnnotations;

namespace EmpressOfLight.Models
{
    public class EmailSub
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
