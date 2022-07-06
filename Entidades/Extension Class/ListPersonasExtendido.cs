using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades.Extension_Class
{
    public static class ListPersonasExtendido
    {
        public static List<T> EliminarCoincidencias<T>(this List<T> lista, List<T> list) where T : Persona
        {
            List<T> nueva = new List<T>();
            nueva.AddRange(lista);
            foreach (T a in lista)
            {
                foreach(T b in list)
                {
                    if (a.Documento == b.Documento)
                    {
                        nueva.Remove(a);
                    }
                }
            }

            return nueva;
        }

    }
}
