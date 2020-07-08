using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trial2.Models
{
    //[Table("Utilizador")]
    public class Utilizador
    {
        public Utilizador() {}

        [Key]
        public string email { get; set; }
        public string nome { get; set; }
        public DateTime data_de_nascimento { get; set; }
        public string distrito { get; set; }
        public string rua { get; set; }
        public string localidade { get; set; }
        public string cc { get; set; }
        public string sexo { get; set; }
        public string contacto { get; set; }
        public List<Favoritos> favoritos { get; set; }
        public int encriptado { get; set; }
        public string nif { get; set; }
    }


}
