using Imposto.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Factory
{
    public class CfopFactory : IFactory<Cfop>
    {
        public CfopFactory(Estado estadoOrigem, Estado estadoDestino)
        {
            EstadoOrigem = estadoOrigem;
            EstadoDestino = estadoDestino;
        }

        public Estado EstadoOrigem { get; }

        public Estado EstadoDestino { get; }

        public Cfop ObterInstancia()
        {
            ICfopCalculo instancia = null;

            switch (this.EstadoOrigem.ToString())
            {
                case "SP":
                    instancia = new CfopOrigemSP(EstadoDestino);
                    break;
                case "MG":
                    instancia = new CfopOrigemMG(EstadoDestino);
                    break;
                default:
                    break;
            }
            return instancia.Cfop;
        }
    }
}
