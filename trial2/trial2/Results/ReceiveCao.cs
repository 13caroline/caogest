using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trial2.Models;
using Microsoft.AspNetCore.Http;

namespace trial2.Results
{
    public class RecieveCao
    {
        public string nome { get; set; }
        public string sexo { get; set; }
        public string descricao { get; set; }
        public string estado { get; set; }
        public string raca { get; set; }
        public List<string> cor { get; set; }
        public string idade { get; set; }
        public string esterilizacao { get; set; }
        public string porte { get; set; }
        public string canil_user_email { get; set; }
    }
}