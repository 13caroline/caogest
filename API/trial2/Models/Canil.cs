using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trial2.Models
{
    //[Table("Canil")]
    public class Canil
    {
        public Canil() {}

        [Key]
        public string email { get; set; }
        public string nib { get; set; }
        public string nome { get; set; }
        public int capacidadeOcupada { get; set; }
        public int capacidadeTotal { get; set; }
        public string distrito { get; set; }
        public string rua { get; set; }
        public string localidade { get; set; }
        public string contacto { get; set; }
        public string estado { get; set; }
        public int encriptado { get; set; }
        //public ICollection<Canil_has_Parceria> parceria { get; set; }
    }
}
