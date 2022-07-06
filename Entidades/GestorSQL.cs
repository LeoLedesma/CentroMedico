using Entidades.Exceptions;
using Entidades.Extension_Class;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using static Entidades.CentroMedico;
using static Entidades.Persona;

namespace Entidades
{

    public delegate void GuardarExceptionSQLHandler();
    public delegate void RecuperarExceptionSQLHandler();

    /// <summary>
    /// Clase que administra las entidades de la base de datos
    /// </summary>
    public class GestorSQL
    {
        private static string cadenaConexion;
        public static string querys;
        public static event GuardarExceptionSQLHandler OnGuardarException;
        public static event RecuperarExceptionSQLHandler OnRecuperarException;

        static GestorSQL()
        {
            GestorSQL.cadenaConexion = "Server=DESKTOP-S8IOILV;Database=LedesmaLeonel2ETP4;Trusted_Connection=True;";
        }

        //----------------------Busqueda--------------------------------

        /// <summary>
        /// Busca si el profesional ya contiene asociada la especialidad
        /// </summary>
        /// <param name="idProfesional"></param>
        /// <param name="especialidad"></param>
        /// <returns>true si la tiene, false si no la tiene </returns>
        public static bool BuscarEspecialidadProfesional(int idProfesional, string especialidad)
        {
            string query = "SELECT * FROM especialidadesProfesionales WHERE idProfesional = @idProfesional and idEspecialidadesCentro = @idEspecialidad";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                cmd.Parameters.AddWithValue("@idEspecialidad", BuscarIdEspecialidad(especialidad));
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    return true;
                }

