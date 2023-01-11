using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LerGravarCSV
{
    internal class Fluxo
    {
        private readonly string _caminhoArquivo = "C:\\Projetos\\Entradas\\exemplo.csv";
        public string? ConsultarLinha(string frase)
        {
            var sr = new StreamReader(_caminhoArquivo);

            while (true)
            {
                var linha = sr.ReadLine();

                if (linha == frase)
                    return linha;

                if (linha == null)
                    break;
            }

            return null;
        }
    }
}
