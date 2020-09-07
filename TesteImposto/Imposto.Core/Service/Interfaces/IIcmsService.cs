using Imposto.Core.Domain;
using Imposto.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Service
{
    public interface IIcmsService
    {
        Icms CalcularIcms(Pedido pedido, PedidoItem pedidoItem, Cfop cfop);
    }
}
