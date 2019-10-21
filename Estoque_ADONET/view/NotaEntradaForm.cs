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
    public partial class NotaEntradaForm : Form
    {
        public NotaEntradaForm()
        {
            InitializeComponent();
            popcombo();
            popTabela();
        }

        private void popcombo()
        {
            comboForn.DataSource = dal.FornecedorDAL.GetAllFornecedores();
            comboNota.DataSource = dal.NotaEntrada.getAllNotas();
            comboProduto.DataSource = dal.ProdutoDAL.getAllProdutos();
            
        }
        private void popTabela()
        {
            try
            {
                tabelaProduto.DataSource = dal.NotaProduto.getProdutos(comboNota.SelectedValue.ToString());
            }catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void TxtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(dal.NotaProduto.save((poco.NotaEntrada)comboNota.SelectedItem,
                (poco.Produto)comboProduto.SelectedItem,Int32.Parse(txtQtdeProduto.Text),
                double.Parse(txtValorProduto.Text)));
            popTabela();
        }

        private void BtnGravar_Click(object sender, EventArgs e)
        {
            try
            {
                
                MessageBox.Show
                (
                    dal.NotaEntrada.save(new poco.NotaEntrada(txtNumeroNota.Text, (poco.Fornecedor)comboForn.SelectedItem, DateTime.Parse(txtDataNota.Text)))       
                );
            }catch(Exception ex)
            {
                MessageBox.Show("Erro!");
            }
            popTabela();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            popcombo();
        }

        private void ComboNota_SelectedIndexChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(comboNota.SelectedValue.ToString());
            popTabela();
        }
    }
}
