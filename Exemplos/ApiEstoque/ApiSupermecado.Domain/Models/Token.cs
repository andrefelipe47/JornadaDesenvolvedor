using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiSupermecado.Domain.Models
{
    public class Token
    {
        public string Bearer { get; set; }
        public DateTime Validade { get; set; }
        public int NivelAcesso { get; set; }
        public string NomeUsuario { get; set; }
    }
}
