using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.ValueObjects
{
    public class Cfop
    {
        public Cfop(string valor)
        {
            Valor = valor;
        }

        public string Valor { get; }

        public static implicit operator Cfop(string value) => new Cfop(value);
    }
}
