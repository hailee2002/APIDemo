using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDEMO.Data
{
    [Table("User")]
    public class User
    {


        [Required]
        [Key]
        public Guid ID { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Email { get; set; }
        public Int32 Phone { get; set; }
        public int Age { get; set; }
        public Int32 MSSV { get; set; }
        [ForeignKey("MSSV")]
        public School School { get; set; }
    }

        

        
}
