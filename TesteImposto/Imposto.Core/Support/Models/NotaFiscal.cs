using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Support.Models
{
    [Serializable]
    public class NotaFiscalXmlModel
    {
        public int NumeroNotaFiscal { get; set; }
        public int Serie { get; set; }
        public string NomeCliente { get; set; }
        public string EstadoDestino { get; set; }
        public string EstadoOrigem { get; set; }

        public NotaFiscalItemXmlModel[] Itens { get; set; }
    }

    [Serializable]
    public class NotaFiscalItemXmlModel
    {
        public string Cfop { get; set; }
        public decimal Icms { get; set; }
        public string NomeProduto { get; set; }
        public string CodigoProduto { get; set; }
        public decimal Ipi { get; set; }
        public decimal Desconto { get; set; }
    }
}
