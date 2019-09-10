using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Estoque_ADONET.dal
{
    class FornecedorDAL
    {
        public static String remove(int id)
        {
            String a;
            try
            {
                var conn = DBConnection.get();
                var cmd = new NpgsqlCommand("DELETE FROM fornecedor WHERE cod=@a", conn);
                cmd.Parameters.AddWithValue("a",id);
                conn.Open();
                cmd.ExecuteNonQuery();
                a = "Excluido com sucesso!";

            }catch(NpgsqlException ex)
            {
                a = ex.ToString();
            }
            return a;
            
        }

        public static String save(String nome, String cnpj)
        {
            if (nome.Equals("") || cnpj.Equals(""))
                return "Campo em Branco!";
            string a;
            var conn = DBConnection.get();
            var cmd = new NpgsqlCommand("INSERT INTO fornecedor (nome,cnpj) VALUES (@a,@b)",conn);
            cmd.Parameters.AddWithValue("a", nome);
            cmd.Parameters.AddWithValue("b", cnpj);

            conn.Open();
            try
            {
                cmd.ExecuteNonQuery();
                a = "Adicionado com Sucesso!";
            }
            catch(NpgsqlException ex)
            {
                a = ex.ToString();
            }
            conn.Close();

            return a;

        }

        public static DataTable GetAllFornecedores(String a)
        {
            var conn = DBConnection.get();
            conn.Open();
            String str = "SELECT cod,nome,cnpj FROM fornecedor WHERE nome like '@%'";
            str = str.Replace("@", a);

            var adapter = new NpgsqlDataAdapter(str,conn);
            var table = new DataTable();
            adapter.Fill(table);

            conn.Close();
            return table;
            
        }
        public static List<poco.Fornecedor> GetAllFornecedores()
        {
            var a = new List<poco.Fornecedor>();

            var conn = DBConnection.get();
            var cmd = new NpgsqlCommand("SELECT cod,nome,cnpj FROM fornecedor", conn);
            conn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
                a.Add(new poco.Fornecedor(reader.GetInt32(0), reader.GetString(1)
                    , reader.GetString(2)));
            return a;
        }

        public static poco.Fornecedor GetFornecedorById(String id)
        {
            try
            {
                var conn = DBConnection.get();
                var connStr = "SELECT cod,nome,cnpj FROM fornecedor WHERE cod = @";
                connStr = connStr.Replace("@", id);
                var cmd = new NpgsqlCommand(connStr,conn);
                conn.Open();
                var reader = cmd.ExecuteReader();
                reader.Read();
                var f = new poco.Fornecedor(reader.GetInt32(0),reader.GetString(1), reader.GetString(2));
                conn.Close();
                return f;
            }catch(Exception ex)
            {
                Console.WriteLine(ex+"dasd");
            }
            return null;
        }
    }
}
