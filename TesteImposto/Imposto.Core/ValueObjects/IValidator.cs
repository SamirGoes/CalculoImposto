using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.ValueObjects
{
    public interface IValidator
    {
        bool Valido { get; }
        IEnumerable<string> Erros { get; }
        void Validar();
    }
}
