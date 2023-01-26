using ApiSuperMercado.Domain.Exceptions;
using ApiSuperMercado.Domain.Models;
using ApiSuperMercado.Repositories.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ApiSuperMercado.Services
{
    public class ProdutoService
    {
        private readonly ProdutoRepositorio _repositorio;
        public ProdutoService(ProdutoRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public List<Produto> Listar(string? nome)
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.ListarProdutos(nome);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public Produto Obter(int identificadorProduto)
        {
            try
            {
                _repositorio.AbrirConexao();
                return _repositorio.Obter(identificadorProduto);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Atualizar(Produto model)
        {
            try
            {
                ValidarModelProduto(model);
                _repositorio.AbrirConexao();
                _repositorio.Atualizar(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Deletar(int identificadorProduto)
        {
            try
            {
                _repositorio.AbrirConexao();
                _repositorio.Deletar(identificadorProduto);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        public void Inserir(Produto model)
        {
            try
            {
                ValidarModelProduto(model);
                _repositorio.AbrirConexao();
                _repositorio.Inserir(model);
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }

        private static void ValidarModelProduto(Produto model)
        {
            if (model is null)
                throw new ValidacaoException("O json está mal formatado, ou foi enviado vazio.");

            if (string.IsNullOrWhiteSpace(model.Nome))
                throw new ValidacaoException("O nome e obrigatório.");

            if (model.Nome.Trim().Length < 3 || model.Nome.Trim().Length > 255)
                throw new ValidacaoException("O nome precisa ter entre 3 a 255 caracteres.");

            if (model.Valor <= 0)
                throw new ValidacaoException("O valor do produto deve ser maior que zero.");

            model.Nome = model.Nome.Trim();
        }
    }
}
