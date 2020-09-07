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
    public class IcmsTestes
    {
        [TestMethod]
        public void DeveRetornarIcmsSessentaAliquitaZeroDezoitoParaEstadoDestinoEOrigemIguais()
        {
            Estado origem = "SP";
            Estado destino = "SP";
            var pedido = new Pedido("Samir", origem, destino);
            var pedidoItem = new PedidoItem("Produto", "123", 120, false);
            Cfop cfop = "6.009";

            IcmsService icmsService = new IcmsService();
            Icms icms = icmsService.CalcularIcms(pedido, pedidoItem, cfop);

            Assert.AreEqual("60", icms.TipoIcms);
            Assert.AreEqual(0.18M, icms.AliquotaIcms);
        }

        [TestMethod]
        public void DeveRetornarIcmsDezAliquitaZeroDezesseteParaEstadoDestinoEOrigemDiferentes()
        {
            Estado origem = "SP";
            Estado destino = "MG";
            var pedido = new Pedido("Samir", origem, destino);
            var pedidoItem = new PedidoItem("Produto", "123", 120, false);
            Cfop cfop = "6.009";

            IcmsService icmsService = new IcmsService();
            Icms icms = icmsService.CalcularIcms(pedido, pedidoItem, cfop);

            Assert.AreEqual("10", icms.TipoIcms);
            Assert.AreEqual(0.17M, icms.AliquotaIcms);
        }

        [TestMethod]
        public void DeveIncluirBaseIcmsMultiplicadoPorZeroNoveValorPedidoQuandoCfopSeisMilENove()
        {
            Estado origem = "SP";
            Estado destino = "MG";
            var pedido = new Pedido("Samir", origem, destino);
            var pedidoItem = new PedidoItem("Produto", "123", 120, false);
            decimal valorEsperado = 120 * 0.90M;
            Cfop cfop = "6.009";

            IcmsService icmsService = new IcmsService();
            Icms icms = icmsService.CalcularIcms(pedido, pedidoItem, cfop);

            Assert.AreEqual(valorEsperado, icms.BaseIcms);
        }
    }
}
