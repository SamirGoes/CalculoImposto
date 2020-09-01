using Imposto.Core.Repositorios;
using Imposto.Infra.Dados.Context;
using Imposto.Infra.Dados.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Infra.Dados.Repositorios
{
    public class NotaFiscalRepositorio : INotaFiscalRepositorio
    {
        private readonly ImpostoContext contexto;

        public NotaFiscalRepositorio(ImpostoContext contexto)
        {
            this.contexto = contexto;
        }

        public void AdicionarNoraFiscal(Core.Domain.NotaFiscal notaFiscal)
        {
            throw new NotImplementedException();
        }
    }
}
