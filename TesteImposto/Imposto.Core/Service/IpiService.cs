using Imposto.Core.Domain;
using Imposto.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Service
{
    public class IpiService
    {
        public Ipi CalcularIpi(PedidoItem itemPedido)
        {
            Ipi _ipi = null;
            decimal baseDeCalculo = itemPedido.ValorItemPedido;
            decimal aliquota = 10;

            if (itemPedido.Brinde)
                aliquota = 0;

            _ipi = new Ipi(baseDeCalculo, aliquota);
            _ipi.Calcular();

            return _ipi;
        }
    }
}
