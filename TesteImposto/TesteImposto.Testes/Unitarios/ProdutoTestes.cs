using Imposto.Core.Domain;
using Imposto.Core.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace TesteImposto.Testes.Unitarios
{
    [TestClass]
    public class ProdutoTestes
    {
        [TestMethod]
        public void DeveAdicionarDesconto()
        {
            decimal valorProduto = 100;
            decimal valorDesconto = 0.10M;
            decimal valorFinal = valorProduto - valorProduto * valorDesconto;

            var pedido = new Produto("Produto 1", "1", valorProduto);
            pedido.AplicarDesconto(valorDesconto);

            Assert.AreEqual(valorFinal, pedido.Valor);
        }
    }
}
