using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.ValueObjects
{
    public class Nome : IEquatable<Nome>, IValidator
    {
        public Nome(string nome)
        {
            NomeCompleto = nome;
            Validar();
        }

        public string NomeCompleto { get; private set; }

        public bool Valido { get; private set; } = true;

        public IEnumerable<string> Erros { get; private set; }

        public bool Equals(Nome other)
            => NomeCompleto == other.NomeCompleto;

        public static implicit operator Nome(string nome)
            => new Nome(nome);

        public void Validar()
        {
            var list = new List<string>();
            if (string.IsNullOrEmpty(NomeCompleto))
            {
                Valido = false;
                list.Add("Nome inválido!");
            }

            Erros = list;
        }
    }
}
