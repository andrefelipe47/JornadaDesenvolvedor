using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsabilidadesClasse.Utilitarios
{
    internal static class Validacoes
    {
        public static bool ValidarSeNumeroDecimalBrasileiro(string? texto)
        {
            if (string.IsNullOrWhiteSpace(texto)
                || texto.Contains("."))
                return false;

            var isDecimal = decimal.TryParse(texto, out _);

            if (!isDecimal)
                return false;

            return true;
        }

        public static bool ValidarTamanhoTexto(string? texto, short min, short max)
        {
            if (string.IsNullOrWhiteSpace(texto)
                || texto.Trim().Length < min
                || texto.Trim().Length > max)
                return false;

            return true;
        }
    }
}
