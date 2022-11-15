using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiDEMO.Data
{
    [Table("Infor")]
    public class School
    {
        [Key]
        public Int32 MSSV { get; set; }
        public string SchoolName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Major { get; set; }
        public virtual ICollection<User> User { get; set; }
        
    }

}
