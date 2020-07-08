using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trial2.Models
{
    public class Voluntarios
    {
        public string canil_user_email { get; set; }
        public string utilizador_user_email { get; set; }
    }
}
