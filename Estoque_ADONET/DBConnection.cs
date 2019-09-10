using System;
using Npgsql;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_ADONET
{
    class DBConnection
    {
        static String connString = "Host=127.0.0.1;Username=postgres;Password=postgres;Database=EstoqueDB";

        public static NpgsqlConnection get()
        {
            return new NpgsqlConnection(connString);
        }

    }
}
