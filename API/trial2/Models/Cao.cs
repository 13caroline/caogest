using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trial2.Models
{
    public class Cao
    {
        [Key]
        public int idCao { get; set; }
        public string nome { get; set; }
        public string sexo { get; set; }
        public string descricao { get; set; }
        public string estado { get; set; }
        public string raca { get; set; }
        public string cor { get; set; }
        public int idade { get; set; }
        public string esterilizacao { get; set; }
        public string porte { get; set; }

        [ForeignKey("Canil")]
        public string canil_user_email { get; set; }
        public ICollection<Favoritos> favoritos { get; set; }
        public Cao() { }
    }
}
