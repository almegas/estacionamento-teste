using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteFe.Models
{
    public class Cartao
    {
        [Display(Name = "Número Cartão")]
        public int CartaoID { get; set; }
        public string Nome { get; set; }
        public Endereco Endereco { get; set; }
        public int Telefone { get; set; }
        [Display(Name = "E-mail")]
        public String Email { get; set; }
    }
}
