using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades.Exceptions;
using Entidades.Interfaces;
using Entidades.Models;
using System.Xml.Serialization;


namespace Entidades
{
    public abstract class GestorDeArchivos
    {
        /// <summary>
        /// Escribe en la carpeta donde se esta ejecutando el programa el error.
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns>True si fue satisfactorio</returns>
        /// <exception cref="Exception"></exception>
        public static bool EscribirErrorEnLog(string mensaje)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter($"{Directory.GetCurrentDirectory()}\\errores.log", true))
                {
                    sw.WriteLine($"{mensaje}");
                }
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al Escribir el Log.");
            }
        }

        /// <summary>
        /// Guarda en el path recibido la cadena de texto de datos.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="datos"></param>
        /// <returns>True si fue satisfactorio</returns>
        /// <exception cref="Exception"></exception>
        public static bool GuardarArchivo(string path, string datos)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine(datos);
                }
                return true;
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al guardar el archivo.");
            }
        }

        /// <summary>
        /// Lee el archivo que este en el path recibido y lo retorna.
        /// </summary>
        /// <param name="path"></param>
        /// <returns>Si encontró el archivo, el contenido del mismo.</returns>
        /// <exception cref="Exception"></exception>
        public static string LeerArchivo(string path)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    return sr.ReadToEnd();
                }
            }
            catch (Exception)
            {
                throw new Exception("Ocurrio un error al leer el archivo");
            }
        }

        /// <summary>
        /// Guarda una lista de objetos en el path indicado, llamando al ToString del objeto.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="fullPath"></param>
        /// <param name="lista"></param>
        /// <exception cref="Exception"></exception>
        public static void GuardarArchivo<T>(string fullPath, List<T> lista)
        {
            try
            {
                StringBuilder sb = new StringBuilder();

                foreach (T item in lista)
                {
                    sb.AppendLine(item.ToString());
                }

                GestorDeArchivos.GuardarArchivo(fullPath, sb.ToString());
            }catch(Exception)
            {
                throw new Exception("Ocurrio un error al guardar la lista.");
            }
        }

    }
}
