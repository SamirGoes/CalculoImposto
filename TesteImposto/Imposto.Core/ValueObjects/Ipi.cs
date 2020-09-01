using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.ValueObjects
{
    public class Ipi : IImposto
    {
        public Ipi(decimal baseDeCalculo, decimal aliquota)
        {
            BaseDeCalculo = baseDeCalculo;
            Aliquota = aliquota;
        }

        public decimal BaseDeCalculo { get; }

        public decimal Aliquota { get; }

        public decimal Valor { get; private set; }

        public decimal Calcular()
        {
            Valor = BaseDeCalculo * Aliquota;
            return Valor;
        }
    }
}
