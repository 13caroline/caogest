using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trial2.Models
{
    public class Horario
    {
        public Horario() { }
        public DateTime dataInicio { get; set; }
        public DateTime dataFim { get; set; }
        public int capacidade { get; set; }
        public int registados { get; set;  }
        public int dia { get; set; }
        public string canil_user_email { get; set; }

    }
}
