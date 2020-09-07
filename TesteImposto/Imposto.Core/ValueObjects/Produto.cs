using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.ValueObjects
{
    public class Produto : IEquatable<Produto>, IValidator
    {
        public Produto(string codigoProduto, string nomeProduto, decimal valor)
        {
            CodigoProduto = codigoProduto;
            NomeProduto = nomeProduto;
            Valor = valor;
        }

        public string CodigoProduto { get; private set; }
        public string NomeProduto { get; private set; }
        public decimal Valor { get; private set; }

        public bool Valido { get; private set; } = true;

        public IEnumerable<string> Erros { get; private set; }

        public bool Equals(Produto other)
            => this.CodigoProduto == other.CodigoProduto;

        public void Validar()
        {
            var list = new List<string>();
            if (string.IsNullOrEmpty(CodigoProduto))
            {
                Valido = false;
                list.Add("Código inválido!");
            }

            if (string.IsNullOrEmpty(NomeProduto))
            {
                Valido = false;
                list.Add("Nome inválido!");
            }

            Erros = list;
        }

        public override string ToString()
            => $"{CodigoProduto} - {NomeProduto}";

        public void AplicarDesconto(decimal valor)
        {
            Valor -= Valor * valor;
        }
    }
}
