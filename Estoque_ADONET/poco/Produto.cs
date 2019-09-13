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
        double precoVenda;


        public Produto(string descricao, int estoque, double precoVenda)
        {
            this.descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            this.estoque = estoque;
            this.precoVenda = precoVenda;
        }

        public Produto(int id, string descricao, int estoque, double precoVenda)
        {
            this.id = id;
            this.descricao = descricao ?? throw new ArgumentNullException(nameof(descricao));
            this.estoque = estoque;
            this.precoVenda = precoVenda;
        }

        public int Id { get => id; set => id = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public int Estoque { get => estoque; set => estoque = value; }
        public double PreçoVenda { get => precoVenda; set => precoVenda = value; }

        public override string ToString()
        {
            return this.descricao;
        }
    }
}
