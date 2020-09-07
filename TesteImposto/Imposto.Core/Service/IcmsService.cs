using Imposto.Core.Domain;
using Imposto.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Service
{
    public class IcmsService : IIcmsService
    {
        public Icms CalcularIcms(Pedido pedido, PedidoItem pedidoItem, Cfop cfop)
        {
            Icms icms = null;

            string tipoIcms = string.Empty;
            decimal baseIcms = 0;
            decimal aliquotaIcms = 0;

            if (pedido.EhMesmoEstado())
            {
                tipoIcms = "60";
                aliquotaIcms = 0.18M;
            }
            else
            {
                tipoIcms = "10";
                aliquotaIcms = 0.17M;
            }

            if (pedidoItem.Brinde)
            {
                tipoIcms = "60";
                aliquotaIcms = 0.18M;
            }

            baseIcms = CalcularBaseIcms(pedidoItem, cfop);
            icms = new Icms(tipoIcms, baseIcms, aliquotaIcms);
            icms.Calcular();

            return icms;
        }

        private decimal CalcularBaseIcms(PedidoItem pedidoItem, Cfop cfop)
        {
            if (cfop.Valor == "6.009")
                return pedidoItem.ValorItemPedido * 0.90M; //redução de base
            else
                return pedidoItem.ValorItemPedido;
        }
    }
}
