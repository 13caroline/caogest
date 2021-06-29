using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trial2.Models
{
    public class Canil_has_Parceria
    {
        public string canil_user_email { get; set; }
        public int parceria_identificacao { get; set; }
    }
}
