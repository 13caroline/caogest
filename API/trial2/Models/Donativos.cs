using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trial2.Models
{
    public class Donativos
    {
        [Key]
        public int id { get; set; }
        [ForeignKey("Utilizador")]
        public string utilizador_user_email { get; set; }
        [ForeignKey("Canil")]
        public string canil_user_email { get; set; }
        public double valor { get; set; }
        public DateTime data { get; set; }
        public string descricao { get; set; }
    }
}
