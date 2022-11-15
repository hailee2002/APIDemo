using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDEMO.Models
{
    public class SchoolModel
    {
        public string SchoolName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Major { get; set; }
    }
}
