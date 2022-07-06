using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class TurnoYaExisteException : Exception
    {
        public TurnoYaExisteException(string message) : base(message)
        {
        }

        public TurnoYaExisteException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}

