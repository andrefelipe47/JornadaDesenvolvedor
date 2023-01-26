using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSupermecado.Domain.Models
{
    public enum EnumPermissaoUsuario
    {
        Admin = 1,
        User
    }
    public class Usuario
    {
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}
