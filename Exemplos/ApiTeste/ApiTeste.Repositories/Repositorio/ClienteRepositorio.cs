using ApiTeste.Domain.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Repositories.Repositorio
{
    public class ClienteRepositorio : Contexto
    {
        private readonly IMongoCollection<Cliente> _collection;
        public ClienteRepositorio(IConfiguration configuration) : base(configuration)
        {
            _collection = _database.GetCollection<Cliente>("Cliente");
        }

        public void Inserir(Cliente model)
        {
            _collection.InsertOne(model);
        }
        public void Atualizar(Cliente model)
        {
            // atualizar também e uma insercao, o detalhe, e que os bancos de dados não relacionais utilizam a primary key pra se orientar
            // ou seja, se já existe na base, ele atualiza sem você precisar falar explicitamente
            _collection.InsertOne(model);
        }
        public bool SeExiste(string cpfCliente)
        {
            var filter = Builders<Cliente>.Filter.Eq("CpfCliente", cpfCliente);
            var isExiste = _collection.Find<Cliente>(filter);

            return isExiste.FirstOrDefault() is null;
        }
        public Cliente? Obter(string cpfCliente)
        {
            var filter = Builders<Cliente>.Filter.Eq("CpfCliente", cpfCliente);
            return _collection.Find<Cliente>(filter).FirstOrDefault();
        }
        public List<Cliente> ListarClientes(string? nome)
        {
            var builder = Builders<Cliente>.Filter;
            var filter = builder.Empty;
            if (nome != null)
            {
                var nomeFilter = builder.Eq("Nome", nome);
                filter &= nomeFilter;
            }

            return _collection.Find<Cliente>(filter).ToList();
        }
        public void Deletar(string cpfCliente)
        {
            var filter = Builders<Cliente>.Filter.Eq("CpfCliente", cpfCliente);
            _collection.FindOneAndDelete<Cliente>(filter);
        }
    }
}
