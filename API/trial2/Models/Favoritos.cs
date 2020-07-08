using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trial2.Models
{
    public class Favoritos
    {
        public Utilizador utilizador { get; set; }
        public string utilizador_user_email { get; set; }
        public Cao cao { get; set; }
        public int cao_idCa { get; set; }
    }
}
