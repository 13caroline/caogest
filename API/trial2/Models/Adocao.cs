using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trial2.Models
{
    public class Adocao
    {
        [Key]
        public int nPedido { get; set; }
        public DateTime data { get; set; }
        public string estado { get; set; }
        [ForeignKey("Cao")]
        public int cao_idCao { get; set; }
        public string permissao { get; set; }
        public string alergia { get; set; }
        public string descAnimais { get; set; }
        public string ausencia { get; set; }
        public string habitacao { get; set; }
        public string exterior { get; set; }
        public string tipoMoradia { get; set; }
        public string motivo { get; set; }

        [ForeignKey("Utilizador")]
        public string utilizador_user_email { get; set; }
        public string comprovativo { get; set; }
        public string donoAnimal { get; set; }

    }
}
