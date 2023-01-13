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

                try
                {
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
                            continue;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.Clear();
                    Console.WriteLine(ex.Message);
                    Console.WriteLine("Pressione uma tecla para continuar!");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Ocorreu um erro fatal no programa, veja a mensagem do erro e contate o administrador: " + ex.Message);
                    Console.WriteLine("Pressione uma tecla para continuar!");
                    Console.ReadKey();
                }
            }
        }

        private void Cadastrar()
        {
            var produto = ColetarDadosProduto();
            _repositorio.Inserir(produto);
            throw new InvalidOperationException($"{produto.Nome} cadastrado com sucesso!");
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
            var produto = ColetarDadosProduto();
            produto.IdentificadorProduto = identificador;
            _repositorio.Atualizar(produto);

            throw new InvalidOperationException($"{produto.Nome} atualizado com sucesso para o identificador {identificador}!");
        }
        private void Remover()
        {
            var identificador = PerguntarIdentificador("remover");
            _repositorio.Remover(identificador);
        }
        private void Desativar()
        {
            var identificador = PerguntarIdentificador("desativar");
            _repositorio.Desativar(identificador);
        }
        private Produto ColetarDadosProduto()
        {
            Console.WriteLine("Qual o nome do produto que você quer cadastrar?");
            var nomeProduto = Console.ReadLine();
            if (!Utilitarios.Validacoes.ValidarTamanhoTexto(nomeProduto, 3, 80))
                throw new InvalidOperationException("O nome do produto deve conter de 3 a 80 caracteres.");

            Console.WriteLine($"Qual o valor do produto {nomeProduto}?");
            var valorString = Console.ReadLine();
            if (!Utilitarios.Validacoes.ValidarSeNumeroDecimalBrasileiro(valorString))
                throw new InvalidOperationException("O valor deve ser informado no seguinte formato 0,00.");

            var valor = Convert.ToDecimal(valorString);

            return new Produto()
            {
                Nome = nomeProduto,
                Valor = valor,
                Situacao = true
            };
        }
        private int PerguntarIdentificador(string nomeAcao)
        {
            Console.WriteLine($"Por favor forneça o identificador do produto para {nomeAcao}?");
            string identificadorInformadoString = Console.ReadLine();
            if (!int.TryParse(identificadorInformadoString, out _))
                throw new InvalidOperationException("O identificador informado não e válido.");

            var identificadorInformado = Convert.ToInt32(identificadorInformadoString);
            if (!_repositorio.SeExiste(identificadorInformado))
                throw new InvalidOperationException("Este produto não existe... Tente novamente...");

            return identificadorInformado;
        }
    }
}
