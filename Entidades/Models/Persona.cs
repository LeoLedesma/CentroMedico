using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase que representa una persona
    /// </summary>
    [XmlInclude(typeof(Paciente)), XmlInclude(typeof(Profesional))]    
    public abstract class Persona : ISerializable
    {
        public enum eGenero { Femenino=0, Masculino, NoBinario, Otro }
        public enum eNacionalidad { Argentina=1, Brasilera, Boliviana, Chilena, Colombiana, Paraguaya, Uruguaya, Venezolana, Otra }

        private int id;
        private string nombre;
        private string apellido;
        private DateTime fechaDeNacimiento;
        private int edad;
        private eNacionalidad nacionalidad;
        private eGenero genero;
        private string documento;
        private string telefono;

        /// <summary>
        /// Constructor de persona
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaDeNacimiento"></param>
        /// <param name="sexo"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="documento"></param>
        /// <param name="telefono"></param>
        internal Persona(string nombre, string apellido, DateTime fechaDeNacimiento, eGenero sexo, eNacionalidad nacionalidad, string documento, string telefono)
        {
            this.Nombre = nombre;
            this.Apellido = apellido;
            this.FechaDeNacimiento = fechaDeNacimiento;
            this.Genero = sexo;
            this.Documento = documento;
            this.Telefono = telefono;
            this.Nacionalidad = nacionalidad;
        }

        internal Persona(int id, string nombre, string apellido, DateTime fechaDeNacimiento, eGenero sexo, eNacionalidad nacionalidad, string documento, string telefono) : this(nombre, apellido, fechaDeNacimiento, sexo, nacionalidad, documento, telefono)
        {
            this.Id = id;
        }

        internal Persona()
        {            
        }

        public string Nombre { get => nombre; set => nombre = value.ToLower(); }
        public string Apellido { get => apellido; set => apellido = value.ToLower(); }
        public int Edad
        {
            get => edad;
        }

        public DateTime FechaDeNacimiento
        {
            get { return fechaDeNacimiento; }
            set
            {
                if (fechaDeNacimiento < DateTime.Now)
                {
                    this.fechaDeNacimiento = value;
                    edad = DateTime.Now.Year - fechaDeNacimiento.Year;

                    if (fechaDeNacimiento.Month > DateTime.Now.Month)
                    {
                        edad--;
                    }
                }
            }
        }

        public string Documento { get => documento; set => documento = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public int Id { get => id; set => id = value; }
        public eGenero Genero { get => genero; set => genero = value; }
        public eNacionalidad Nacionalidad { get => nacionalidad; set => nacionalidad = value; }


        //Sobrecarga de operadores


        public static bool operator ==(Persona p1, Persona p2)
        {
            return p1.Documento == p2.Documento;
        }

        public static bool operator !=(Persona p1, Persona p2)
        {
            return !(p1 == p2);
        }

        /// <summary>
        /// Serializa a la persona segun la extension del fullPath.
        /// </summary>
        /// <param name="fullPath"></param>
        /// <exception cref="SerializarException"></exception>
        public void Serializar(string fullPath)
        {
            if (fullPath.Contains(".xml"))
            {
                this.SerializarToXML(fullPath);
            }
            else if (fullPath.Contains(".json"))
            {
                this.SerializarToJSON(fullPath);
            }
        }

        /// <summary>
        /// Serializa la persona a un archivo XML
        /// </summary>
        /// <param name="fullPath"></param>
        /// <exception cref="SerializarException"></exception>
        public void SerializarToXML(string fullPath)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(fullPath);
                XmlSerializer xml;
                
                if (this is Paciente)
                {
                    List<Paciente> lista = new List<Paciente>() { (Paciente) this };
                    xml = new XmlSerializer(typeof(List<Paciente>));
                    xml.Serialize(streamWriter, lista);                    

                }
                else if (this is Profesional)
                {
                    List<Profesional> lista = new List<Profesional>() { (Profesional)this };                    
                    xml = new XmlSerializer(typeof(List<Paciente>));
                    xml.Serialize(streamWriter, lista);
                }               

            }
            catch (Exception e)
            {
                throw new SerializarException($"Error al guardar el {this.GetType()}", e);
            }
            finally
            {
                if (streamWriter != null)
                    streamWriter.Close();
            }
        }

        /// <summary>
        /// Serializa la persona a un archivo JSON
        /// </summary>
        /// <param name="fullPath"></param>
        /// <exception cref="SerializarException"></exception>
        public void SerializarToJSON(string fullPath)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(fullPath);

                JsonSerializerOptions options = new JsonSerializerOptions();
                options.WriteIndented = true;
                string jsonString = JsonSerializer.Serialize(this, options);

                streamWriter.WriteLine(jsonString);
            }
            catch (Exception e)
            {
                throw new SerializarException($"Error al serializar el {this.GetType()}.", e);
            }
            finally
            {
                if (streamWriter != null)
                    streamWriter.Close();
            }
        }

        /// <summary>
        /// Describe a la persona con nombre y apellido.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{this.Nombre.TotUpperFirstLetter()} {this.Apellido.TotUpperFirstLetter()}";
        }


    }
}
