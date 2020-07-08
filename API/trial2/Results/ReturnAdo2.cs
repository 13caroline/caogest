using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using trial2.Models;

namespace trial2.Results
{
    public class ReturnAdo2
    {
        public int nPedido { get; set; }
        public DateTime data { get; set; }
        public string estado { get; set; }
        public int cao_idCao { get; set; }
        public string permissao { get; set; }
        public string alergia { get; set; }
        public string descAnimais { get; set; }
        public string ausencia { get; set; }
        public string habitacao { get; set; }
        public string exterior { get; set; }
        public string tipoMoradia { get; set; }
        public string motivo { get; set; }
        public string nome_Canil { get; set; }
        public string comprovativo { get; set; }
        public string donoAnimal { get; set; }
        public string nome_Cao { get; set; }
        public List<Fotografia> fotos { get; set; }
        public ReturnAdo2()
        {
            fotos = new List<Fotografia>();
        }
    }
}
