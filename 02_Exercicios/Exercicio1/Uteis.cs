using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio1
{
    public static class Uteis
    {
        public static bool ValidarSeNumeroDecimalBrasileiro(string? texto)
        {
            if (string.IsNullOrWhiteSpace(texto))
                return false;

            if (texto.Contains("."))
                return false;

            var isDecimal = decimal.TryParse(texto, out _);

            // ! nega um booleano ou uma condicao que retorna bool
            // colocar antes do isDecimal que bool
            // faz com que o if espere false
            // ou seja, como estou negando o isDecimal true se torna false
            // seria a mesma coisa de if (isDecimal == false)
            if (!isDecimal)
                return false;

            return true;
        }
    }
}
