using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trial2.Models;

namespace trial2.Results
{
    public class ReciveUser
    {
        public string email { get; set; }
        public string password { get; set; }
        public int tipo { get; set; }
        public string nome { get; set; }
        public DateTime data_de_nascimento { get; set; }
        public string distrito { get; set; }
        public string rua { get; set; }
        public string localidade { get; set; }
        public string cc { get; set; }
        public string sexo { get; set; }
        public string contacto { get; set; }
        public string nif { get; set;  }
    }
}
