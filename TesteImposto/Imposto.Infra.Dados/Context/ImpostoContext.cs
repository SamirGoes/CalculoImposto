using Imposto.Infra.Dados.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Infra.Dados.Context
{
    public class ImpostoContext : DbContext
    {
        public ImpostoContext() : base("DefaultConnection")
        {

        }

        public DbSet<NotaFiscal> NotaFiscal { get; set; }

        public DbSet<NotaFiscalItem> NotaFiscalItem { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            
            base.OnModelCreating(modelBuilder);
        }
    }
}
