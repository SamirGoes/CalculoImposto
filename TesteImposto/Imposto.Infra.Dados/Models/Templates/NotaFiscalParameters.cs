using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Infra.Dados.Models.Templates
{
    class NotaFiscalParameters
    {
        public int pId { get; set; }
        public int pNumeroNotaFiscal { get; set; }
        public int pSerie { get; set; }
        public string pNomeCliente { get; set; }
        public string pEstadoDestino { get; set; }
        public string pEstadoOrigem { get; set; }
    }
}
