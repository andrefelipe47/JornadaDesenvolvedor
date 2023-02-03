using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Repositories
{
    public class Contexto
    {
        internal readonly IMongoDatabase _database;
        public Contexto(IConfiguration configuration)
        {
            var credenciaisConexao = configuration["conexaoMongoDB"];
            var cliente = new MongoClient(credenciaisConexao);
            _database = cliente.GetDatabase("andre_martins");
        }
    }
}
