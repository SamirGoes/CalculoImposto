using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using Imposto.Core.Factory;
using Imposto.Core.ValueObjects;

namespace Imposto.Core.Domain
{
    public class NotaFiscal
    {
        public int Id { get; private set; }
        public int NumeroNotaFiscal { get; private set; }
        public int Serie { get; private set; }
        public Nome NomeCliente { get; private set; }

        public Estado EstadoDestino { get; private set; }
        public Estado EstadoOrigem { get; private set; }

        public IEnumerable<NotaFiscalItem> ItensDaNotaFiscal { get => _itensDaNotaFiscal; }

        private IList<NotaFiscalItem> _itensDaNotaFiscal;

        public NotaFiscal()
        {
            _itensDaNotaFiscal = new List<NotaFiscalItem>();
        }

        public NotaFiscal(int numeroNotaFiscal, int serie, Nome nomeCliente, Estado estadoDestino, Estado estadoOrigem)
        {
            //Id = id;
            NumeroNotaFiscal = numeroNotaFiscal;
            Serie = serie;
            NomeCliente = nomeCliente;
            EstadoDestino = estadoDestino;
            EstadoOrigem = estadoOrigem;
            _itensDaNotaFiscal = new List<NotaFiscalItem>();
        }

        public void AdicionarItem(NotaFiscalItem item)
        {
            _itensDaNotaFiscal.Add(item);
        }
    }
}
