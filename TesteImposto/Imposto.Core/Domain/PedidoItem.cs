using Imposto.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Domain
{
    public class PedidoItem : IValidator
    {
        public PedidoItem(string nomeProduto, string codigoProduto, decimal valorItemPedido, bool brinde)
        {
            NomeProduto = nomeProduto;
            CodigoProduto = codigoProduto;
            ValorItemPedido = valorItemPedido;
            Brinde = brinde;

            Validar();
        }

        public string NomeProduto { get; }
        public string CodigoProduto { get; }        
        public decimal ValorItemPedido { get; }
        public bool Brinde { get; }

        public bool Valido { get; private set; } = true;

        public IEnumerable<string> Erros { get; private set; }

        public void Validar()
        {
            var list = new List<string>();
            if (string.IsNullOrEmpty(NomeProduto))
            {
                Valido = false;
                list.Add("Nome inválido!");
            }
            
            if (string.IsNullOrEmpty(CodigoProduto))
            {
                Valido = false;
                list.Add("Código inválido!");
            }

            if (ValorItemPedido < 0)
            {
                Valido = false;
                list.Add("Valor inválido!");
            }

            Erros = list;
        }
    }
}
