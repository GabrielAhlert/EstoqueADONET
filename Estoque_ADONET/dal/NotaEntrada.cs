using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_ADONET.dal
{
    class NotaEntrada
    {
        public static List<poco.NotaEntrada> getAllNotas()
        {
            var a = new List<poco.NotaEntrada>();

            var conn = DBConnection.get();
            var cmd = new NpgsqlCommand("SELECT cod,numero FROM notaentrada", conn);
            conn.Open();
            var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                a.Add(new poco.NotaEntrada(reader.GetInt64(0), reader.GetString(1)));
            }

            return a;
        }

        public static String save(poco.NotaEntrada nota)
        {
            try
            {
                var conn = DBConnection.get();
                var cmd = new NpgsqlCommand(
                    "INSERT INTO notaentrada (numero, dataemissao, cod_fornecedor)" +
                    " VALUES (@a,@b,@c)", conn);
                cmd.Parameters.AddWithValue("a", nota.numero);
                cmd.Parameters.AddWithValue("b", nota.dataEmissao);
                cmd.Parameters.AddWithValue("c", nota.fornecedor.Id);

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
