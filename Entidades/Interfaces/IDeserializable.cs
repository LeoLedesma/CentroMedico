using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Interfaces
{
    public interface IDeserializable<T>
    {
        /// <summary>
        /// Deserializa la entidad desde un archivo .XML, devolviendo un objeto generico.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public T DeserializarFromXML(string path);

        /// <summary>
        /// Deserializa la entidad desde un archivo .JSON, devolviendo un objeto generico.
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public T DeserializarFromJson(string path);
    }
}
