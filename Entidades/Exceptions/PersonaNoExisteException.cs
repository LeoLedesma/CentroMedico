using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class PersonaNoExisteException : Exception
    {
        public PersonaNoExisteException()
        {
        }

        public PersonaNoExisteException(string message)
            : base(message)
        {
        }

        public PersonaNoExisteException(string message, Exception inner)
            : base(message, inner)
        {
        }

    }
}
