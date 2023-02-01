using CloudMarket.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudMarket.Repositories.Repositorio
{
    public class ProdutoRepositorio : Contexto
    {
        public ProdutoRepositorio(IConfiguration configuration) : base(configuration)
        {
        }

        public void Inserir(Produto model)
        {
            string comandoSql = @"INSERT INTO Produto 
                                    (Nome, Valor, Situacao) 
                                        VALUES
                                    (@Nome, @Valor, @Situacao);";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@Nome", model.Nome);
                cmd.Parameters.AddWithValue("@Valor", model.Valor);
                cmd.Parameters.AddWithValue("@Situacao", model.Situacao);
                cmd.ExecuteNonQuery();
            }
        }
        public void Atualizar(Produto model)
        {
            string comandoSql = @"UPDATE Produto 
                                SET 
                                    Nome = @Nome,
                                    Valor = @Valor, 
                                    Situacao = @Situacao 
                                WHERE IdentificadorProduto = @IdentificadorProduto;";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@IdentificadorProduto", model.IdentificadorProduto);
                cmd.Parameters.AddWithValue("@Nome", model.Nome);
                cmd.Parameters.AddWithValue("@Valor", model.Valor);
                cmd.Parameters.AddWithValue("@Situacao", model.Situacao);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o IdentificadorProduto {model.IdentificadorProduto}");
            }
        }
        public bool SeExiste(int identificadorProduto)
        {
            string comandoSql = @"SELECT COUNT(IdentificadorProduto) as total FROM Produto WHERE IdentificadorProduto = @IdentificadorProduto";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@IdentificadorProduto", identificadorProduto);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }
        public Produto? Obter(int identificadorProduto)
        {
            string comandoSql = @"SELECT IdentificadorProduto, Nome, Valor, Situacao FROM Produto WHERE IdentificadorProduto = @IdentificadorProduto";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@IdentificadorProduto", identificadorProduto);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        var produto = new Produto();
                        produto.IdentificadorProduto = Convert.ToInt32(rdr["IdentificadorProduto"]);
                        produto.Nome = Convert.ToString(rdr["Nome"]);
                        produto.Valor = Convert.ToDecimal(rdr["Valor"]);
                        produto.Situacao = Convert.ToBoolean(rdr["Situacao"]);
                        return produto;
                    }
                    else
                        return null;
                }
            }
        }
        public List<Produto> ListarProdutos(string? nome)
        {
            string comandoSql = @"SELECT IdentificadorProduto, Nome, Valor, Situacao FROM Produto";

            if (!string.IsNullOrWhiteSpace(nome))
                comandoSql += " WHERE Nome LIKE @Nome";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                if (!string.IsNullOrWhiteSpace(nome))
                    cmd.Parameters.AddWithValue("@Nome", "%" + nome + "%");

                using (var rdr = cmd.ExecuteReader())
                {
                    var produtos = new List<Produto>();
                    while (rdr.Read())
                    {
                        var produto = new Produto();
                        produto.IdentificadorProduto = Convert.ToInt32(rdr["IdentificadorProduto"]);
                        produto.Nome = Convert.ToString(rdr["Nome"]);
                        produto.Valor = Convert.ToDecimal(rdr["Valor"]);
                        produto.Situacao = Convert.ToBoolean(rdr["Situacao"]);
                        produtos.Add(produto);
                    }
                    return produtos;
                }
            }
        }
        public void Deletar(int identificadorProduto)
        {
            string comandoSql = @"DELETE FROM Produto 
                                WHERE IdentificadorProduto = @IdentificadorProduto;";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@IdentificadorProduto", identificadorProduto);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o IdentificadorProduto {identificadorProduto}");
            }
        }
    }
}
