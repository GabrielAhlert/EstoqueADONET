using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Estoque_ADONET
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //dal.FornecedorDAL.addFornecedor("Gabriel", "04032222061");

            // var a = dal.FornecedorDAL.GetFornecedorById("1");

            //Console.WriteLine(a.Nome);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
            //Application.Run(new view.NotaEntradaForm());
        }
    }
}
