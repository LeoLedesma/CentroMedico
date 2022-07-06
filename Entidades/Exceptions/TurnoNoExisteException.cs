using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class TurnoNoExisteException : Exception
    {
        public TurnoNoExisteException()
        {
        }

        public TurnoNoExisteException(string message)
            : base(message)
        {
        }

        public TurnoNoExisteException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
