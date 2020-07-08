using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trial2.Results
{
    public class ReturnDonativos
    {
        public int id { get; set; }
        public string utilizador_user_email { get; set; }
        public string canil_user_email { get; set; }
        public double valor { get; set; }
        public DateTime data { get; set; }
        public string descricao { get; set; }
        public string nome_canil { get; set; }
        public string contacto_canil { get; set; }
        public string rua_canil { get; set; }
        public string localidade_canil { get; set; }
    }
}
