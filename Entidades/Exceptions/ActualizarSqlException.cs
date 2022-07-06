using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    class ActualizarSqlException : Exception
    {

        public ActualizarSqlException(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }

        public ActualizarSqlException(string mensaje) : base(mensaje)
        {
        }

    }
}
