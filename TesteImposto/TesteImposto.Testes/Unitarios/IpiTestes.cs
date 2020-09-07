using Imposto.Core.Domain;
using Imposto.Core.Service;
using Imposto.Core.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteImposto.Testes
{
    [TestClass]
    public class IpiTestes
    {
        [TestMethod]
        public void DeveRetornarAliquotaZeroQuandoItemPedidoForBrinde()
        {
            IIpiService ipiService = new IpiService();
            var pedidoItem = new PedidoItem("Produto", "1234", 50, true);

            Ipi ipi = ipiService.CalcularIpi(pedidoItem);

            Assert.AreEqual(0, ipi.Aliquota);
        }

        [TestMethod]
        public void DeveRetornarAliquotaDezPorcentoQuandoItemPedidoNaoForBrinde()
        {
            IIpiService ipiService = new IpiService();
            var pedidoItem = new PedidoItem("Produto", "1234", 50, false);
            
            Ipi ipi = ipiService.CalcularIpi(pedidoItem);

            Assert.AreEqual(0.1M, ipi.Aliquota);
        }

        [TestMethod]
        public void DeveRetornarDezPorcentoQuandoAliquotaIgualDez()
        {
            decimal valor = 50;
            decimal valorEsperado = 50 * 0.10M;
            Ipi ipi = new Ipi(valor, 0.10M);

            ipi.Calcular();

            Assert.AreEqual(valorEsperado, ipi.Valor);
        }

        [TestMethod]
        public void DeveRetornarZeroQuandoAliquotaIgualZero()
        {
            decimal valor = 50;
            decimal valorEsperado = 0;
            Ipi ipi = new Ipi(valor, 0);

            ipi.Calcular();

            Assert.AreEqual(valorEsperado, ipi.Valor);
        }
    }
}
