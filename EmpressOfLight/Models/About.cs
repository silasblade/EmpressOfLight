using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmpressOfLight.Models
{
    public class About
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AboutId { get; set; }

        public string AboutTitle { get; set; }

        [Column(TypeName = "text")]
        public string AboutSub { get; set; }

        public string AboutTopic { get; set; }

        public string AboutImg { get; set; }

        public string AboutName { get; set; }
    }
}
