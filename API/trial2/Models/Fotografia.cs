using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trial2.Models
{
    public class Fotografia
    {
        [Key]
        public int idFotografia { get; set; }
        public string path { get; set; }

        [ForeignKey("Cao")]
        public int cao_idCao { get; set; }
    }
}
