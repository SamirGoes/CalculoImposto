using Imposto.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Service
{
    public interface IImpostoService<T> where T: IImposto
    {
        T ObterImposto();
    }
}
