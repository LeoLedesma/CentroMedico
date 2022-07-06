using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{

    public class Turno : ISerializable
    {
        private int id;
        private DateTime fecha;
        private Paciente paciente;
        private Profesional profesional;
        private string especialidad;
        private bool pacienteAsistio;

        public Turno(int id, DateTime fecha, Paciente paciente, Profesional profesional, string especialidad)
        {
            this.Fecha = fecha;
            this.Paciente = paciente;
            this.Profesional = profesional;
            this.Especialidad = especialidad;
            this.Id = id;
        }
        public Turno(int id, DateTime fecha, Paciente paciente, Profesional profesional, string especialidad, bool pacienteAsistio) : this(id, fecha, paciente, profesional, especialidad)
        {
            this.pacienteAsistio = pacienteAsistio;
        }

        public Turno()
        {
        }

        /// <summary>
        /// Describe al turno.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append($"Id: {this.Id} - Fecha: {this.Fecha.ToString("dddd dd/MM/yyyy hh:mm")} - Paciente: {this.Paciente} - " +
                $"Profesional: {this.Profesional} - Especialidad: {this.Especialidad}");

            return sb.ToString();
        }

        public DateTime Fecha { get => fecha; set => fecha = value; }
        public Paciente Paciente { get => paciente; set => paciente = value; }
        public Profesional Profesional { get => profesional; set => profesional = value; }
        public string Especialidad { get => especialidad; set => especialidad = value; }
        public int Id { get => id; set => id = value; }
        public bool PacienteAsistio { get => pacienteAsistio; set => pacienteAsistio = value; }

        /// <summary>
        /// Confirma la asistencia al turno.
        /// </summary>
        public void Confirmar()
        {
            this.pacienteAsistio = true;
        }

        public void Serializar(string fullPath)
        {
            if (fullPath.Contains(".xml"))
                this.SerializarToXML(fullPath);
            else if (fullPath.Contains(".json"))
                this.SerializarToJSON(fullPath);
        }

        /// <summary>
        /// Serializa el turno a un archivo XML.
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
                                
                xml = new XmlSerializer(typeof(Turno));
                xml.Serialize(streamWriter, this);
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
        /// Serializa el turno a un archivo json.
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
        /// Dos turnos son iguales cuando tienen la misma fecha, profesional y paciente.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool operator ==(Turno t1, Turno t2)
        {
            return t1.profesional == t2.profesional && t1.paciente == t2.paciente && t1.fecha == t2.fecha;
        }

        /// <summary>
        /// Dos turnos son diferentes cuando no tienen la misma fecha, profeisonal y paciente.
        /// </summary>
        /// <param name="t1"></param>
        /// <param name="t2"></param>
        /// <returns></returns>
        public static bool operator !=(Turno t1, Turno t2)
        {
            return !(t1 == t2);
        }
    }
}
