using Imposto.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imposto.Core.ValueObjects;
using Imposto.Core.Factory;
using System.ComponentModel;
using Imposto.Core.Support;
using Imposto.Core.Repositorios;
using System.Configuration;
using Imposto.Core.Support.Models;
using System.Xml.Serialization;
using System.IO;

namespace Imposto.Core.Service
{
    public class NotaFiscalService : INotaFiscalService
    {
        private readonly ICfopService _cfopService;
        private readonly IIcmsService _icmsService;
        private readonly IIpiService _ipiService;
        private readonly INotaFiscalRepositorio _notaFiscalRepositorio;

        private string DiretorioNota => ConfigurationManager.AppSettings["XmlDiretorio"];

        public NotaFiscalService(
            ICfopService cfopService,
            IIcmsService icmsService,
            IIpiService ipiService,
            INotaFiscalRepositorio notaFiscalRepositorio)
        {
            this._cfopService = cfopService;
            this._icmsService = icmsService;
            this._ipiService = ipiService;
            this._notaFiscalRepositorio = notaFiscalRepositorio;
        }

        public bool GerarNotaFiscal(Domain.Pedido pedido)
        {
            NotaFiscal notaFiscal
                = new NotaFiscal(new Random().Next(99999), 1, pedido.NomeCliente, pedido.EstadoDestino, pedido.EstadoOrigem);

            Cfop cfop = _cfopService.ObterCfop(pedido);
            
            if (string.IsNullOrEmpty(cfop.Valor)) return false;
            
            foreach (PedidoItem itemPedido in pedido.Itens)
            {
                Produto produto = new Produto(itemPedido.NomeProduto, itemPedido.CodigoProduto, itemPedido.ValorItemPedido);
                Icms icms = _icmsService.CalcularIcms(pedido, itemPedido, cfop);
                Ipi ipi = _ipiService.CalcularIpi(itemPedido);
                EstadoService estado = new EstadoService(pedido.EstadoDestino);

                NotaFiscalItem notaFiscalItem = new NotaFiscalItem(0, notaFiscal.NumeroNotaFiscal, cfop, icms, produto, ipi);

                if (estado.EhEstadoSudeste())
                    notaFiscalItem.AplicarDesconto(0.10M);

                notaFiscal.AdicionarItem(notaFiscalItem);
            }

            bool notaFiscalCriada = CriarXml(notaFiscal);

            if (notaFiscalCriada)
                this._notaFiscalRepositorio.AdicionarNotaFiscal(notaFiscal);

            return notaFiscalCriada;
        }

        private bool CriarXml(NotaFiscal notaFiscal)
        {
            var notaXml = new NotaFiscalXmlModel
            {
                NumeroNotaFiscal = notaFiscal.NumeroNotaFiscal,
                Serie = notaFiscal.Serie,
                NomeCliente = notaFiscal.NomeCliente.NomeCompleto,
                EstadoDestino = notaFiscal.EstadoDestino.ToString(),
                EstadoOrigem = notaFiscal.EstadoOrigem.ToString(),
                Itens = notaFiscal.ItensDaNotaFiscal
                    .Select(i =>
                        new NotaFiscalItemXmlModel
                        {
                            Cfop = i.Cfop.Valor,
                            Icms = i.Icms.ValorIcms,
                            NomeProduto = i.Produto.NomeProduto,
                            CodigoProduto = i.Produto.CodigoProduto,
                            Ipi = i.Ipi.Valor,
                            Desconto = i.Desconto
                        }).ToArray()
            };

            try
            {
                var serializer = new XmlSerializer(typeof(NotaFiscalXmlModel));

                string path = Path.Combine(DiretorioNota, $"{ notaFiscal.NumeroNotaFiscal }.xml");

                using (var writer = new StreamWriter(path))
                {
                    serializer.Serialize(writer, notaXml);
                }

                return File.Exists(path);
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
