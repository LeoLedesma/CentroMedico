using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Exceptions
{
    class GuardarExceptionSQL : Exception
    {
        public GuardarExceptionSQL(string mensaje, Exception innerException) : base(mensaje, innerException)
        {
        }

        public GuardarExceptionSQL(string mensaje) : base(mensaje)
        {
        }
    }
}
