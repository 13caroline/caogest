using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trial2.Models
{
    public class Parceria
    {
        [Key]
        public int identificacao { get; set; }
        public string nome { get; set; }
        public string url { get; set; }
        public string pathLogo { get; set; }
        //public ICollection<Canil_has_Parceria> parceria { get; set; }
    }
}
