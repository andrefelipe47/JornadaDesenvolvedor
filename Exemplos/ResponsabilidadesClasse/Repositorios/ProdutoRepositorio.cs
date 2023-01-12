using ResponsabilidadesClasse.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponsabilidadesClasse.Repositorios
{
    internal class ProdutoRepositorio
    {
        private readonly string _caminhoBase = "C:\\Projetos\\DatabasesLocais\\produto.csv";
        private List<Produto> ListagemProdutos = new List<Produto>();
        public ProdutoRepositorio()
        {
            if (!File.Exists(_caminhoBase))
            {
                var file = File.Create(_caminhoBase);
                file.Close();
            }
        }
        public void Inserir(Produto produto)
        {
            var identificador = ProximoIdentificador();

            var sw = new StreamWriter(_caminhoBase);
            sw.WriteLine(GerarLinhaProduto(identificador, produto));
            sw.Close();
        }
        public List<Produto> Listar()
        {
            CarregarProdutos();
            return ListagemProdutos;
        }

        public bool SeExiste(int identificadorProduto)
        {
            CarregarProdutos();
            return ListagemProdutos.Any(x => x.IdentificadorProduto == identificadorProduto);

            //foreach (var x in ListagemProdutos)
            //{
            //    if(x.IdentificadorProduto == identificadorProduto)
            //        return true;
            //}

            //return false;
        }

        public void Atualizar(Produto produto)
        {
            CarregarProdutos();

            var posicao = ListagemProdutos.FindIndex(x => x.IdentificadorProduto == produto.IdentificadorProduto);
            ListagemProdutos[posicao] = produto;
            RegravarProdutos(ListagemProdutos);
        }

        public void Remover(int identificadorProduto)
        {
            var posicao = ListagemProdutos.FindIndex(x => x.IdentificadorProduto == identificadorProduto);


        }

        #region Metodos privados
        private Produto LinhaTextoParaProduto(string linha)
        {
            var colunas = linha.Split(';');

            var produto = new Produto();
            produto.IdentificadorProduto = int.Parse(colunas[0]);
            produto.Nome = colunas[1];
            produto.Valor = decimal.Parse(colunas[2]);
            produto.Situacao = true;

            return produto;
        }
        private void CarregarProdutos()
        {
            ListagemProdutos.Clear();
            var sr = new StreamReader(_caminhoBase);
            while (true)
            {
                var linha = sr.ReadLine();

                if (linha == null)
                    break;

                ListagemProdutos.Add(LinhaTextoParaProduto(linha));
            }

            sr.Close();
        }
        private int ProximoIdentificador()
        {
            CarregarProdutos();

            if (ListagemProdutos.Count == 0)
                return 1;

            return ListagemProdutos.Max(x => x.IdentificadorProduto) + 1;
        }
        private void RegravarProdutos(List<Produto> produtos)
        {
            var sw = new StreamWriter(_caminhoBase);

            foreach (var produto in produtos.OrderBy(x => x.IdentificadorProduto))
            {
                sw.WriteLine(GerarLinhaProduto(produto.IdentificadorProduto, produto));
            }

            sw.Close();
        }
        private string GerarLinhaProduto(int identificador, Produto produto)
        {
            return $"{identificador};{produto.Nome};{produto.Valor};{produto.Situacao}";
        }
        #endregion
    }
}
