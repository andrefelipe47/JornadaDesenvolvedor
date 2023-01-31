using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polimorfismo.Models
{
    internal class Cdb : Investimento
    {
        public override decimal CalcularSaldoFuturo(int quantidadeMeses)
        {
            var saldoFinal = (quantidadeMeses * (Rentabilidade / 100)) + Saldo;
            var juros = saldoFinal - Saldo;
            var jurosImpostoDescontado = juros * 0.80M;
            return Saldo - jurosImpostoDescontado;
        }
    }
}
