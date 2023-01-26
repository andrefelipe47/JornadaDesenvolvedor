using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSupermecado.Repositories
{
    public class Contexto
    {
        internal readonly SqlConnection _conn;
        public Contexto(IConfiguration configuration)
        {
            _conn = new SqlConnection(configuration["DbCredentials"]);
        }

        public void AbrirConexao()
        {
            _conn.Open();
        }

        public void FecharConexao()
        {
            _conn.Close();
        }
    }
}
