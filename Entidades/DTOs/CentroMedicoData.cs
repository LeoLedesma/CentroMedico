using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades
{
    /// <summary>
    /// Hace de intermediara de la clase CentroMedico para realizar la serializacion, debido a su diseño Singleton, 
    /// CentroMedico no puede ser instanciada a traves de un constructor publico sin parametros.
    /// </summary>
    /// 
    [XmlRoot("CentroMedico")]
    public class CentroMedicoData
    {

        public CentroMedicoData()
        {           
        }

        [XmlElement("Nombre")]
        public string Nombre { get => CentroMedico.Instancia.Nombre; set => CentroMedico.Instancia.Nombre = value; }
        
        [XmlElement("Pacientes")]
        public List<Paciente> Pacientes { get => CentroMedico.Instancia.Pacientes; set => CentroMedico.Instancia.Pacientes = value; }

        [XmlElement("Profesionales")]
        public List<Profesional> Profesionales { get => CentroMedico.Instancia.Profesionales; set => CentroMedico.Instancia.Profesionales = value; }

        [XmlElement("ListaEspecialidades")]
        public List<string> ListaEspecialidades { get => CentroMedico.Instancia.ListaEspecialidades; set => CentroMedico.Instancia.ListaEspecialidades = value; }

        [XmlElement("Turnos")]
        public List<Turno> Turnos { get => CentroMedico.Instancia.Turnos; set => CentroMedico.Instancia.Turnos = value; }

        [XmlElement("HorarioDeAtencion")]
        public DiasDeAtencion DiasDeAtencion { get => CentroMedico.Instancia.DiasDeAtencion; set => CentroMedico.Instancia.DiasDeAtencion = value; }

        [XmlElement("DuracionDeTurnos")]
        public CentroMedico.EDuracionTurno DuracionDeTurnos { get => CentroMedico.Instancia.DuracionDeTurnos; set => CentroMedico.Instancia.DuracionDeTurnos = value; }

        public static explicit operator CentroMedico(CentroMedicoData centro1)
        {
            return CentroMedico.Instancia;
        }

    }
}
