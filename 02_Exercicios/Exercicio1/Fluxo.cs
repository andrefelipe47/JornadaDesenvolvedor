using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utilitarios;

namespace Exercicio1
{
    internal class Fluxo
    {
        public void Executar()
        {
            ExibirCabecalho();
            var notas = ColetarNotasProvas();
            CalcularExibirMediaNotas(notas);
        }

        private void ExibirCabecalho()
        {
            Console.WriteLine("######################################");
            Console.WriteLine("Sistema para calcular médias de provas");
            Console.WriteLine("######################################");
            Console.WriteLine(Environment.NewLine + Environment.NewLine);
        }
        private List<decimal> ColetarNotasProvas()
        {
            var notas = new List<decimal>();

            while (true)
            {
                Console.WriteLine("Digite uma nota de prova, ou escreva PARE para finalizar o cadastro das notas.");
                var respostaUsuario = Console.ReadLine();
                Console.Clear();

                var seValorCorreto = Util.ValidarSeNumeroDecimalBrasileiro(respostaUsuario);
                if (!seValorCorreto)
                {
                    if (respostaUsuario?.Trim().ToUpper() == "PARE")
                        break;

                    Console.WriteLine("O valor digitado não e válido, por favor tente novamente.");
                    continue;
                }

                var nota = Convert.ToDecimal(respostaUsuario);

                if (nota < 0)
                {
                    Console.WriteLine("O valor da nota não pode ser menor do que zero. Por favor tente novamente.");
                    continue;
                }

                notas.Add(nota);

            }

            return notas;
        }
        
        private void CalcularExibirMediaNotas(List<decimal> notas)
        {
            decimal somaNotas = 0;
            foreach (var nota in notas)
            {
                somaNotas += nota;
                // e a mesma coisa de usar
                //somaNotas = somaNotas + nota;
            }

            if (somaNotas > 0)
                Console.WriteLine("A média da turma foi: " + somaNotas / notas.Count);
            else
                Console.WriteLine("A média da turma foi: " + somaNotas);

            // ao invés de usar o if else
            // poderia usar um OPERADOR TERNARIO (também conhecido como if de uma linha)
            // Console.WriteLine("A média da turma foi: " + (somaNotas > 0 ? somaNotas / notas.Count : somaNotas));

            Console.ReadKey();
        }
    }
}
