using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TesteFe.Models;

namespace TesteFe.Models
{
    public class EstacionamentoContext : DbContext
    {
        public EstacionamentoContext (DbContextOptions<EstacionamentoContext> options)
            : base(options)
        {
        }

        public DbSet<TesteFe.Models.Estacionamento> Estacionamento { get; set; }

        public DbSet<TesteFe.Models.CartaoPessoaFisica> CartaoPessoaFisica { get; set; }

        public DbSet<TesteFe.Models.CartaoPessoaJuridica> CartaoPessoaJuridica { get; set; }
    }
}
