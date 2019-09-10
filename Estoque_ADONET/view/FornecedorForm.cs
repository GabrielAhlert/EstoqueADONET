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
    public partial class FornecedorForm : Form
    {   
        
        public FornecedorForm()
        {
            InitializeComponent();
            atualizarGrid();
        }

        private void ClearControls()
        {
            txtNome.Text = String.Empty;
            txtCnpj.Text = String.Empty;
            txtNome.Focus();

        }
        private void atualizarGrid()
        {
            this.tableFornecedores.Columns[0].DataPropertyName = "cod";
            this.tableFornecedores.Columns[1].DataPropertyName = "nome";
            this.tableFornecedores.Columns[2].DataPropertyName = "cnpj";
            this.tableFornecedores.Columns[2].DefaultCellStyle.Format = "99.999.999/9999-99";
            this.tableFornecedores.DataSource = dal.FornecedorDAL.GetAllFornecedores(txtNome.Text);
        
          //  this.tableFornecedores.RefreshEdit();
        }


        private void BtnNovo_Click(object sender, EventArgs e)
        {
            ClearControls();
            
        }

        private void BtnGravar_Click(object sender, EventArgs e)
        {
            if (txtCnpj.MaskFull)
            {
                txtCnpj.TextMaskFormat = MaskFormat.ExcludePromptAndLiterals;
                MessageBox.Show(dal.FornecedorDAL.save(txtNome.Text, txtCnpj.Text));
                txtCnpj.TextMaskFormat = MaskFormat.IncludePromptAndLiterals;
            }

            atualizarGrid();
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            ClearControls();
            this.Close();
        }

        private void TxtNome_TextChanged(object sender, EventArgs e)
        {
            atualizarGrid();
        }

        private void BtnRemover_Click(object sender, EventArgs e)
        {
                MessageBox.Show(dal.FornecedorDAL.remove(int.Parse(txtId.Text)));
            atualizarGrid();
        }

        private void TableFornecedores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            try
            {
                var fornecedor = dal.FornecedorDAL.GetFornecedorById(tableFornecedores.Rows[e.RowIndex].Cells[0].Value.ToString());
                txtId.Text = fornecedor.Id.ToString();
                txtNome.Text = fornecedor.Nome;
                txtCnpj.Text = fornecedor.Cnpj;
            }catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
