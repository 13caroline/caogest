using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace trial2.Models
{
    public class Documento
    {
        [Key]
        public int identificacao { get; set;}
        public string titulo { get; set;}
        public string texto { get; set;}
        public DateTime date { get; set;}
        public string pathImagem { get; set; }
        public string nota1 { get; set; }
        public string nota2 { get; set; }
        [ForeignKey("User")]
        public string user_email { get; set;}
    }
}
