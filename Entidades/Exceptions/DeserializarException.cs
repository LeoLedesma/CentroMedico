using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    public class DeserializarException : Exception
    {
        public DeserializarException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }

        public DeserializarException(string mensaje) : base(mensaje)
        {
        }
    }
}
