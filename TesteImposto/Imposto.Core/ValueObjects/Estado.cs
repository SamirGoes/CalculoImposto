using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.ValueObjects
{
    public class Estado : IEquatable<Estado>, IValidator
    {
        public Estado(string nomeEstado)
        {
            NomeEstado = nomeEstado;
            Validar();
        }

        public string NomeEstado { get; private set; }

        public bool Valido { get; private set; } = true;

        public IEnumerable<string> Erros { get; private set; }

        public bool Equals(Estado other)
            => NomeEstado == other.NomeEstado;

        public override string ToString()
            => NomeEstado;

        public void Validar()
        {
            var list = new List<string>();
            if (string.IsNullOrEmpty(this.NomeEstado))
                list.Add("Estado inválido");

            Erros = list;
        }

        public static implicit operator Estado (string nomeEstado)
            => new Estado(nomeEstado);
    }
}
