using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Estoque_ADONET.poco
{
    class NotaEntrada
    {
        public long? id { get; set; }
        public string numero { get; set; }
        public Fornecedor fornecedor { get; set; }
        public DateTime dataEmissao { get; set; }
        public DateTime dataEntrada { get; set; }

        public NotaEntrada()
        {
            this.id = null;
        }

        public NotaEntrada(long? id, string numero)
        {
            this.id = id;
            this.numero = numero ?? throw new ArgumentNullException(nameof(numero));
        }

        public NotaEntrada(string numero, Fornecedor fornecedor, DateTime dataEmissao)
        {
            this.numero = numero ?? throw new ArgumentNullException(nameof(numero));
            this.fornecedor = fornecedor ?? throw new ArgumentNullException(nameof(fornecedor));
            this.dataEmissao = dataEmissao;
        }

        public override string ToString()
        {
            return this.numero;
        }
    }

    
}
