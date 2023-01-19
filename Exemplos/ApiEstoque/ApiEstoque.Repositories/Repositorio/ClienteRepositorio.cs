using ApiEstoque.Domain.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiEstoque.Repositories.Repositorio
{
    public class ClienteRepositorio : Contexto
    {
        public void Inserir(Cliente model)
        {
            string comandoSql = @"INSERT INTO Cliente 
                                    (CpfCliente, Nome, Nascimento, Telefone) 
                                        VALUES
                                    (@CpfCliente, @Nome, @Nascimento, @Telefone);";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@CpfCliente", model.CpfCliente);
                cmd.Parameters.AddWithValue("@Nome", model.Nome);
                cmd.Parameters.AddWithValue("@Nascimento", model.Nascimento);
                cmd.Parameters.AddWithValue("@Telefone", model.Telefone);
                cmd.ExecuteNonQuery();
            }
        }
        public void Atualizar(Cliente model)
        {
            string comandoSql = @"UPDATE Cliente 
                                SET 
                                    Nome = @Nome,
                                    Nascimento = @Nascimento, 
                                    Telefone = @Telefone 
                                WHERE CpfCliente = @CpfCliente;";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@CpfCliente", model.CpfCliente);
                cmd.Parameters.AddWithValue("@Nome", model.Nome);
                cmd.Parameters.AddWithValue("@Nascimento", model.Nascimento);
                cmd.Parameters.AddWithValue("@Telefone", model.Telefone);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o cpf {model.CpfCliente}");
            }
        }
        public bool SeExiste(string cpfCliente)
        {
            string comandoSql = @"SELECT COUNT(CpfCliente) as total FROM Cliente WHERE CpfCliente = @CpfCliente";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@CpfCliente", cpfCliente);
                return Convert.ToBoolean(cmd.ExecuteScalar());
            }
        }
        public List<Cliente> ListarClientes()
        {
            string comandoSql = @"SELECT CpfCliente, Nome, Nascimento, Telefone FROM Cliente";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                using (var rdr = cmd.ExecuteReader())
                {
                    var clientes = new List<Cliente>();
                    while (rdr.Read())
                    {
                        var cliente = new Cliente();
                        cliente.CpfCliente = Convert.ToString(rdr["CpfCliente"]);
                        cliente.Nome = Convert.ToString(rdr["Nome"]);
                        cliente.Nascimento = Convert.ToDateTime(rdr["Nascimento"]);
                        cliente.Telefone = rdr["Telefone"] == DBNull.Value ? null : Convert.ToString(rdr["Telefone"]);
                        clientes.Add(cliente);
                    }
                    return clientes;
                }
            }
        }
        public void Deletar(string cpfCliente)
        {
            string comandoSql = @"DELETE FROM Cliente 
                                WHERE CpfCliente = @CpfCliente;";

            using (var cmd = new MySqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@CpfCliente", cpfCliente);
                if (cmd.ExecuteNonQuery() == 0)
                    throw new InvalidOperationException($"Nenhum registro afetado para o cpf {cpfCliente}");
            }
        }
    }
}
