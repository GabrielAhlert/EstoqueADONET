using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_ADONET.dal
{
    class NotaProduto
    {
        public static DataTable getProdutos(String nota)
        {
            try
            {
                var conn = DBConnection.get();
                conn.Open();
                String str = "SELECT n.cod ,descricao,quantidade,preco, a.numero " +
                    "FROM notaentrada_produto n " +
                    "JOIN produto p ON p.cod = n.cod_produto " +
                    "JOIN notaentrada a ON a.cod = n.cod_notaentrada " +
                    "WHERE a.numero LIKE '%@a%'";
                    str = str.Replace("@a", nota);
                Console.WriteLine(str);

                var adapter = new NpgsqlDataAdapter(str, conn);
                var table = new DataTable();
                adapter.Fill(table);

                conn.Close();
                return table;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }
        public static String save(poco.NotaEntrada nota, poco.Produto prod, int quantidade, double preco)
        {
            try
            {
                var conn = DBConnection.get();
                var cmd = new NpgsqlCommand(
                    "INSERT INTO notaentrada_produto (cod_notaentrada, cod_produto, quantidade, preco)" +
                    " VALUES (@a,@b,@c,@d)", conn);
                cmd.Parameters.AddWithValue("a", nota.id);
                cmd.Parameters.AddWithValue("b", prod.Id);
                cmd.Parameters.AddWithValue("c", quantidade);
                cmd.Parameters.AddWithValue("d", preco);

                conn.Open();
                cmd.ExecuteNonQuery();
                return "Adicionado com sucesso!";
            }
            catch (Exception ex)
            {

                return ex.ToString();
            }
        }
    }
}
