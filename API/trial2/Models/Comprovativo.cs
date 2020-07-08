using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trial2.Models
{
    public class Comprovativo
    {
        [Key]
        public int idComprovativo { get; set; }
        public string path { get; set; }
        public int adocao_NPedido { get; set; }
    }
}
