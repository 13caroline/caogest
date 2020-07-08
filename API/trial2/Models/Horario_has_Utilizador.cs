using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trial2.Models
{
    [Table("Horario_has_Utilizador")]
    public class Horario_has_Utilizador
    {
        public DateTime horario_DataInicio { get; set; }
        public DateTime horario_DataFim { get; set; }
        public int horario_Dia { get; set; }
        public string horario_Canil_User_Email { get; set; }
        [ForeignKey("Utilizador")]
        public string utilizador_email { get; set; }
    }
}
