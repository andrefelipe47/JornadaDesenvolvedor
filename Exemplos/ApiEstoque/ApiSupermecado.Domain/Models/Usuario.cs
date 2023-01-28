using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSupermecado.Domain.Models
{
    public enum EnumCargoUsuario
    {
        Vendedor = 1,
        Marketing
    }
    public class Usuario
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Nome { get; set; }
        public EnumCargoUsuario CargoUsuario { get; set; }
    }
}
