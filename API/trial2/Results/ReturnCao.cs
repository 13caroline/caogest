using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trial2.Models;

namespace trial2.Results
{
    public class ReturnCao
    {
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
        public string email_canil { get; set; }
        public string nome_canil { get; set; }
        public string distrito { get; set; }
        public List<Fotografia> fotos { get; set; }
        public ReturnCao()
        {
            fotos = new List<Fotografia>();
        }
    }
}
