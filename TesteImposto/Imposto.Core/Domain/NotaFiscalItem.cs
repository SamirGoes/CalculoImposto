using Imposto.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Domain
{
    public class NotaFiscalItem
    {
        public NotaFiscalItem(int id, int idNotaFiscal, Cfop cfop, Icms icms, Produto produto, Ipi ipi)
        {
            Id = id;
            IdNotaFiscal = idNotaFiscal;
            Cfop = cfop;
            Icms = icms;
            Produto = produto;
            Ipi = ipi;
        }

        public int Id { get; private set; }
        public int IdNotaFiscal { get; private set; }
        public Cfop Cfop { get; private set; }
        public Icms Icms { get; private set; }
        public Produto Produto { get; private set; }
        public Ipi Ipi { get; private set; }
        public decimal Desconto { get; private set; }

        public void AplicarDesconto(decimal valor)
        {
            Desconto = valor;
            Produto.AplicarDesconto(valor);
        }
    }
}
