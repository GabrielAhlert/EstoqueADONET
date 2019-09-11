using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque_ADONET.view
{
    public partial class ProdutoForm : Form
    {
        public ProdutoForm()
        {
            InitializeComponent();
            atualizarForm();

        }
        private void atualizarForm()
        {
            this.tableProduto.Columns[0].DataPropertyName = "cod";
            this.tableProduto.Columns[1].DataPropertyName = "descricao";
            this.tableProduto.Columns[2].DataPropertyName = "estoque";
            this.tableProduto.Columns[3].DataPropertyName = "venda";
            tableProduto.DataSource = dal.ProdutoDAL.getAllProdutos();
            //popCombo();
        }


        private void BtnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(dal.ProdutoDAL.gravar(new poco.Produto(
                txtDescricao.Text, int.Parse(txtEstoque.Text),
                float.Parse(txtVenda.Text))));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
            atualizarForm();
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            txtDescricao.Text = string.Empty;
            txtEstoque.Text = string.Empty;
            txtId.Text = string.Empty;
            txtVenda.Text = string.Empty;
        }

        private void ProdutoForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void TableProduto_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            try
            {
                txtId.Text = tableProduto.Rows[e.RowIndex].Cells[0].Value.ToString();
                txtDescricao.Text = tableProduto.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtEstoque.Text = tableProduto.Rows[e.RowIndex].Cells[2].Value.ToString();
                txtVenda.Text = tableProduto.Rows[e.RowIndex].Cells[3].Value.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
            MessageBox.Show( dal.ProdutoDAL.remove(int.Parse(txtId.Text)));
            atualizarForm();

        }
    }
}
