using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TesteFe.Models
{
    public class CartaoPessoaJuridica: Cartao
    {
        public int CNPJ { get; set; }
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }
        
    }
}