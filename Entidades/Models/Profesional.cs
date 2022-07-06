using Entidades.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Clase que representa un profesional de un centro medico.
    /// </summary>
    public class Profesional : Persona, ICloneable
    {
        private string matricula;
        private List<string> especialidades;
        private DiasDeAtencion diasDeAtencion;

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="apellido"></param>
        /// <param name="fechaDeNacimiento"></param>
        /// <param name="genero"></param>
        /// <param name="nacionalidad"></param>
        /// <param name="documento"></param>
        /// <param name="telefono"></param>
        /// <param name="matricula"></param>
        /// <param name="especialidades"></param>
        public Profesional(string nombre, string apellido, DateTime fechaDeNacimiento, eGenero genero, eNacionalidad nacionalidad, string documento, string telefono, string matricula, List<string> especialidades)
            : base(nombre, apellido, fechaDeNacimiento, genero, nacionalidad, documento, telefono)
        {
            Matricula = matricula;
            this.Especialidades = especialidades;
            this.DiasDeAtencion = new DiasDeAtencion();
        }

        public Profesional(int id, string nombre, string apellido, DateTime fechaDeNacimiento, eGenero genero, eNacionalidad nacionalidad, string documento, string telefono, string matricula, List<string> especialidades)
            : this(nombre, apellido, fechaDeNacimiento, genero, nacionalidad, documento, telefono, matricula, especialidades)
        { 
            this.Id = id;
        }

        /// <summary>
        /// Constructor de la clase.
        /// </summary>
        public Profesional() : base()
        {
            this.especialidades = new List<string>();
            this.DiasDeAtencion = new DiasDeAtencion();
        }

        public List<string> Especialidades { get => especialidades; set => especialidades = value; }
        public DiasDeAtencion DiasDeAtencion { get => diasDeAtencion; set => diasDeAtencion = value; }

        public string Matricula
        {
            get { return matricula; }
            set { matricula = value; }
        }

        /// <summary>
        /// Clona al profesional y devuelve una nueva instancia.
        /// </summary>
        /// <returns></returns>
        private Profesional ClonarProfesional()
        {
            Profesional nuevaReferencia = new Profesional();

            nuevaReferencia.Id = this.Id;
            nuevaReferencia.Nombre = this.Nombre;
            nuevaReferencia.Apellido = this.Apellido;
            nuevaReferencia.FechaDeNacimiento = this.FechaDeNacimiento;
            nuevaReferencia.Genero = this.Genero;
            nuevaReferencia.Nacionalidad = this.Nacionalidad;
            nuevaReferencia.Documento = this.Documento;
            nuevaReferencia.Telefono = this.Telefono;
            nuevaReferencia.Matricula = this.Matricula;
            nuevaReferencia.Especialidades = this.Especialidades;
            nuevaReferencia.DiasDeAtencion = this.DiasDeAtencion;

            return nuevaReferencia;
        }

        /// <summary>
        /// Clona al profesional y devuelve una nueva instancia.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            return this.ClonarProfesional();
        }
    }
}
