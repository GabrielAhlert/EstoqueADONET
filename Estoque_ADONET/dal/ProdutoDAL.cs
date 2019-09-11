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
        public static String remove(int id)
        {
            String a;
            try
            {
                var conn = DBConnection.get();
                var cmd = new NpgsqlCommand("DELETE FROM produto WHERE cod=@a", conn);
                cmd.Parameters.AddWithValue("a", id);
                conn.Open();
                cmd.ExecuteNonQuery();
                a = "Excluido com sucesso!";

            }
            catch (NpgsqlException ex)
            {
                a = ex.ToString();
            }
            return a;

        }
        public static string gravar(poco.Produto prod)
        {
            try
            {
                var conn = DBConnection.get();
                var cmd = new NpgsqlCommand(
                    "INSERT INTO produto (descricao, estoque, venda)" +
                    " VALUES (@a,@b,@c)", conn);
                cmd.Parameters.AddWithValue("a", prod.Descricao);
                cmd.Parameters.AddWithValue("b", prod.Estoque);
                cmd.Parameters.AddWithValue("c", prod.PreçoVenda);

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
            try
            {
                var conn = DBConnection.get();
                conn.Open();
                String str = "SELECT cod ,descricao,estoque,venda FROM produto";

                var adapter = new NpgsqlDataAdapter(str, conn);
                var table = new DataTable();
                adapter.Fill(table);

                conn.Close();
                return table;
            }catch(Exception ex)
            {
                return null;
            }
        }
    }
}
