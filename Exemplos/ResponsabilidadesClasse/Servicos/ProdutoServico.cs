using ResponsabilidadesClasse.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsabilidadesClasse.Servicos
{
    internal class ProdutoServico
    {
        private readonly Repositorios.ProdutoRepositorio _repositorio;
        public ProdutoServico()
        {
            _repositorio = new Repositorios.ProdutoRepositorio();
        }

        public void Perguntar()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("O que você deseja fazer?");
                Console.WriteLine("1 - Listar Produtos");
                Console.WriteLine("2 - Cadastrar Produtos");
                Console.WriteLine("3 - Atualizar Produtos");
                Console.WriteLine("4 - Remover Produtos");
                var resposta = Console.ReadLine();
                Console.Clear();

                switch (resposta)
                {
                    case "1":
                        Listar();
                        break;
                    case "2":
                        Cadastrar();
                        break;
                    case "3":
                        Atualizar();
                        break;
                    case "4":
                        Remover();
                        break;
                    default:
                        Console.WriteLine("Selecione uma opção válida");
                        break;
                }
            }
        }

        private void Cadastrar()
        {
            var produto = ColetarDadosProduto();
            _repositorio.Inserir(produto);

            Console.WriteLine($"{produto.Nome} cadastrado com sucesso!");
            Console.WriteLine($"Aperte uma tecla para prosseguir!");
            Console.ReadKey();
        }
        private void Listar()
        {
            var produtos = _repositorio.Listar();

            Console.WriteLine("Deseja também listar produtos inativos? S/N");
            if (Console.ReadLine() == "N")
                produtos = produtos.Where(x => x.Situacao == true).ToList();

            Console.Clear();

            foreach (var p in produtos)
            {
                Console.WriteLine($"Identificador => {p.IdentificadorProduto};Nome => {p.Nome};Valor => {p.Valor};{(p.Situacao ? "Ativo" : "Inativo")}");
            }

            Console.WriteLine("Para sair da listagem aperte uma tecla!");
            Console.ReadKey();

            //produtos.ForEach(p => Console.WriteLine($"Identificador => {p.IdentificadorProduto};Nome => {p.Nome};Valor => {p.Valor};{(p.Situacao ? "Ativo" : "Inativo")}"));
        }
        private void Atualizar()
        {
            Console.WriteLine("Por favor forneça o identificador do produto para atualizar?");
            int identificadorInformado = Convert.ToInt32(Console.ReadLine());
            if (!_repositorio.SeExiste(identificadorInformado))
            {
                Console.WriteLine("Este identificador não existe... Tente novamente...");
                return;
            }

            var produto = ColetarDadosProduto();
            produto.IdentificadorProduto = identificadorInformado;

            _repositorio.Atualizar(produto);
        }
        private void Remover()
        {
            Console.WriteLine("Por favor forneça o identificador do produto para remover?");
            int identificadorInformado = Convert.ToInt32(Console.ReadLine());
            if (!_repositorio.SeExiste(identificadorInformado))
            {
                Console.WriteLine("Este identificador não existe... Tente novamente...");
                return;
            }

            _repositorio.Remover(identificadorInformado);
        }

        private Produto ColetarDadosProduto()
        {
            Console.WriteLine("Qual o nome do produto que você quer cadastrar?");
            var nomeProduto = Console.ReadLine();

            Console.WriteLine($"Qual o valor do produto {nomeProduto}?");
            var valor = Convert.ToDecimal(Console.ReadLine());

            return new Produto()
            {
                Nome = nomeProduto,
                Valor = valor,
                Situacao = true
            };
        }
    }
}
