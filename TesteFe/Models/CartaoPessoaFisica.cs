using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteFe.Models
{
    public class CartaoPessoaFisica : Cartao
    {
        public int CPF { get; set; }
        public string Sexo { get; set; }
        [Display(Name = "Data Nascimento")]
        public DateTime DataNascimento { get; set; }
        public int RG { get; set; }
    }
}
