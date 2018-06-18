using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TesteFe.Models
{
    public static class DadosInicializacaoDb
    {
        public static void PopularDb(EstacionamentoContext context)
        {
            context.Database.EnsureCreated();

            if (context.Estacionamento.Any())
            {
                //banco já populado
                return;
            }
            var estacionamentos = new Estacionamento[]
            {
               new Estacionamento{ Nome = "Estacionamento Jojo Todinho" },
               new Estacionamento{ Nome = "Estacionamento Jojo Todinho" }
                //Cartoes = new List<Cartao>
                //{
                //    new CartaoPessoaFisica
                //    {
                //        Nome = "Nome",
                //        CPF= 12345678,
                //        DataNascimento = DateTime.Now,
                //        Emails =  new List<string>{"email@email" },
                //        RG = 1234555666,
                //        Sexo = 'm',
                //        Telefone = 2134435245,
                //        Endereco = new Endereco{
                //            Lougradouro = "Lougradouro",
                //            Bairro = "Bairro",
                //            CEP = 212212435,
                //            Cidade = "Cidade",
                //            Complemento ="Complemento",
                //            Estado = "Estado",
                //            Numero = 123323,
                //            Pais = "Pais"
                //        }

                //    }
                //}
            };

            foreach (var item in estacionamentos)
            {
                context.Estacionamento.Add(item);
            }

            context.SaveChanges();

        }
    }
}
