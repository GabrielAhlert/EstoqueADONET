using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_ADONET.poco
{
    class Fornecedor
    {
        int id;
        String nome;
        String cnpj;

        public Fornecedor(int id, string nome, string cnpj)
        {
            this.Id = id;
            this.nome = nome;
            this.cnpj = cnpj;
        }

        public string Nome { get => nome; set => nome = value; }
        public string Cnpj { get => cnpj; set => cnpj = value; }
        public int Id { get => id; set => id = value; }

        public override string ToString()
        {
            return this.nome;
        }
    }
}
