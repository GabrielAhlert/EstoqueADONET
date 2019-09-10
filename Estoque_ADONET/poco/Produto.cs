using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_ADONET.poco
{
    class Produto
    {
        int id;
        String descricao;
        int estoque;
        double precoCusto;
        double precoVenda;
        Fornecedor fornecedor;

        public Produto(string descricao, int estoque, double precoCusto, double precoVenda, Fornecedor fornecedor)
        {
            this.descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            this.estoque = estoque;
            this.precoCusto = precoCusto;
            this.precoVenda = precoVenda;
            this.fornecedor = fornecedor;
        }

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public int Estoque { get => estoque; set => estoque = value; }
        public double PreçoVenda { get => precoVenda; set => precoVenda = value; }
        public double PrecoCusto { get => precoCusto; set => precoCusto = value; }
        internal Fornecedor Fornecedor { get => fornecedor; set => fornecedor = value; }
    }
}
