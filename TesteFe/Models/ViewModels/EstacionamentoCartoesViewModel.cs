using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteFe.Models.ViewModels
{
    public class EstacionamentoCartoesViewModel
    {
        public List<CartaoPessoaFisica> CartoesPessoaFisica { get; set; }
        public List<CartaoPessoaJuridica> CartoesPessoaJuridica { get; set; }
        public string Busca { get; set; }
        public CartaoPessoaJuridica CartaoPessoaJuridica { get; set; }
        public CartaoPessoaFisica CartaoPessoaFisica { get; set; }
    }
}
