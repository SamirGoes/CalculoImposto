using Imposto.Core.Domain;
using Imposto.Core.Factory;
using Imposto.Core.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Core.Service
{
    public class CfopService
    {
        private IFactory<Cfop> _cfopFactory;

        public Cfop ObterCfop(Pedido pedido)
        {
            _cfopFactory = new CfopFactory(pedido.EstadoOrigem, pedido.EstadoDestino);
            return _cfopFactory.ObterInstancia();
        }
    }
}
