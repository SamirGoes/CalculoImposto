using Imposto.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Service
{
    public class EstadoService
    {
        private readonly Estado estado;

        public EstadoService(Estado estado)
        {
            this.estado = estado;
        }

        public bool EhEstadoSudeste()
        {
            return
                   estado.Equals("SP")
                || estado.Equals("MG")
                || estado.Equals("ES")
                || estado.Equals("RJ");
        }
    }
}
