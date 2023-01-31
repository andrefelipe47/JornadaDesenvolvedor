using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsumento.Models
{
    public class Pessoa
    {
        private string cpf;

        public string GetCpf()
        {
            return cpf;
        }
        public void SetCpf(string cpf)
        {
            this.cpf = cpf + "-";
        }

        private string nome;
        public string Nome { get { return nome; } set { nome = value; } }
    }
}
