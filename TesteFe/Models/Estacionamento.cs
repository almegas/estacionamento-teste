using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteFe.Models
{
    public class Estacionamento
    {
        public int EstacionamentoID { get; set; }
        public string Nome { get; set; }

        private ICollection<Cartao> cartoes;

        public virtual ICollection<Cartao> Cartoes
        {
            get {
                if (this.cartoes == null)
                {
                    this.cartoes = new List<Cartao>();
                }
                return cartoes; }
            set { cartoes = value; }
        }


    }
}
