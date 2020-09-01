using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Domain
{
    public class PedidoItem
    {
        public PedidoItem(string nomeProduto, string codigoProduto, decimal valorItemPedido, bool brinde)
        {
            NomeProduto = nomeProduto;
            CodigoProduto = codigoProduto;
            ValorItemPedido = valorItemPedido;
            Brinde = brinde;
        }

        public string NomeProduto { get; }
        public string CodigoProduto { get; }        
        public decimal ValorItemPedido { get; }
        public bool Brinde { get; }
    }
}
