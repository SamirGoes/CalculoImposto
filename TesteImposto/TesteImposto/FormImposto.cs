using Imposto.Core.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Imposto.Core.Domain;
using Imposto.Infra.CrossCutting.IoC;

namespace TesteImposto
{
    public partial class FormImposto : Form
    {
        private readonly INotaFiscalService _notafiscalService;

        public FormImposto()
        {
            InitializeComponent();
            dataGridViewPedidos.AutoGenerateColumns = true;
            dataGridViewPedidos.DataSource = GetTablePedidos();
            ResizeColumns();

            _notafiscalService = Bootstrapper.GetInstance<INotaFiscalService>();

            cmbEstadoOrigem.Items.AddRange(ListaEstadosOrigem().ToArray());
            cmbEstadoDestino.Items.AddRange(ListaEstadosDestino().ToArray());
        }

        private void ResizeColumns()
        {
            double mediaWidth = dataGridViewPedidos.Width / dataGridViewPedidos.Columns.GetColumnCount(DataGridViewElementStates.Visible);

            for (int i = dataGridViewPedidos.Columns.Count - 1; i >= 0; i--)
            {
                var coluna = dataGridViewPedidos.Columns[i];
                coluna.Width = Convert.ToInt32(mediaWidth);
            }
        }

        private object GetTablePedidos()
        {
            DataTable table = new DataTable("pedidos");
            table.Columns.Add(new DataColumn("Nome do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Codigo do produto", typeof(string)));
            table.Columns.Add(new DataColumn("Valor", typeof(decimal)));
            table.Columns.Add(new DataColumn("Brinde", typeof(bool)));

            return table;
        }

        private void buttonGerarNotaFiscal_Click(object sender, EventArgs e)
        {
            var pedido = new Pedido(textBoxNomeCliente.Text, cmbEstadoOrigem.Text, cmbEstadoDestino.Text);

            if (!pedido.Valido)
            {
                MessageBox.Show(string.Join("\n", pedido.Erros), "Erro");
                return;
            }

            DataTable table = (DataTable)dataGridViewPedidos.DataSource;

            foreach (DataRow row in table.Rows)
            {
                pedido.AdicionarItem(
                    new PedidoItem(
                        brinde: Convert.ToBoolean(row["Brinde"]),
                        codigoProduto: row["Codigo do produto"].ToString(),
                        nomeProduto: row["Nome do produto"].ToString(),
                        valorItemPedido: Convert.ToDecimal(row["Valor"].ToString())
                    ));
            }

            _notafiscalService.GerarNotaFiscal(pedido);
            MessageBox.Show("Operação efetuada com sucesso");
        }

        private IEnumerable<string> ListaEstadosOrigem()
        {
            yield return ("MG");
            yield return ("SP");
        }

        private IEnumerable<string> ListaEstadosDestino()
        {
            yield return ("MG");
            yield return ("PE");
            yield return ("PA");
            yield return ("PB");
            yield return ("PI");
            yield return ("PR");
            yield return ("RJ");
            yield return ("RO");
            yield return ("SE");
            yield return ("TO");
        }
    }
}
