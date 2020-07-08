using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trial2.Models
{
    //[Table("User")]
    public class User
    {
        [Key]
        public string email { get; set; }
        public string password { get; set; }
        public int tipo { get; set; }
        public int encriptado { get; set; }
        public User() { }
    }
}
