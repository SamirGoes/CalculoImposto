using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.ValueObjects
{
    public class Icms : IImposto
    {
        public Icms(string tipoIcms, decimal baseIcms, decimal aliquotaIcms)
        {
            TipoIcms = tipoIcms;
            BaseIcms = baseIcms;
            AliquotaIcms = aliquotaIcms;
        }

        public string TipoIcms { get; }
        public decimal BaseIcms { get; }
        public decimal AliquotaIcms { get; }
        public decimal ValorIcms { get; private set; }

        public decimal Calcular()
        {
            this.ValorIcms = this.BaseIcms * this.AliquotaIcms;

            return this.ValorIcms;
        }
    }
}
