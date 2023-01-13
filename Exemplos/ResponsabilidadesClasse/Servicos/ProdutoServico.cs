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
                Console.WriteLine("2 - Cadastrar Produto");
                Console.WriteLine("3 - Atualizar Produto");
                Console.WriteLine("4 - Remover Produto");
                Console.WriteLine("5 - Desativar Produto");
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
                    case "5":
                        Desativar();
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
            if (produto is null)
                return;

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
            var identificador = PerguntarIdentificador("atualizar");
            if (!identificador.HasValue)
                return;

            var produto = ColetarDadosProduto();
            if (produto is null)
                return;

            produto.IdentificadorProduto = identificador.Value;
            _repositorio.Atualizar(produto);
        }
        private void Remover()
        {
            var identificador = PerguntarIdentificador("remover");
            if (!identificador.HasValue)
                return;
            _repositorio.Remover(identificador.Value);
        }
        private void Desativar()
        {
            var identificador = PerguntarIdentificador("desativar");
            if (!identificador.HasValue)
                return;
            _repositorio.Desativar(identificador.Value);
        }
        private Produto? ColetarDadosProduto()
        {
            Console.WriteLine("Qual o nome do produto que você quer cadastrar?");
            var nomeProduto = Console.ReadLine();

            if (!Utilitarios.Validacoes.ValidarTamanhoTexto(nomeProduto, 3, 80))
            {
                Console.WriteLine("O nome do produto deve conter de 3 a 80 caracteres.");
                Console.ReadKey();
                return null;
            }

            Console.WriteLine($"Qual o valor do produto {nomeProduto}?");
            var valorString = Console.ReadLine();

            if (!Utilitarios.Validacoes.ValidarSeNumeroDecimalBrasileiro(valorString))
            {
                Console.WriteLine("O valor deve ser informado no seguinte formato 0,00.");
                Console.ReadKey();
                return null;
            }

            var valor = Convert.ToDecimal(valorString);

            return new Produto()
            {
                Nome = nomeProduto,
                Valor = valor,
                Situacao = true
            };
        }

        private int? PerguntarIdentificador(string nomeAcao)
        {

            Console.WriteLine($"Por favor forneça o identificador do produto para {nomeAcao}?");
            string identificadorInformadoString = Console.ReadLine();

            if (!int.TryParse(identificadorInformadoString, out _))
            {
                Console.WriteLine("O identificador informado não e válido.");
                Console.ReadKey();
                return null;
            }

            var identificadorInformado = Convert.ToInt32(identificadorInformadoString);

            if (!_repositorio.SeExiste(identificadorInformado))
            {
                Console.WriteLine("Este produto não existe... Tente novamente...");
                Console.ReadKey();
                return null;
            }
            else
            {
                return identificadorInformado;
            }
        }
    }
}
