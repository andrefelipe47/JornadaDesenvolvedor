using Utilitarios;

namespace Exercicio5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um número decimal.");
            var inputUsuario = Console.ReadLine();

            if (Util.ValidarSeNumeroDecimalBrasileiro(inputUsuario))
                Console.WriteLine("O valor e decimal");
            else
                Console.WriteLine("O valor não e decimal");

            Console.ReadKey();
        }
    }
}