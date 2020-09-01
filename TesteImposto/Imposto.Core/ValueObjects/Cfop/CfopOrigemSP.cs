using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.ValueObjects
{
    public class CfopOrigemSP : ICfopCalculo
    {
        private readonly Estado EstadoDestino;

        public Estado EstadoOrigem { get; }

        public Cfop Cfop { get; private set; }

        public CfopOrigemSP(Estado estadoDestino)
        {
            this.EstadoOrigem = new Estado("SP");
            this.EstadoDestino = estadoDestino;

            ObterCfop();
        }

        public void ObterCfop()
        {
            switch (this.EstadoDestino.ToString())
            {
                case "RJ": Cfop = "6.000"; break;
                case "PE": Cfop = "6.001"; break;
                case "MG": Cfop = "6.002"; break;
                case "PB": Cfop = "6.003"; break;
                case "PR": Cfop = "6.004"; break;
                case "PI": Cfop = "6.005"; break;
                case "RO": Cfop = "6.006"; break;
                case "SE": Cfop = "6.007"; break;
                case "TO": Cfop = "6.008"; break;
                //case "SE": return "6.009";
                case "PA": Cfop = "6.010"; break;
                default: Cfop = "0000"; break;
            }
        }
    }
}
