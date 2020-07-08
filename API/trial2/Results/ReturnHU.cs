using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trial2.Results
{
    public class ReturnHU
    {
        public DateTime horario_DataInicio { get; set; }
        public DateTime horario_DataFim { get; set; }
        public int horario_Dia { get; set; }
        public string horario_Canil_User_Email { get; set; }
        public string utilizador_email { get; set; }
        public string nome_canil { get; set; }

        public ReturnHU() { }
    }
}
