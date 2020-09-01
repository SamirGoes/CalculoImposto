using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imposto.Core.ValueObjects;
using Imposto.Core.Factory;
using System.ComponentModel;

namespace Imposto.Core.Service
{
    public class NotaFiscalService : INotaFiscalService
    {
        private CfopService _cfopService;
        private IcmsService _icmsService;
        private IpiService _ipiService;

        public NotaFiscalService()
        {
            _cfopService = new CfopService();
            _icmsService = new IcmsService();
            _ipiService = new IpiService();
        }

        public void GerarNotaFiscal(Domain.Pedido pedido)
        {
            NotaFiscal notaFiscal 
                = new NotaFiscal(99999, new Random().Next(Int32.MaxValue), pedido.NomeCliente, pedido.EstadoDestino, pedido.EstadoOrigem);

            Cfop cfop = _cfopService.ObterCfop(pedido);

            foreach (PedidoItem itemPedido in pedido.Itens)
            {
                Icms icms = _icmsService.CalcularIcms(pedido, itemPedido, cfop);

                Ipi ipi = _ipiService.CalcularIpi(itemPedido);

                NotaFiscalItem notaFiscalItem = new NotaFiscalItem(0, notaFiscal.NumeroNotaFiscal, cfop, icms, itemPedido.NomeProduto, itemPedido.CodigoProduto, ipi);

                notaFiscal.AdicionarItem(notaFiscalItem);
            }
        }
    }
}
