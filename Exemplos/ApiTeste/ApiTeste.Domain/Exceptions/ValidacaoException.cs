using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTeste.Domain.Exceptions
{
    public class ValidacaoException : Exception
    {
        public ValidacaoException() { }

        public ValidacaoException(string message)
            : base(message) { }

        public ValidacaoException(string message, Exception inner)
            : base(message, inner) { }
    }
}
