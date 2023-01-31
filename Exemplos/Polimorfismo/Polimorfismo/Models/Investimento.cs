using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfismo.Models
{
    internal class Investimento: Conta
    {
        public decimal Rentabilidade { get; set; }

        public virtual decimal CalcularSaldoFuturo(int quantidadeMeses)
        {
            return (quantidadeMeses * (Rentabilidade / 100)) + Saldo;
        }
    }
}
