using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Imposto.Core.ValueObjects;

namespace Imposto.Core.Domain
{
    public class Pedido : IValidator
    {
        public Estado EstadoDestino { get; }
        public Estado EstadoOrigem { get; }

        public Nome NomeCliente { get; }

        public IList<PedidoItem> _itensDoPedido { get; private set; }

        public IEnumerable<PedidoItem> Itens { get => _itensDoPedido; }

        public bool Valido { get; private set; } = true;

        public IEnumerable<string> Erros { get; private set; }

        public Pedido(Nome nomeCliente, Estado estadoOrigem, Estado estadoDestino)
        {
            EstadoDestino = estadoDestino;
            EstadoOrigem = estadoOrigem;
            NomeCliente = nomeCliente;
            _itensDoPedido = new List<PedidoItem>();

            Validar();
        }

        public void AdicionarItem(PedidoItem item)
        {
            _itensDoPedido.Add(item);
        }

        public bool EhMesmoEstado()
            => EstadoOrigem.Equals(EstadoDestino);

        public void Validar()
        {
            var list = new List<string>();

            if (!EstadoOrigem.Valido)
            {
                Valido = false;
                list.Add("Estado de origem inválido");
            }

            if (!EstadoDestino.Valido)
            {
                Valido = false;
                list.Add("Estado destino inválido");
            }

            if (!NomeCliente.Valido)
            {
                Valido = false;
                list.AddRange(NomeCliente.Erros);
            }

            Erros = list;
        }
    }
}
