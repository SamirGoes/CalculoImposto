using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Repositorios
{
    public interface INotaFiscalRepositorio
    {
        void AdicionarNoraFiscal(NotaFiscal notaFiscal);
    }
}
