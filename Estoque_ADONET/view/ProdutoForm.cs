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
            this.tableProduto.Columns[3].DataPropertyName = "custo";
            this.tableProduto.Columns[4].DataPropertyName = "venda";
            this.tableProduto.Columns[5].DataPropertyName = "nome";
            tableProduto.DataSource = dal.ProdutoDAL.getAllProdutos();
            popCombo();
        }
        private void popCombo()
        {
            comboFornecedor.DataSource = dal.FornecedorDAL.GetAllFornecedores();
        }

        private void BtnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(dal.ProdutoDAL.gravar(new poco.Produto(
                txtDescricao.Text, int.Parse(txtEstoque.Text),
                float.Parse(txtCusto.Text), float.Parse(txtVenda.Text),
                (poco.Fornecedor)comboFornecedor.SelectedItem)));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void BtnNovo_Click(object sender, EventArgs e)
        {
            Console.WriteLine(((poco.Fornecedor)comboFornecedor.SelectedItem).Id);
        }

        private void ProdutoForm_Load(object sender, EventArgs e)
        {

        }
    }
}
