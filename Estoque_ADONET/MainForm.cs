using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque_ADONET
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void FornecedoresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new view.FornecedorForm().Show();
        }

        private void ProdutosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new view.ProdutoForm().Show();
        }

        private void NotaDeEntradaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new view.NotaEntradaForm().Show();
        }
    }
}
