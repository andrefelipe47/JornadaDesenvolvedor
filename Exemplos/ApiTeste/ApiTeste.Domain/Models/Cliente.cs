using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Domain.Models
{
    public class Cliente
    {
        [BsonId]
        public string Id { get; set; }
        public string CpfCliente { get; set; }
        public string Nome { get; set; }
        public DateTime Nascimento { get; set; }
        public string? Telefone { get; set; }
    }
}
