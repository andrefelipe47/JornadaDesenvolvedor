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
    public class UsuarioRepositorio : Contexto
    {
        public UsuarioRepositorio(IConfiguration configuration) : base(configuration)
        {
        }
     
        public Usuario? ObterUsuarioPorCredenciais(string email, string senha)
        {
            string comandoSql = @"SELECT u.Email, u.Nome, u.IdentificadorCargo FROM Usuario u
                                    JOIN Cargo c ON u.IdentificadorCargo = c.IdentificadorCargo
                                    WHERE u.Email = @email AND u.Senha = @senha";

            using (var cmd = new SqlCommand(comandoSql, _conn))
            {
                cmd.Parameters.AddWithValue("@email", email);
                cmd.Parameters.AddWithValue("@senha", senha);

                using (var rdr = cmd.ExecuteReader())
                {
                    if (rdr.Read())
                    {
                        return new Usuario()
                        {
                            Nome = rdr["Nome"].ToString(),
                            Email = rdr["Email"].ToString(),
                            CargoUsuario = (EnumCargoUsuario)Convert.ToInt32(rdr["IdentificadorCargo"])
                        };
                    }
                    else
                        return null;
                }
            }
        }
    }
}