                return false;
            }

        }

        /// <summary>
        /// Busca el id del turno en la BDD
        /// </summary>
        /// <param name="idTurno"></param>
        /// <returns>el id del turno, -1 si no lo encontró</returns>
        public static int BuscarIdTurno(Turno turno)
        {
            string query = "SELECT id FROM turnos WHERE idProfesional = @idProfesional and idPaciente = @idPaciente and fecha = @fecha and idEspecialidad = @idEspecialidad";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idProfesional", BuscarIdProfesional(turno.Profesional.Documento));
                cmd.Parameters.AddWithValue("@idPaciente", BuscarIdPaciente(turno.Paciente.Documento));
                cmd.Parameters.AddWithValue("@fecha", turno.Fecha);
                cmd.Parameters.AddWithValue("@idEspecialidad", BuscarIdEspecialidad(turno.Especialidad));
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;

                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }

                return -1;
            }
        }

        public static List<Turno> BuscarTurnosFuturos(string busqueda, string nombreAtributo)
        {
            string query = $"SELECT * FROM turnos WHERE {nombreAtributo} = @busqueda and fecha >= @hoy";
            List<Turno> coincidencias = new List<Turno>();

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@busqueda", busqueda);
                cmd.Parameters.AddWithValue("@hoy", DateTime.Now);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    DateTime fecha = reader.GetDateTime(1);
                    Paciente paciente = RecuperarPaciente(reader.GetInt32(2));
                    Profesional profesional = RecuperarProfesional(reader.GetInt32(3));
                    string especialidad = RecuperarEspecialidad(reader.GetInt32(4));
                    bool pacienteAsistio = reader.GetBoolean(5);

                    coincidencias.Add(new Turno(id, fecha, paciente, profesional, especialidad, pacienteAsistio));
                }

                return coincidencias;
            }
        }

        public static List<Turno> BuscarTurnos(string queryAdicional)
        {
            string query = "SELECT * FROM turnos ";
            List<Turno> coincidencias = new List<Turno>();

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    DateTime fecha = reader.GetDateTime(1);
                    Paciente paciente = RecuperarPaciente(reader.GetInt32(2));
                    Profesional profesional = RecuperarProfesional(reader.GetInt32(3));
                    string especialidad = RecuperarEspecialidad(reader.GetInt32(4));
                    bool pacienteAsistio = reader.GetBoolean(5);

                    coincidencias.Add(new Turno(id, fecha, paciente, profesional, especialidad, pacienteAsistio));
                }

                return coincidencias;
            }
        }





        /// <summary>
        /// Busca el id del profesional por documento.
        /// </summary>
        /// <param name="documento"></param>
        /// <returns>el id del turno, -1 si no lo encontró</returns>
        public static int BuscarIdProfesional(string documento)
        {
            string query = "SELECT id FROM profesionales WHERE documento = @documento";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@documento", documento);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;


                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }

                return -1;
            }
        }

        /// <summary>
        /// Busca el id del paciente por documento.
        /// </summary>
        /// <param name="documento"></param>
        /// <returns>El id del turno, -1 si no lo encontró</returns>
        public static int BuscarIdPaciente(string documento)
        {

            string query = "SELECT id FROM pacientes WHERE documento = @documento";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@documento", documento);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;

                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }

                return -1;
            }
        }

        /// <summary>
        /// Busca el idDiasDeAtencion del profesional por documento.
        /// </summary>
        /// <param name="documento"></param>
        /// <returns>El idDiasDeAtencion del profesional o -1 si no lo encontro</returns>
        public static int BuscarIdDiasDeAtencion(string documento)
        {
            string query = "SELECT idDiasDeAtencion FROM profesionales WHERE documento = @documento";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@documento", documento);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }

                return -1;
            }
        }

        /// <summary>
        /// Busca el id de la especialidad dentro de especialidadesCentro por nombre.
        /// </summary>
        /// <param name="especialidad"></param>
        /// <returns>El id de la especialidad o -1 si no lo encontro</returns>
        public static int BuscarIdEspecialidad(string especialidad)
        {
            string query = "SELECT ID FROM especialidadesCentro WHERE nombre = @especialidad";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@especialidad", especialidad);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }

                return -1;
            }
        }

        /// <summary>
        /// Busca el idEspecialidad del profesional por idProfesional y especialidad en especialidadesProfesionales.
        /// </summary>
        /// <param name="idProfesional"></param>
        /// <param name="especialidad"></param>
        /// <returns>El id de la especialidad o -1 si no lo encontro</returns>
        public static int BuscarIdEspecialidadProfesional(int idProfesional, string especialidad)
        {
            string query = "SELECT id FROM especialidadesProfesionales WHERE idProfesional = @idProfesional and idEspecialidadesCentro = @idEspecialidad";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idEspecialidad", BuscarIdEspecialidad(especialidad));
                cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }

                return -1;

            }
        }

       

        /// <summary>
        /// Busca si el paciente existe en la base de datos
        /// </summary>
        /// <param name="documento"></param>
        /// <returns>False si no existe, true si ya existe</returns>
        public static bool BuscarPaciente(string documento)
        {
            string query = "SELECT id FROM pacientes WHERE documento = @documento";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@documento", documento);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;

                while (reader.Read())
                {
                    return true;
                }

                return false;
            }
        }
                

        /// <summary>
        /// Busca pacientes segun su atributo y busqueda
        /// </summary>
        /// <param name="busqueda"></param>
        /// <param name="atributo"></param>
        /// <returns>Las coincidencias</returns>
        public static List<Paciente> BuscarPacientes(string busqueda, string atributo)
        {
            string query = $"SELECT * FROM pacientes WHERE {atributo} LIKE @busqueda";
            List<Paciente> pacientes = new List<Paciente>();


            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@atributo", atributo);
                cmd.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pacientes.Add(RecuperarPaciente(reader.GetInt32(0)));
                }

                return pacientes;
            }

        }

        /// <summary>
        /// Busca profesionales segun su atributo y busqueda
        /// </summary>
        /// <param name="busqueda"></param>
        /// <param name="atributo"></param>
        /// <returns>Las coincidencias</returns>
        public static List<Profesional> BuscarProfesionales(string busqueda, string atributo)
        {
            string query = $"SELECT * FROM profesionales WHERE {atributo} LIKE @busqueda";
            List<Profesional> profesionales = new List<Profesional>();


            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@atributo", atributo);
                cmd.Parameters.AddWithValue("@busqueda", "%" + busqueda + "%");
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    profesionales.Add(RecuperarProfesional(reader.GetInt32(0)));
                }

                return profesionales;
            }

        }

        /// <summary>
        /// Busca el idDiasDeAtencion del centromedico
        /// </summary>
        /// <returns>El id o -1 si no lo encontro</returns>
        public static int BuscarIdDiasDeAtencionCentro()
        {
            string query = "SELECT idDiasDeAtencion from centroMedico";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;

                while (reader.Read())
                {
                    return reader.GetInt32(0);
                }
                return -1;
            }
        }

        /// <summary>
        /// Busca si existe el profesional por documento
        /// </summary>
        /// <param name="documento"></param>
        /// <returns>true si existe, false si no</returns>
        public static bool BuscarProfesional(string documento)
        {
            string query = "SELECT id FROM profesionales WHERE documento = @documento";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@documento", documento);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;
                int i = 0;

                while (reader.Read())
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Comprueba si el centro medico ya está cargado.
        /// </summary>
        /// <returns>True si ya esta cargado, false si no</returns>
        public static bool BuscarCentroMedico()
        {
            string query = "SELECT * FROM centroMedico";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Paciente paciente = null;
                int i = 0;

                while (reader.Read())
                {
                    return true;
                }

                return false;

            }

        }


        //-----------------------Guardar----------------------------

        /// <summary>
        /// Guarda todas los campos del centro medico, actualizandolo o creando uno nuevo si no existiese.
        /// </summary>
        /// <param name="centroMedico"></param>
        /// <returns>True si logro guardar el centro medico</returns>
        public static bool GuardarCentroMedico(CentroMedico centroMedico)
        {
            try
            {
                string query;
                bool esActualizacion = false;
                if (BuscarCentroMedico())
                {
                    query = "UPDATE centroMedico set nombre = @nombre, duracionTurno = @duracionTurno WHERE id = @id";
                    esActualizacion = true;
                }
                else
                {
                    query = "INSERT INTO centroMedico (nombre, duracionTurno, idDiasDeAtencion) VALUES (@nombre, @duracionTurno, @idDiasDeAtencion)";
                }


                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@id", 1);
                    cmd.Parameters.AddWithValue("@nombre", centroMedico.Nombre);
                    cmd.Parameters.AddWithValue("@duracionTurno", (int)centroMedico.DuracionDeTurnos);
                    if (esActualizacion)
                    {
                        GestorSQL.ActualizarDiasDeAtencion(centroMedico.DiasDeAtencion, GestorSQL.BuscarIdDiasDeAtencionCentro());
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@idDiasDeAtencion", GestorSQL.GuardarDiasDeAtencion(centroMedico.DiasDeAtencion));
                    }
                    connection.Open();

                    cmd.ExecuteNonQuery();

                    GestorSQL.ActualizarEspecialidadesCentro(centroMedico.ListaEspecialidades);
                    GestorSQL.ActualizarProfesionales(centroMedico.Profesionales);
                    GestorSQL.ActualizarPacientes(centroMedico.Pacientes);
                    GestorSQL.ActualizarTurnos(centroMedico.Turnos);

                }
            }
            catch (Exception)
            {
                GestorSQL.OnGuardarException?.Invoke();
                return false;
            }

            return true;

        }

        public static bool GuardarPersona(Persona persona)
        {
            try
            {

                if (persona is Paciente)
                    return GestorSQL.GuardarPaciente(persona as Paciente);

                else if (persona is Profesional)
                    return GestorSQL.GuardarProfesional(persona as Profesional);

                return false;
            }
            catch (Exception ex)
            {
                throw new GuardarExceptionSQL("Ocurrió un error al guardar la persona.", ex);
            }


        }

        /// <summary>
        /// Guarda la lista de turnos.
        /// </summary>
        /// <param name="turnos"></param>
        /// <returns>La cantidad de turnos que guardó</returns>
        public static int GuardarTurnos(List<Turno> turnos)
        {
            int contador = 0;
            foreach (Turno turno in turnos)
            {
                if (GestorSQL.GuardarTurno(turno))
                    contador++;
            }

            return contador;

        }

        /// <summary>
        /// Guarda un turno
        /// </summary>
        /// <param name="turno"></param>
        /// <returns>True si lo guardo, false si ya existia</returns>
        public static bool GuardarTurno(Turno turno)
        {
            string query = "INSERT INTO turnos (idPaciente, idProfesional, idEspecialidad, fecha, pacienteAsistio) VALUES (@idPaciente, @idProfesional, @idEspecialidad, @fecha, @pacienteAsistio)";

            if (BuscarIdTurno(turno) == -1)
            {
                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@idPaciente", BuscarIdPaciente(turno.Paciente.Documento));
                    cmd.Parameters.AddWithValue("@idProfesional", BuscarIdProfesional(turno.Profesional.Documento));
                    int id = GestorSQL.BuscarIdEspecialidad(turno.Especialidad);
                    cmd.Parameters.AddWithValue("@idEspecialidad", BuscarIdEspecialidad(turno.Especialidad));
                    cmd.Parameters.AddWithValue("@fecha", turno.Fecha);
                    cmd.Parameters.AddWithValue("@pacienteAsistio", turno.PacienteAsistio);

                    connection.Open();

                    cmd.ExecuteNonQuery();
                    return true;
                }
            }

            return false;

        }

        public static bool GuardarEspecialidadCentro(string especialidad)
        {
            if (GestorSQL.BuscarIdEspecialidad(especialidad) == -1)
            {
                string query = "INSERT INTO especialidadesCentro (nombre, isActive) VALUES (@nombre, @isActive)";

                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nombre", especialidad);
                    cmd.Parameters.AddWithValue("@isActive", 1);
                    connection.Open();

                    return cmd.ExecuteNonQuery() == 1 ? true : false;
                }
            }
            else
            {
                string query = "UPDATE especialidadesCentro set nombre = @nombre, isActive = @isActive where nombre = @nombre";
                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nombre", especialidad);
                    cmd.Parameters.AddWithValue("@isActive", 1);
                    connection.Open();

                    return cmd.ExecuteNonQuery() == 1 ? true : false;
                }
            }
        }


        /// <summary>
        /// Guarda la lista de especialidades del centro medico, creandolas o actualizandolas.
        /// </summary>
        /// <param name="especialidades"></param>
        public static void GuardarEspecialidadesCentro(List<string> especialidades)
        {
            foreach (string especialidad in especialidades)
            {
                GestorSQL.GuardarEspecialidadCentro(especialidad);
            }
        }

        /// <summary>
        /// Guarda la lista de especialidades de un profesional, creandolas o actualizandolas.
        /// </summary>
        /// <param name="idProfesional"></param>
        /// <param name="especialidades"></param>
        public static void GuardarEspecialidadesProfesional(int idProfesional, List<string> especialidades)
        {
            foreach (string especialidad in especialidades)
            {
                if (!GestorSQL.BuscarEspecialidadProfesional(idProfesional, especialidad))
                {
                    string query = "INSERT INTO especialidadesProfesionales (idProfesional, idEspecialidadesCentro, isActive) VALUES (@idProfesional, @idEspecialidad, @isActive)";

                    using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                    {
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                        cmd.Parameters.AddWithValue("@idEspecialidad", GestorSQL.BuscarIdEspecialidad(especialidad));
                        cmd.Parameters.AddWithValue("@isActive", 1);
                        connection.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
                else
                {
                    string query = "UPDATE especialidadesProfesionales set idProfesional = @idProfesional, idEspecialidadesCentro = @idEspecialidad, isActive = @isActive " +
                        "where idProfesional = @idProfesional and idEspecialidadesCentro = @idEspecialidad";
                    using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                    {
                        SqlCommand cmd = new SqlCommand(query, connection);
                        cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                        cmd.Parameters.AddWithValue("@idEspecialidad", GestorSQL.BuscarIdEspecialidad(especialidad));
                        cmd.Parameters.AddWithValue("@isActive", 1);
                        connection.Open();

                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        /// <summary>
        /// Guarda una instancia de HorarioDeAtencion.
        /// </summary>
        /// <param name="horario"></param>
        /// <returns>Retorna el id de la instancia que guardo.</returns>
        public static int GuardarHorariosAtencion(HorarioDeAtencion horario)
        {
            string query = "INSERT INTO horarioDeAtencion (atiende, esPorDefecto, desde, hasta) " +
                "VALUES (@atiende, @esPorDefecto, @desde, @hasta)";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                int atiende = horario.Atiende ? 1 : 0;
                int esPorDefecto = horario.EsPorDefecto ? 1 : 0;
                cmd.Parameters.AddWithValue("@atiende", atiende);
                cmd.Parameters.AddWithValue("@esPorDefecto", esPorDefecto);
                cmd.Parameters.AddWithValue("@desde", horario.Desde);
                cmd.Parameters.AddWithValue("@hasta", horario.Hasta);
                connection.Open();

                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT MAX(id) FROM horarioDeAtencion";
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Guarda una instancia de DiasDeAtencion.
        /// </summary>
        /// <param name="diasAtencion"></param>
        /// <returns>Retorna el id de la instancia guardada.</returns>
        public static int GuardarDiasDeAtencion(DiasDeAtencion diasAtencion)
        {
            string query = "INSERT INTO diasDeAtencion(idLunes, idMartes, idMiercoles, idJueves, idViernes, idSabado, idDomingo) " +
                "VALUES (@lunes, @martes, @miercoles, @jueves, @viernes, @sabado, @domingo)";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@lunes", GestorSQL.GuardarHorariosAtencion(diasAtencion.Lunes));
                cmd.Parameters.AddWithValue("@martes", GestorSQL.GuardarHorariosAtencion(diasAtencion.Martes));
                cmd.Parameters.AddWithValue("@miercoles", GestorSQL.GuardarHorariosAtencion(diasAtencion.Miercoles));
                cmd.Parameters.AddWithValue("@jueves", GestorSQL.GuardarHorariosAtencion(diasAtencion.Jueves));
                cmd.Parameters.AddWithValue("@viernes", GestorSQL.GuardarHorariosAtencion(diasAtencion.Viernes));
                cmd.Parameters.AddWithValue("@sabado", GestorSQL.GuardarHorariosAtencion(diasAtencion.Sabado));
                cmd.Parameters.AddWithValue("@domingo", GestorSQL.GuardarHorariosAtencion(diasAtencion.Domingo));

                connection.Open();

                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT MAX(id) FROM diasDeAtencion";
                return (int)cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Guarda una instancia de profesional.
        /// </summary>
        /// <param name="profesional"></param>        
        public static bool GuardarProfesional(Profesional profesional)
        {
            string query = "INSERT INTO profesionales (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, matricula, idDiasDeAtencion, isActive) " +
                "VALUES (@nombre, @apellido, @fechaNacimiento, @genero, @nacionalidad, @documento, @telefono, @matricula, @idDiasDeAtencion, @isActive)";
            if (!BuscarProfesional(profesional.Documento))
            {
                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nombre", profesional.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", profesional.Apellido);
                    cmd.Parameters.AddWithValue("@fechaNacimiento", profesional.FechaDeNacimiento);
                    cmd.Parameters.AddWithValue("@genero", (int)profesional.Genero);
                    cmd.Parameters.AddWithValue("@nacionalidad", (int)profesional.Nacionalidad);
                    cmd.Parameters.AddWithValue("@documento", profesional.Documento);
                    cmd.Parameters.AddWithValue("@telefono", profesional.Telefono);
                    cmd.Parameters.AddWithValue("@matricula", profesional.Matricula);
                    cmd.Parameters.AddWithValue("@idDiasDeAtencion", GestorSQL.GuardarDiasDeAtencion(profesional.DiasDeAtencion));
                    cmd.Parameters.AddWithValue("@isActive", 1);
                    connection.Open();
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        GestorSQL.GuardarEspecialidadesProfesional(BuscarIdProfesional(profesional.Documento), profesional.Especialidades);
                        return true;
                    }
                }

            }

            return false;
        }

        /// <summary>
        /// Guarda una lista de profesionales.
        /// </summary>
        /// <param name="profesionales"></param>
        public static void GuardarProfesionales(List<Profesional> profesionales)
        {

            foreach (Profesional profesional in profesionales)
            {
                GestorSQL.GuardarProfesional(profesional);
            }
        }

        /// <summary>
        /// guarda  una lista de pacientes.
        /// </summary>
        /// <param name="pacientes"></param>
        public static void GuardarPacientes(List<Paciente> pacientes)
        {
            foreach (Paciente paciente in pacientes)
            {
                GestorSQL.GuardarPaciente(paciente);
            }
        }

        /// <summary>
        /// Guarda una instancia de paciente.
        /// </summary>
        /// <param name="paciente"></param>        
        public static bool GuardarPaciente(Paciente paciente)
        {

            if (!BuscarPaciente(paciente.Documento))
            {
                string query = "INSERT INTO pacientes (nombre, apellido, fechaNacimiento, indiceGenero, indiceNacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado, isActive) " +
                "VALUES (@nombre, @apellido, @fechaNacimiento, @genero, @nacionalidad, @documento, @telefono, @telefonoContacto, @obraSocial, @numeroAfiliado, @isActive)";

                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    cmd.Parameters.AddWithValue("@nombre", paciente.Nombre);
                    cmd.Parameters.AddWithValue("@apellido", paciente.Apellido);
                    cmd.Parameters.AddWithValue("@fechaNacimiento", paciente.FechaDeNacimiento);
                    cmd.Parameters.AddWithValue("@genero", (int)paciente.Genero);
                    cmd.Parameters.AddWithValue("@nacionalidad", (int)paciente.Nacionalidad);
                    cmd.Parameters.AddWithValue("@documento", paciente.Documento);
                    cmd.Parameters.AddWithValue("@telefono", paciente.Telefono);
                    cmd.Parameters.AddWithValue("@telefonoContacto", paciente.TelefonoContacto);
                    cmd.Parameters.AddWithValue("@obraSocial", paciente.ObraSocial);
                    cmd.Parameters.AddWithValue("@numeroAfiliado", paciente.NumeroAfiliado);
                    cmd.Parameters.AddWithValue("@isActive", true);

                    connection.Open();

                    return cmd.ExecuteNonQuery() == 1;
                }

            }

            return false;
        }

        //-----------------------Eliminar----------------------------

        public static bool EliminarPersona(Persona persona)
        {
            try
            {
                if (persona is Paciente)
                {
                    return GestorSQL.EliminarPaciente(persona as Paciente);
                }
                else if (persona is Profesional)
                {
                    return GestorSQL.EliminarProfesional(persona as Profesional);
                }

                return false;

            }
            catch (Exception ex)
            {
                throw new EliminarSqlException("Ocurrio un error al eliminar la persona.", ex);
            }

        }

        /// <summary>
        /// Elimina de manera logica una instancia paciente cambiando isActive a 0.
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns>True si pudo eliminarlo, false si no</returns>
        public static bool EliminarPaciente(Paciente paciente)
        {
            string query = "UPDATE pacientes set isActive = 0 WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", BuscarIdPaciente(paciente.Documento));

                connection.Open();
                if (cmd.ExecuteNonQuery() == 1)
                    return true;

                return false;
            }
        }

        /// <summary>
        /// Elimina de manera logica una instancia profesional cambiando isActive a 0.
        /// </summary>
        /// <param name="profesional"></param>
        /// <returns>True si pudo eliminarlo, false si no</returns>
        public static bool EliminarProfesional(Profesional profesional)
        {
            string query = "UPDATE profesionales set isActive = 0 WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", BuscarIdProfesional(profesional.Documento));

                connection.Open();
                if (cmd.ExecuteNonQuery() == 1)
                    return true;

                return false;
            }
        }

        /// <summary>
        /// Elimina de manera logica una especialidad del profesional cambiando isActive a 0.
        /// </summary>
        /// <param name="idProfesional"></param>
        /// <param name="especialidad"></param>
        /// <returns>True si pudo eliminarla, false si no</returns>
        public static bool EliminarEspecialidadProfesional(int idProfesional, string especialidad)
        {
            string query = " UPDATE especialidadesProfesionales SET isActive = 0 WHERE idProfesional = @idProfesional and idEspecialidadesCentro = @idEspecialidad";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                cmd.Parameters.AddWithValue("@idEspecialidad", BuscarIdEspecialidad(especialidad));

                connection.Open();
                if (cmd.ExecuteNonQuery() == 1)
                    return true;

                return false;
            }
        }

        /// <summary>
        /// Elimina de manera logica una especialidad del centro medico cambiando isActive a 0.
        /// </summary>
        /// <param name="idEspecialidad"></param>
        /// <returns>True si pudo eliminarla, false si no</returns>
        public static bool EliminarEspecialidadCentro(int idEspecialidad)
        {
            string query = " UPDATE especialidadesCentro SET isActive = 0 WHERE id = @idEspecialidad";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idEspecialidad", idEspecialidad);

                connection.Open();
                if (cmd.ExecuteNonQuery() == 1)
                    return true;

                return false;
            }

        }

        /// <summary>
        /// Elimina un turno.
        /// </summary>
        /// <param name="turno"></param>
        /// <returns>True si pudo eliminarla, false si no</returns>
        public static bool EliminarTurno(Turno turno)
        {
            string query = "DELETE FROM turnos WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", BuscarIdTurno(turno));

                connection.Open();
                if (cmd.ExecuteNonQuery() == 1)
                    return true;

                return false;
            }
        }

        //-----------------------Actualizar--------------------------

        /// <summary>
        /// Actualiza un paciente con los campos recibidos.
        /// </summary>
        /// <param name="paciente"></param>
        /// <returns>True si pudo actualizarlo, false si no.</returns>
        public static bool ActualizarPaciente(Paciente paciente)
        {
            string query = "UPDATE pacientes set nombre = @nombre, apellido = @apellido, fechaNacimiento = @fechaNacimiento, " +
                "indiceGenero = @genero, indiceNacionalidad = @nacionalidad, documento = @documento, telefono = @telefono, " +
                "telefonoContacto = @telefonoContacto, obraSocial = @obraSocial, numeroAfiliado = @numeroAfiliado, isActive = @isActive WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", paciente.Id);
                cmd.Parameters.AddWithValue("@nombre", paciente.Nombre);
                cmd.Parameters.AddWithValue("@apellido", paciente.Apellido);
                cmd.Parameters.AddWithValue("@fechaNacimiento", paciente.FechaDeNacimiento);
                cmd.Parameters.AddWithValue("@genero", (int)paciente.Genero);
                cmd.Parameters.AddWithValue("@nacionalidad", (int)paciente.Nacionalidad);
                cmd.Parameters.AddWithValue("@documento", paciente.Documento);
                cmd.Parameters.AddWithValue("@telefono", paciente.Telefono);
                cmd.Parameters.AddWithValue("@telefonoContacto", paciente.TelefonoContacto);
                cmd.Parameters.AddWithValue("@obraSocial", paciente.ObraSocial);
                cmd.Parameters.AddWithValue("@numeroAfiliado", paciente.NumeroAfiliado);
                cmd.Parameters.AddWithValue("@isActive", true);

                ///Si paciente con el documento, y su id, es el mismo que en servidor, actualizo

                if (GestorSQL.BuscarIdPaciente(paciente.Documento) == paciente.Id)
                {
                    connection.Open();
                    if (cmd.ExecuteNonQuery() == 1)
                        return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Actualiza los dias de atencion que correspondan al id.
        /// </summary>
        /// <param name="diasDeAtencion"></param>
        /// <param name="id"></param>
        public static void ActualizarDiasDeAtencion(DiasDeAtencion diasDeAtencion, int id)
        {
            string query = "SELECT idLunes, idMartes, idMiercoles, idJueves, idViernes, idSabado, idDomingo FROM diasDeAtencion WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();

                List<int> idsHorarioDeAtencion = new List<int>();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    idsHorarioDeAtencion.Add(reader.GetInt32(0));
                    idsHorarioDeAtencion.Add(reader.GetInt32(1));
                    idsHorarioDeAtencion.Add(reader.GetInt32(2));
                    idsHorarioDeAtencion.Add(reader.GetInt32(3));
                    idsHorarioDeAtencion.Add(reader.GetInt32(4));
                    idsHorarioDeAtencion.Add(reader.GetInt32(5));
                    idsHorarioDeAtencion.Add(reader.GetInt32(6));
                }

                int indice = 1;
                foreach (int idHorarioDeAtencion in idsHorarioDeAtencion)
                {
                    GestorSQL.ActualizarHorarioDeAtencion(idHorarioDeAtencion, diasDeAtencion[indice]);
                    indice++;
                }

            }
        }

        /// <summary>
        /// Actualiza el HorarioDeAtencion que corresponda al id recibido.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="horarioDeAtencion"></param>
        public static void ActualizarHorarioDeAtencion(int id, HorarioDeAtencion horarioDeAtencion)
        {
            string query = "UPDATE horarioDeAtencion SET atiende = @atiende, esPorDefecto = @esPorDefecto, desde = @desde, hasta = @hasta WHERE id = @id";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.Parameters.AddWithValue("@atiende", horarioDeAtencion.Atiende);
                cmd.Parameters.AddWithValue("@esPorDefecto", horarioDeAtencion.EsPorDefecto);
                cmd.Parameters.AddWithValue("@desde", horarioDeAtencion.Desde);
                cmd.Parameters.AddWithValue("@hasta", horarioDeAtencion.Hasta);

                connection.Open();
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Actualiza un profesional.
        /// </summary>
        /// <param name="profesional"></param>
        public static bool ActualizarProfesional(Profesional profesional)
        {
            string query = "UPDATE profesionales set nombre = @nombre, apellido = @apellido, fechaNacimiento = @fechaNacimiento, " +
                "indiceGenero = @genero, indiceNacionalidad = @nacionalidad, documento = @documento, telefono = @telefono, " +
                "matricula = @matricula, idDiasDeAtencion = @idDiasDeAtencion WHERE documento = @documento";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@nombre", profesional.Nombre);
                cmd.Parameters.AddWithValue("@apellido", profesional.Apellido);
                cmd.Parameters.AddWithValue("@fechaNacimiento", profesional.FechaDeNacimiento);
                cmd.Parameters.AddWithValue("@genero", profesional.Genero);
                cmd.Parameters.AddWithValue("@nacionalidad", (int)profesional.Nacionalidad);
                cmd.Parameters.AddWithValue("@documento", profesional.Documento);
                cmd.Parameters.AddWithValue("@telefono", profesional.Telefono);
                cmd.Parameters.AddWithValue("@matricula", profesional.Matricula);
                int idDiasDeAtencion = BuscarIdDiasDeAtencion(profesional.Documento);
                cmd.Parameters.AddWithValue("@idDiasDeAtencion", idDiasDeAtencion);
                connection.Open();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    GestorSQL.ActualizarEspecialidadesProfesional(profesional.Especialidades, profesional.Documento);
                    GestorSQL.ActualizarDiasDeAtencion(profesional.DiasDeAtencion, idDiasDeAtencion);
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// Actualiza las especialidades de un profesional segun su documento.
        /// </summary>
        /// <param name="especialidades"></param>
        /// <param name="documento"></param>
        public static void ActualizarEspecialidadesProfesional(List<string> especialidades, string documento)
        {
            int idProfesional = BuscarIdProfesional(documento);

            List<string> especialidadesExistentes = RecuperarEspecialidadesProfesional(idProfesional);
            GestorSQL.GuardarEspecialidadesProfesional(idProfesional, especialidades.Except(especialidadesExistentes).ToList());

            foreach (string especialidad in especialidadesExistentes.Except(especialidades).ToList())
            {
                GestorSQL.EliminarEspecialidadProfesional(idProfesional, especialidad);
            }
        }

        /// <summary>
        /// Actualiza una persona, tanto si es Paciente o Profesional.
        /// </summary>
        /// <param name="persona"></param>
        public static bool ActualizarPersona(Persona persona)
        {
            try
            {
                if (persona is Paciente)
                {
                    return GestorSQL.ActualizarPaciente((Paciente)persona);

                }
                else if (persona is Profesional)
                {
                    return GestorSQL.ActualizarProfesional((Profesional)persona);
                }

                return false;
            }
            catch (Exception ex)
            {
                throw new ActualizarSqlException("Ocurrió un error al actualizar persona", ex);
            }
        }

        /// <summary>
        /// Actualiza la lista de profesionales del centro medico.
        /// </summary>
        /// <param name="profesionales"></param>
        public static void ActualizarProfesionales(List<Profesional> profesionales)
        {
            List<Profesional> profesionalesExistentes = RecuperarProfesionales();
            GestorSQL.GuardarProfesionales(profesionales);

            foreach (Profesional profesional in profesionalesExistentes.EliminarCoincidencias(profesionales))
            {
                GestorSQL.EliminarProfesional(profesional);
            }
        }

        /// <summary>
        /// Actualiza la lista de turnos del centro medico.
        /// </summary>
        /// <param name="turnos"></param>
        public static void ActualizarTurnos(List<Turno> turnos)
        {
            List<Turno> turnosExistentes = RecuperarTurnos();
            GestorSQL.GuardarTurnos(turnos.Except(turnosExistentes).ToList());

            foreach (Turno turno in turnosExistentes.Except(turnos).ToList())
            {
                GestorSQL.EliminarTurno(turno);
            }
        }

        /// <summary>
        /// Actualiza la lista de pacientes del centro medico.
        /// </summary>
        /// <param name="pacientes"></param>
        public static void ActualizarPacientes(List<Paciente> pacientes)
        {
            List<Paciente> pacientesExistentes = RecuperarPacientes();
            GestorSQL.GuardarPacientes(pacientes);

            foreach (Paciente paciente in pacientesExistentes.EliminarCoincidencias(pacientes))
            {
                GestorSQL.EliminarPaciente(paciente);
            }
        }

        /// <summary>
        /// Actualiza la lista de especialidades del centro medico.
        /// </summary>
        /// <param name="especialidades"></param>
        public static void ActualizarEspecialidadesCentro(List<string> especialidades)
        {
            List<string> especialidadesExistentes = RecuperarEspecialidadesCentro();
            GestorSQL.GuardarEspecialidadesCentro(especialidades.Except(especialidadesExistentes).ToList());

            foreach (string especialidad in especialidadesExistentes.Except(especialidades).ToList())
            {
                GestorSQL.EliminarEspecialidadCentro(BuscarIdEspecialidad(especialidad));
            }

        }

        //-----------------------Carga--------------------------

        /// <summary>
        /// Recupera de la base de datos un paciente por su id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Una instancia del paciente o null si no pudo.</returns>
        public static Paciente RecuperarPaciente(int id)
        {
            string query = "SELECT * FROM pacientes where id = @id";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    DateTime fechaNacimiento = reader.GetDateTime(3);
                    eGenero genero = (eGenero)reader.GetInt32(4);
                    eNacionalidad nacionalidad = (eNacionalidad)reader.GetInt32(5);
                    string documento = reader.GetString(6);
                    string telefono = reader.GetString(7);
                    string telefonoContacto = reader.GetString(8);
                    string obraSocial = reader.GetString(9);
                    string numeroAfiliado = reader.GetString(10);

                    return new Paciente(id, nombre, apellido, fechaNacimiento, genero, nacionalidad, documento, telefono, telefonoContacto, obraSocial, numeroAfiliado);

                }

                return null;
            }
        }

        /// <summary>
        /// Recupera los pacientes del centro medico activos.
        /// </summary>
        /// <returns>Retorna la lista de pacientes que recupero.</returns>
        public static List<Paciente> RecuperarPacientes()
        {
            List<Paciente> pacientes = new List<Paciente>();

            string query = "SELECT * FROM pacientes where isActive = 1";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    pacientes.Add(RecuperarPaciente(reader.GetInt32(0)));
                }

                return pacientes;
            }
        }

        /// <summary>
        /// Recupera todos los horarios de atencion segun el id del DiaDeAtencion
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Una instancia de DiaDeAtencion o null si no logró recuperarla.</returns>
        public static DiasDeAtencion RecuperarDiasDeAtencion(int id)
        {
            string query = "SELECT * FROM diasDeAtencion where id = @id";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {

                    HorarioDeAtencion lunes = RecuperarHorarioDeAtencion(reader.GetInt32(1));
                    HorarioDeAtencion martes = RecuperarHorarioDeAtencion(reader.GetInt32(2));
                    HorarioDeAtencion miercoles = RecuperarHorarioDeAtencion(reader.GetInt32(3));
                    HorarioDeAtencion jueves = RecuperarHorarioDeAtencion(reader.GetInt32(4));
                    HorarioDeAtencion viernes = RecuperarHorarioDeAtencion(reader.GetInt32(5));
                    HorarioDeAtencion sabado = RecuperarHorarioDeAtencion(reader.GetInt32(6));
                    HorarioDeAtencion domingo = RecuperarHorarioDeAtencion(reader.GetInt32(7));

                    DiasDeAtencion diasDeAtencion = new DiasDeAtencion();
                    diasDeAtencion.Lunes = lunes;
                    diasDeAtencion.Martes = martes;
                    diasDeAtencion.Miercoles = miercoles;
                    diasDeAtencion.Jueves = jueves;
                    diasDeAtencion.Viernes = viernes;
                    diasDeAtencion.Sabado = sabado;
                    diasDeAtencion.Domingo = domingo;

                    return diasDeAtencion;
                }

                return null;

            }
        }

        /// <summary>
        /// Recupera el horario de atencion segun su id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Una instancia de horario de atencion</returns>
        public static HorarioDeAtencion RecuperarHorarioDeAtencion(int id)
        {
            string query = "SELECT * FROM horarioDeAtencion where id = @id";

            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    bool atiende = reader.GetBoolean(1);
                    bool esPorDefecto = reader.GetBoolean(2);
                    string desde = reader.GetString(3);
                    string hasta = reader.GetString(4);

                    return new HorarioDeAtencion(atiende, desde, hasta, esPorDefecto);
                }

                return new HorarioDeAtencion();
            }
        }

        /// <summary>
        /// Recupera un profesional segun su id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Una instancia de profesonal o null si no logro recuperarla</returns>
        public static Profesional RecuperarProfesional(int id)
        {
            string query = "SELECT * FROM profesionales where id = @id";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    DateTime fechaNacimiento = reader.GetDateTime(3);
                    eGenero genero = (eGenero)reader.GetInt32(4);
                    eNacionalidad nacionalidad = (eNacionalidad)reader.GetInt32(5);
                    string documento = reader.GetString(6);
                    string telefono = reader.GetString(7);
                    string matricula = reader.GetString(8);
                    List<string> especialidades = GestorSQL.RecuperarEspecialidadesProfesional(id);
                    DiasDeAtencion diasDeAtencion = GestorSQL.RecuperarDiasDeAtencion(reader.GetInt32(9));

                    return new Profesional(id, nombre, apellido, fechaNacimiento, genero, nacionalidad, documento, telefono, matricula, especialidades);
                }

                return null;
            }
        }

        /// <summary>
        /// Recupera la lista de profesionales activos del centro medico.
        /// </summary>
        /// <returns>La lista de pacientes que logro recuperar.</returns>
        public static List<Profesional> RecuperarProfesionales()
        {
            List<Profesional> pacientes = new List<Profesional>();

            string query = "SELECT * FROM profesionales where isActive = 1";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    string nombre = reader.GetString(1);
                    string apellido = reader.GetString(2);
                    DateTime fechaNacimiento = reader.GetDateTime(3);
                    eGenero genero = (eGenero)reader.GetInt32(4);
                    eNacionalidad nacionalidad = (eNacionalidad)reader.GetInt32(5);
                    string documento = reader.GetString(6);
                    string telefono = reader.GetString(7);
                    string matricula = reader.GetString(8);
                    List<string> especialidades = GestorSQL.RecuperarEspecialidadesProfesional(id);

                    pacientes.Add(new Profesional(id, nombre, apellido, fechaNacimiento, genero, nacionalidad, documento, telefono, matricula, especialidades));
                }

                return pacientes;
            }
        }

        /// <summary>
        /// Recupera las especialidades activas de un profesional segun su id.
        /// </summary>
        /// <param name="idProfesional"></param>
        /// <returns>Lista de especialidades que logro recuperar.</returns>
        public static List<string> RecuperarEspecialidadesProfesional(int idProfesional)
        {
            List<string> especialidades = new List<string>();

            string query = "SELECT * FROM especialidadesProfesionales where idProfesional = @idProfesional and isActive = @isActive";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@idProfesional", idProfesional);
                cmd.Parameters.AddWithValue("@isActive", 1);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    especialidades.Add(RecuperarEspecialidad(reader.GetInt32(0)));
                }

                return especialidades;
            }
        }

        /// <summary>
        /// Recupera la lista de especialidades activas del centro medico.
        /// </summary>
        /// <returns></returns>
        public static List<string> RecuperarEspecialidadesCentro()
        {
            string query = "SELECT * FROM especialidadesCentro WHERE isActive = 1";
            List<string> especialidades = new List<string>();
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                int i = 0;

                while (reader.Read())
                {
                    especialidades.Add(reader.GetString(1));
                }

                return especialidades;
            }

        }

        /// <summary>
        /// Recupera una especialidad del centro medico segun su id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>La especialidad o null si no logro recuperarla.</returns>
        public static string RecuperarEspecialidad(int id)
        {

            string query = "SELECT * FROM especialidadesCentro where id = @id and isActive = 1";
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@id", id);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    return reader.GetString(1);
                }
                return null;
            }
        }

        /// <summary>
        /// Recupera la lista de turnos del centro medico.
        /// </summary>
        /// <returns>La lista de turnos que logro recuperar.</returns>
        public static List<Turno> RecuperarTurnos()
        {
            string query = "SELECT * FROM TURNOS";
            List<Turno> turnos = new List<Turno>();
            using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int id = reader.GetInt32(0);
                    DateTime fecha = reader.GetDateTime(1);
                    Paciente paciente = RecuperarPaciente(reader.GetInt32(2));
                    Profesional profesional = RecuperarProfesional(reader.GetInt32(3));
                    string especialidad = RecuperarEspecialidad(reader.GetInt32(4));
                    bool pacienteAsistio = reader.GetBoolean(5);

                    turnos.Add(new Turno(id, fecha, paciente, profesional, especialidad, pacienteAsistio));
                }
                return turnos;
            }
        }

        /// <summary>
        /// Recupera todos los elementos del centro medico.
        /// </summary>
        /// <param name="centro"></param>
        public static void RecuperarCentroMedico(CentroMedico centro)
        {
            try
            {
                centro.AgregarPersonas(RecuperarProfesionales());
                centro.AgregarPersonas(RecuperarPacientes());
                centro.ListaEspecialidades.AddRange(RecuperarEspecialidadesCentro());
                centro.Turnos.AddRange(RecuperarTurnos());

                string query = "SELECT * FROM centroMedico";

                using (SqlConnection connection = new SqlConnection(GestorSQL.cadenaConexion))
                {
                    SqlCommand cmd = new SqlCommand(query, connection);
                    connection.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        centro.Nombre = reader.GetString(1);
                        centro.DuracionDeTurnos = (EDuracionTurno)reader.GetInt32(2);
                        centro.DiasDeAtencion = RecuperarDiasDeAtencion(reader.GetInt32(3));
                    }
                }
            }
            catch (Exception)
            {
                GestorSQL.OnRecuperarException?.Invoke();
            }

        }

    }
}