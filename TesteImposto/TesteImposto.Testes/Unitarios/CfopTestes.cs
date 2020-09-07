using Imposto.Core.Factory;
using Imposto.Core.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TesteImposto.Testes
{
    [TestClass]
    public class CfopTestes
    {
        [DataTestMethod]
        [DataRow("RJ", "6.000")]
        [DataRow("PE", "6.001")]
        [DataRow("MG", "6.002")]
        [DataRow("PB", "6.003")]
        [DataRow("PR", "6.004")]
        [DataRow("PI", "6.005")]
        [DataRow("RO", "6.006")]
        [DataRow("SE", "6.007")]
        [DataRow("TO", "6.008")]
        [DataRow("SE", "6.009")]
        [DataRow("PA", "6.010")]
        public void DeveRetornarCfopCorretoOrigemSP(string estadoDestino, string cfopEsperado)
        {
            Estado origem = "SP";
            Estado destino = estadoDestino; 
            Cfop cfop = cfopEsperado;
            
            var _cfopFactory = new CfopFactory(origem, destino);
            Cfop cfopFabricado = _cfopFactory.ObterInstancia();

            Assert.IsTrue(cfopFabricado.Equals(cfop));
        }

        [DataTestMethod]
        [DataRow("RJ", "6.000")]
        [DataRow("PE", "6.001")]
        [DataRow("MG", "6.002")]
        [DataRow("PB", "6.003")]
        [DataRow("PR", "6.004")]
        [DataRow("PI", "6.005")]
        [DataRow("RO", "6.006")]
        [DataRow("SE", "6.007")]
        [DataRow("TO", "6.008")]
        [DataRow("SE", "6.009")]
        [DataRow("PA", "6.010")]
        public void DeveRetornarCfopCorretoOrigemMG(string estadoDestino, string cfopEsperado)
        {
            Estado origem = "MG";
            Estado destino = estadoDestino;
            Cfop cfop = cfopEsperado;

            var _cfopFactory = new CfopFactory(origem, destino);
            Cfop cfopFabricado = _cfopFactory.ObterInstancia();

            Assert.IsTrue(cfopFabricado.Equals(cfop));
        }
    }
}
