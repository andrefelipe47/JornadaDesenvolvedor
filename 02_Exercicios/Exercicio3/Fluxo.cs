using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercicio3
{
    public class Fluxo
    {
        public void ExecutarFluxo()
        {
            var pessoas = new List<Pessoa>();

            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine("Qual o nome da pessoa?");
                string nomePessoa = Console.ReadLine();

                Console.WriteLine("Qual a idade da pessoa?");
                short idadePessoa = Convert.ToInt16(Console.ReadLine());

                var pessoa = new Pessoa();
                pessoa.Nome = nomePessoa;
                pessoa.Idade = idadePessoa;

                pessoas.Add(pessoa);
            }

            var nomePessoaMaisVelha = "";
            var ultimaIdadeMaisVelho = -1;

            foreach (var pessoa in pessoas)
            {
                Console.WriteLine("Nome: " + pessoa.Nome + " Idade: " + pessoa.Idade);

                if (ultimaIdadeMaisVelho < pessoa.Idade)
                {
                    ultimaIdadeMaisVelho = pessoa.Idade;
                    nomePessoaMaisVelha = pessoa.Nome;
                }
            }

            Console.WriteLine("O mais velho de todos: " + nomePessoaMaisVelha);

            // Para quem tem curiosidade, isso se chama expressão lambda
            // praticamente reduziu 11 linha de codigo a uma apenas
            //var pessoaMaisVelha = pessoas.OrderByDescending(x => x.Idade).First();
            //Console.WriteLine("O mais velho de todos: " + pessoaMaisVelha.Nome);
        }
    }
}
