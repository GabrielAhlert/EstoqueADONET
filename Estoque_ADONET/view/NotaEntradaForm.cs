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
        }

        private void popcombo()
        {
            comboForn.DataSource = dal.FornecedorDAL.GetAllFornecedores();
            comboNota.DataSource = dal.NotaEntrada.getAllNotas();
            comboProduto.DataSource = dal.ProdutoDAL.getAllProdutos();
        }

        private void TxtNome_TextChanged(object sender, EventArgs e)
        {

        }

        private void Button3_Click(object sender, EventArgs e)
        {

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
        }
    }
}
