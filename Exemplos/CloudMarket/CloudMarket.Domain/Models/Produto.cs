using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMarket.Domain.Models
{
    public class Produto
    {
        public int IdentificadorProduto { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public bool Situacao { get; set; }
    }
}
