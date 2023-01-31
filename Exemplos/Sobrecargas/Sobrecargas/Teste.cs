using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sobrecargas
{
    internal class Teste
    {
        public void Multiplicar(decimal valor, int vezesMultiplicar)
        {
            Console.WriteLine("Resultado:" + valor * vezesMultiplicar);
        }

        public void Multiplicar(string valor, int vezesMultiplicar)
        {
            decimal val = Convert.ToDecimal(valor);
            Multiplicar(val, vezesMultiplicar);
        }
       
        public void Multiplicar(int valor, int vezesMultiplicar)
        {
            decimal val = Convert.ToDecimal(valor);
            Multiplicar(val, vezesMultiplicar);
        }
    }
}
