using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_ADONET.dal
{
    class ProdutoDAL
    {
        public static string gravar(poco.Produto prod)
        {
            try
            {
                var conn = DBConnection.get();
                var cmd = new NpgsqlCommand(
                    "INSERT INTO produto (descricao, estoque, custo, venda, cod_fornecedor)" +
                    " VALUES (@a,@b,@c,@d,@e)", conn);
                cmd.Parameters.AddWithValue("a", prod.Descricao);
                cmd.Parameters.AddWithValue("b", prod.Estoque);
                cmd.Parameters.AddWithValue("c", prod.PrecoCusto);
                cmd.Parameters.AddWithValue("d", prod.PreçoVenda);
                cmd.Parameters.AddWithValue("e", prod.Fornecedor.Id);

                conn.Open();
                cmd.ExecuteNonQuery();
                return "Adicionado com sucesso!";
            }
            catch(Exception ex)
            {

                return ex.ToString();
            }
        }
        public static DataTable getAllProdutos()
        {
            var conn = DBConnection.get();
            conn.Open();
            String str = "SELECT p.cod ,descricao,estoque,custo,venda,f.nome " +
                "FROM produto p JOIN fornecedor f ON f.cod = p.cod_fornecedor";

            var adapter = new NpgsqlDataAdapter(str, conn);
            var table = new DataTable();
            adapter.Fill(table);

            conn.Close();
            return table;
        }
    }
}
