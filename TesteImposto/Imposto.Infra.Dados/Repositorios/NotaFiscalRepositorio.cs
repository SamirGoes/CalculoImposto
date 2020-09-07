using Dapper;
using Imposto.Core.Repositorios;
using Imposto.Infra.Dados.Models;
using Imposto.Infra.Dados.Models.Templates;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Imposto.Infra.Dados.Repositorios
{
    public class NotaFiscalRepositorio : RepositorioBase, INotaFiscalRepositorio
    {
        public void AdicionarNotaFiscal(Core.Domain.NotaFiscal notaFiscal)
        {
            using (var connection = new SqlConnection(this.ConnectionString))
            {
                connection.Open();

                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {

                        NotaFiscalParameters parameters = new NotaFiscalParameters
                        {
                            pId = 0,
                            pNumeroNotaFiscal = notaFiscal.NumeroNotaFiscal,
                            pSerie = notaFiscal.Serie,
                            pNomeCliente = notaFiscal.NomeCliente.NomeCompleto,
                            pEstadoDestino = notaFiscal.EstadoDestino.ToString(),
                            pEstadoOrigem = notaFiscal.EstadoOrigem.ToString()
                        };

                        DynamicParameters parametrosNotaFiscal = new DynamicParameters(parameters);
                        parametrosNotaFiscal.Output(parameters, p => p.pId);

                        var affected = connection.Execute(
                            "[dbo].[P_NOTA_FISCAL]",
                            parametrosNotaFiscal,
                            commandType: CommandType.StoredProcedure,
                                transaction: transaction
                            );

                        int? idNotaGerada = parametrosNotaFiscal.Get<int?>("@pId");

                        foreach (var item in notaFiscal.ItensDaNotaFiscal)
                        {
                            var affectedRowsItens = connection.Execute(
                                "[dbo].[P_NOTA_FISCAL_ITEM]",
                                new
                                {
                                    pId = item.Id,
                                    pIdNotaFiscal = idNotaGerada,
                                    pCfop = item.Cfop.Valor,
                                    pTipoIcms = item.Icms.TipoIcms,
                                    pBaseIcms = item.Icms.BaseIcms,
                                    pAliquotaIcms = item.Icms.AliquotaIcms,
                                    pValorIcms = item.Icms.ValorIcms,
                                    pNomeProduto = item.Produto.NomeProduto,
                                    pCodigoProduto = item.Produto.CodigoProduto,
                                    pBaseIpi = item.Ipi.BaseDeCalculo,
                                    pValorIpi = item.Ipi.Valor
                                },
                                commandType: CommandType.StoredProcedure,
                                transaction: transaction
                                );
                        }

                        transaction.Commit();
                    }
                    catch (Exception e)
                    {
                        transaction.Rollback();
                    }
                }
            }
        }
    }
}
