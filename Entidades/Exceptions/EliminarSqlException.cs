using System;
using System.Runtime.Serialization;

namespace Entidades
{
    [Serializable]
    internal class EliminarSqlException : Exception
    {
        public EliminarSqlException()
        {
        }

        public EliminarSqlException(string message) : base(message)
        {
        }

        public EliminarSqlException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EliminarSqlException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}