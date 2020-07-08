using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trial2.Models;

namespace trial2.Results
{
    public class ReturnCanil
    {
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
        public List<Horario> horarios { get; set; }
        public ReturnCanil()
        {
            horarios = new List<Horario>();
        }
    }
}
