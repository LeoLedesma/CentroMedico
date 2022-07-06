using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.Exceptions;

namespace Formularios
{
    /// <summary>
    /// Formulario que se utiliza para buscar profesionales, pacientes y turnos de un centro médico.
    /// </summary>
    public partial class FrmBuscar : FrmSecundario
    {
        private List<Paciente> coincidenciasPacientes;
        private List<Profesional> coincidenciasProfesionales;
        private List<Turno> coincidenciasTurnos;
        private bool abrirFuncionPaciente;
        private bool abrirFuncionTurnos;

        /// <summary>
        /// Constructor que inicializa el formulario.
        /// </summary>
        /// <param name="titulo"></param>
        private FrmBuscar(string titulo) : base(titulo)
        {
            InitializeComponent();
            cmbBuscarPor.SelectedIndex = 0;
            coincidenciasPacientes = new List<Paciente>();
            coincidenciasProfesionales = new List<Profesional>();
            coincidenciasTurnos = new List<Turno>();
        }

        /// <summary>
        /// Constructor del formulario, si desea buscar pacientes abriFuncionPaciente debe ser true,
        /// en cambio si quiere buscar profesionales debe ser false
        /// </summary>
        /// <param name="abrirFuncionPaciente"></param>
        /// <param name="titulo"></param>
        public FrmBuscar(bool abrirFuncionPaciente, string titulo) : this(titulo)
        {
            this.abrirFuncionPaciente = abrirFuncionPaciente;
            this.abrirFuncionTurnos = false;
        }
        /// <summary>
        /// Constructor del formulario para buscar turno, donde abrirFuncionTurnos debe ser true.
        /// </summary>
        /// <param name="abrirFuncionTurnos"></param>
        public FrmBuscar(bool abrirFuncionTurnos) : this("Buscar turnos")
        {
            this.abrirFuncionTurnos = abrirFuncionTurnos;
            this.abrirFuncionPaciente = false;
            this.CargarVisualTurnos();
        }

        static FrmBuscar()
        {
            FrmBuscar.errorProvider = new ErrorProvider();
        }

        /// <summary>
        /// Carga el diseño para buscar turnos
        /// </summary>
        public void CargarVisualTurnos()
        {
            cmbBuscarPor.DataSource = new List<string>()
            {
                "Documento paciente",
                "Apellido profesional",
                "Id turno",
                "Todos"
            };

            lblTextoBusqueda.Text = cmbBuscarPor.Text;

            cmbBuscarTurnos.Visible = true;
            cmbBuscarTurnos.DataSource = new List<string>()
            {
                "Futuros",
                "Pasados",
                "Todos"
            };
        }

        /// <summary>
        /// Busca a los pacientes segun las opciones elegidas.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BusquedaException"></exception>
        private List<Paciente> BuscarPacientes()
        {
            try
            {
                if (cmbBuscarPor.Text != "Todos")
                    return centroMedico.BuscarPaciente(txbBusqueda.Text, cmbBuscarPor.Text.ToLower());
                else
                    return centroMedico.RecuperarPacientes();
            }
            catch (BusquedaException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new List<Paciente>();
        }

        /// <summary>
        /// Busca a los profesionales segun las opciones elegidas.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="BusquedaException"></exception>
        private List<Profesional> BuscarProfesionales()
        {
            try
            {
                if (cmbBuscarPor.Text != "Todos")
                    return GestorSQL.BuscarProfesionales(txbBusqueda.Text, cmbBuscarPor.Text.ToLower());
                else
                    return GestorSQL.RecuperarProfesionales();

            }
            catch (BusquedaException ex)
            {
                MessageBox.Show(ex.Message);
            }
            return new List<Profesional>();
        }

        //private string ConvertirAtributo(string atributo)
        //{
        //    switch (atributo)
        //    {
        //        case "id turno":
        //            return "id";
                    
        //        case "documento paciente":
        //            return "documento";
        //            break;
        //        case "apellido profesional":
        //            {
        //                foreach (Turno turno in this.Turnos)
        //                {
        //                    if (turno.Profesional.Apellido.Contains(busqueda))
        //                        coincidencias.Add(turno);
        //                }
        //            }
        //            break;
        //        case "todos":
        //            coincidencias.AddRange(this.Turnos);
        //            break;
        //    }

        //}


        /// <summary>
        /// Busca los turnos que coincidan con la busqueda
        /// </summary>
        /// <param name="busqueda"></param>
        /// <returns>Los turnos que coincidan con la busqueda, o lista vacia si ocurrio un error. </returns>
        /// <exception cref="BusquedaException">Si ocurrio un error al buscar los turnos</exception>
        private List<Turno> BuscarTurnos(string busqueda)
        {
            try
            {
                //todo Hacer Busqueda de turnos sql
                if (busqueda == "Futuros")
                {
                    return GestorSQL.BuscarTurnosFuturos(txbBusqueda.Text, cmbBuscarPor.Text.ToLower());
                }
                else if (busqueda == "Pasados")
                {
                    return this.centroMedico.BuscarTurnosPasados(txbBusqueda.Text, cmbBuscarPor.Text);
                }
                else
                {                    
                    return this.centroMedico.BuscarTurnos(txbBusqueda.Text, cmbBuscarPor.Text);
                }
            }
            catch (BusquedaException e)
            {
                MessageBox.Show(e.Message);
                return new List<Turno>();
            }
        }

        /// <summary>
        /// Busca las entidades segun con que funcion se haya abierto el formulario.
        /// </summary>        
        private void Buscar()
        {
            try
            {
                if (txbBusqueda.Text != "" || cmbBuscarPor.Text == "Todos")
                {
                    if (!abrirFuncionTurnos && abrirFuncionPaciente)
                        this.coincidenciasPacientes = this.BuscarPacientes();
                    else if (!abrirFuncionTurnos && !abrirFuncionPaciente)
                        this.coincidenciasProfesionales = this.BuscarProfesionales();
                    else
                        this.coincidenciasTurnos = this.BuscarTurnos(cmbBuscarTurnos.Text);

                    this.MostrarCoincidencias();
                }
                else
                    OcultarBotones();

            }
            catch (BusquedaException e)
            {
                MessageBox.Show(e.Message);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        /// <summary>
        /// Muestra las coincidencias de la busqueda
        /// </summary>        
        private void MostrarCoincidencias()
        {
            try
            {

                if ((coincidenciasPacientes.Count > 0 || coincidenciasProfesionales.Count > 0 || coincidenciasTurnos.Count > 0)
                    && (txbBusqueda.Text.Length > 0 || cmbBuscarPor.Text == "Todos"))
                {
                    this.dgvCoincidencias.Visible = true;
                    this.dgvCoincidencias.BringToFront();

                    if (abrirFuncionTurnos)
                    {
                        this.CargarDiseñoColumnasTurnos();
                    }
                    else
                    {
                        this.CargarDiseñoColumnasPersonas();
                    }

                    this.MostrarBotones();
                }
                else
                {
                    this.dgvCoincidencias.Visible = false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al mostrar las coincidencias.");
            }
        }

        /// <summary>
        /// Muestra los botones segun la funcion del formulario.
        /// </summary>
        private void MostrarBotones()
        {
            if (!this.abrirFuncionTurnos)
            {
                this.BtnVerTurnos.Visible = true;

                if (!this.abrirFuncionPaciente)
                {
                    this.BtnModificarHorarios.Visible = true;
                }
                else
                {
                    this.btnNuevoTurno.Visible = true;
                }
            }
            else
            {
                this.BtnConfirmarTurno.Visible = true;
            }

            this.dgvCoincidencias.Visible = true;
            this.BtnEliminar.Visible = true;
            this.BtnModificar.Visible = true;
            this.BtnExportar.Visible = true;

        }

        /// <summary>
        /// Oculta los botones.
        /// </summary>
        private void OcultarBotones()
        {
            this.dgvCoincidencias.Visible = false;
            this.BtnEliminar.Visible = false;
            this.BtnModificar.Visible = false;
            this.BtnVerTurnos.Visible = false;
            this.BtnExportar.Visible = false;
            this.BtnConfirmarTurno.Visible = false;
            this.btnNuevoTurno.Visible = false;

            if (!this.abrirFuncionPaciente)
            {
                this.BtnModificarHorarios.Visible = false;
            }
        }
        /// <summary>
        /// Carga el diseño de las columnas del datagridview para las personas.
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void CargarDiseñoColumnasPersonas()
        {
            if (abrirFuncionPaciente)
            {
                this.dgvCoincidencias.DataSource = this.coincidenciasPacientes;
                this.dgvCoincidencias.Columns["NumeroAfiliado"].DisplayIndex = 6;
                this.dgvCoincidencias.Columns["NumeroAfiliado"].HeaderText = "N° Afiliado";
                this.dgvCoincidencias.Columns["ObraSocial"].HeaderText = "Obra Social";
                this.dgvCoincidencias.Columns["ObraSocial"].DisplayIndex = 5;
                this.dgvCoincidencias.Columns["TelefonoContacto"].Visible = false;
            }
            else
            {
                this.dgvCoincidencias.DataSource = this.coincidenciasProfesionales;
                this.dgvCoincidencias.Columns["Matricula"].DisplayIndex = 4;
            }
            this.dgvCoincidencias.Columns["Id"].DisplayIndex = 0;
            this.dgvCoincidencias.Columns["Documento"].DisplayIndex = 1;
            this.dgvCoincidencias.Columns["Nombre"].DisplayIndex = 2;
            this.dgvCoincidencias.Columns["Apellido"].DisplayIndex = 3;
            this.dgvCoincidencias.Columns["FechaDeNacimiento"].Visible = false;
            this.dgvCoincidencias.Columns["Telefono"].DisplayIndex = 4;
            this.dgvCoincidencias.Columns["Nacionalidad"].Visible = false;
        }

        /// <summary>
        /// Carga el diseño de las columnas para los turnos.
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void CargarDiseñoColumnasTurnos()
        {
            this.dgvCoincidencias.DataSource = this.coincidenciasTurnos;
            this.dgvCoincidencias.Columns["Id"].DisplayIndex = 0;
            this.dgvCoincidencias.Columns["Fecha"].DisplayIndex = 1;
            this.dgvCoincidencias.Columns["PacienteAsistio"].HeaderText = "Asistió";

            dgvCoincidencias.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
        }

        /// <summary>
        /// Abre un formulario para modificar el turno.
        /// </summary>
        /// <param name="turno"></param>
        private void AbrirModificarTurno(Turno turno)
        {
            FrmNuevoTurno FrmModificar = new FrmNuevoTurno(turno);
            FrmCentroSalud.Instancia().AbrirFormularioSecundario(FrmModificar);
        }

        /// <summary>
        /// Abre el formulario para modificar el paciente.
        /// </summary>
        /// <param name="paciente"></param>
        private void AbrirModificarPaciente(Paciente paciente)
        {
            FrmNuevaPersona FrmModificar = new FrmNuevaPersona(paciente);
            FrmCentroSalud.Instancia().AbrirFormularioSecundario(FrmModificar);
        }

        /// <summary>
        /// Abre el formulario para modificar el profesinoal.
        /// </summary>
        /// <param name="profesional"></param>
        private void AbrirModificarProfesional(Profesional profesional)
        {
            FrmNuevaPersona FrmModificar = new FrmNuevaPersona(profesional);
            FrmCentroSalud.Instancia().AbrirFormularioSecundario(FrmModificar);
        }

        /// <summary>
        /// Captura al paciente seleccionado por la columna documento.
        /// </summary>
        /// <returns></returns>
        private Paciente CapturarPacienteSeleccionado()
        {
            try
            {
                string documentoSeleccionado = dgvCoincidencias.CurrentRow.Cells["Documento"].Value.ToString();
                return coincidenciasPacientes.Find(a => a.Documento == documentoSeleccionado);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al buscar el paciente.");
            }

            return new Paciente();
        }

        /// <summary>
        /// Captura el profesional seleccionado por la columna documento.
        /// </summary>
        /// <returns></returns>
        private Profesional CapturarProfesionalSeleccionado()
        {
            try
            {                
                string documentoSeleccionado = dgvCoincidencias.CurrentRow.Cells["Documento"].Value.ToString();
                return coincidenciasProfesionales.Find(a => a.Documento == documentoSeleccionado);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al buscar el profesional.");
            }
            return new Profesional();
        }

        /// <summary>
        /// Captura el turno seleccionado por la columna Id
        /// </summary>
        /// <returns></returns>
        private Turno CapturarTurnoSeleccionado()
        {
            try
            {
                //todo Buscar turno
                string id = dgvCoincidencias.CurrentRow.Cells["id"].Value.ToString();
                return centroMedico.BuscarTurno(int.Parse(id));
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al seleccionar el turno");
            }

            return new Turno();
        }

        /// <summary>
        /// Elimina la persona seleccionada.
        /// </summary>
        private void EliminarPersona()
        {
            try
            {
                Persona persona;

                if (abrirFuncionPaciente)
                {
                    persona = this.CapturarPacienteSeleccionado();
                }
                else
                {
                    persona = this.CapturarProfesionalSeleccionado();
                }

                if (persona is not null)
                {
                    GestorSQL.EliminarPersona(persona);
                }

                this.Buscar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Elimina el turno seleccionado segun su Id.
        /// </summary>
        private void EliminarTurno()
        {
            try
            {
               GestorSQL.EliminarTurno(this.CapturarTurnoSeleccionado());
            }
            catch (TurnoNoExisteException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error al eliminar el turno");
            }
        }


        /// <summary>
        /// Exporta a la entidad seleccionada a .json y .xml
        /// </summary>
        private void Exportar()
        {
            try
            {
                string fullPath = FrmCentroSalud.Instancia().SeleccionarRutaGuardado();
                if (!abrirFuncionTurnos)
                {
                    Persona persona;

                    if (abrirFuncionPaciente)
                        persona = this.CapturarPacienteSeleccionado();
                    else
                        persona = this.CapturarProfesionalSeleccionado();


                    if (!string.IsNullOrEmpty(fullPath))
                        persona.Serializar(fullPath);
                }
                else
                {
                    Turno turno = this.CapturarTurnoSeleccionado();
                    if (!string.IsNullOrEmpty(fullPath))
                        turno.Serializar(fullPath);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al intentar exportar");
            }
        }

        /// <summary>
        /// Confirma el turno seleccionado.
        /// </summary>
        public void ConfirmarAsistenciaTurno()
        {
            try
            {
                //todo Busqueda turno

                Turno turno = this.CapturarTurnoSeleccionado();

                if (turno.Fecha < DateTime.Today || turno.Fecha.Date > DateTime.Today || turno.PacienteAsistio == true)
                {
                    MessageBox.Show("No se puede confirmar este turno.");
                }
                else
                {
                    turno.Confirmar();
                    MessageBox.Show("Turno confirmado");
                    this.Buscar();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo confirmar el turno");
            }
        }

        /// <summary>
        /// Abre el formulario para modificar la entidad.
        /// </summary>
        private void Modificar()
        {
            try
            {
                if (!abrirFuncionTurnos)
                {

                    if (abrirFuncionPaciente)
                    {
                        AbrirModificarPaciente(this.CapturarPacienteSeleccionado());
                    }
                    else
                    {
                        AbrirModificarProfesional(this.CapturarProfesionalSeleccionado());
                    }


                    dgvCoincidencias.Visible = false;
                    txbBusqueda.Text = "";
                }
                else
                {
                    int idSeleccionado = (int)dgvCoincidencias.CurrentRow.Cells["Id"].Value;
                    AbrirModificarTurno(centroMedico.BuscarTurno(idSeleccionado));
                }

            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo abrir el menu modificacion");
            }
        }

        /// <summary>
        /// Abre el formulario para ver los turnos de la persona.
        /// </summary>
        private void VerTurnos()
        {
            if (abrirFuncionPaciente)
            {
                FrmVerTurnos verTurnos = new FrmVerTurnos(this.CapturarPacienteSeleccionado());
                FrmCentroSalud.Instancia().AbrirFormularioSecundario(verTurnos);
            }
            else if (!abrirFuncionPaciente && !abrirFuncionTurnos)
            {
                FrmVerTurnos verTurnos = new FrmVerTurnos(this.CapturarProfesionalSeleccionado());
                FrmCentroSalud.Instancia().AbrirFormularioSecundario(verTurnos);
            }
        }



        //------------Eventos


        /// <summary>
        /// Evento que se ejecuta cuando se cambia el elemento seleccionado en cmbBuscarPor, modificando el texto de la etiqueta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBuscarPor_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                this.lblTextoBusqueda.Text = this.cmbBuscarPor.SelectedItem.ToString() + ":";
                this.txbBusqueda.Text = "";
                this.txbBusqueda.Visible = true;
                this.lblTextoBusqueda.Visible = true;

                if (cmbBuscarPor.Text == "Todos")
                {
                    this.Buscar();
                    this.txbBusqueda.Visible = false;
                    this.lblTextoBusqueda.Visible = false;
                }
            }
            catch (BusquedaException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Evento que se ejecuta al presionar el boton buscar, buscando por el texto ingresado en el textbox y mostrando los resultados.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBuscar_Click(object sender, EventArgs e)
        {
            this.Buscar();
        }


        /// <summary>
        /// Evento que se lanza para validar que las teclas presionadas sean las correctas.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbBusqueda_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!abrirFuncionTurnos)
            {
                switch (cmbBuscarPor.SelectedIndex)
                {
                    case 0:
                    case 2:
                        this.ValidarCampoChars(sender, e);
                        break;
                    case 1:
                    case 3:
                        this.ValidarCampoNumerico(sender, e);
                        break;
                }
            }
            else
            {
                switch (cmbBuscarPor.SelectedIndex)
                {
                    case 0:
                    case 2:
                        this.ValidarCampoNumerico(sender, e);
                        break;
                    case 1:
                        this.ValidarCampoChars(sender, e);
                        break;
                }
            }
        }

        /// <summary>
        /// Evento que se lanza para hacer una busqueda por el texto ingresado en el textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbBusqueda_KeyUp(object sender, KeyEventArgs e)
        {
            this.Buscar();
        }

        /// <summary>
        /// Evento que se lanza para hacer una busqueda por el texto ingresado en el textbox.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void txbBusqueda_Enter(object sender, EventArgs e)
        {
            this.Buscar();
        }

        /// <summary>
        /// Evento que se lanza al hacer doble click sobre una celda del dgvCoincidencias, abriendo la funcion modificar de dicha entidad.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCoincidencias_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.Modificar();
        }

        /// <summary>
        /// Evento que se lanza al hacer click sobre el boton, elimina la entidad seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!abrirFuncionTurnos)
                {
                    this.EliminarPersona();
                }
                else
                {
                    this.EliminarTurno();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            Buscar();
        }

        /// <summary>
        /// Evento que se lanza al darle formate a la celda haciendo que los nombres propios comiencen con mayuscula.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCoincidencias_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgvCoincidencias.Columns[e.ColumnIndex].Name == "Nombre" || dgvCoincidencias.Columns[e.ColumnIndex].Name == "Apellido")
            {
                if (e.Value != null)
                {
                    e.Value = e.Value.ToString().TotUpperFirstLetter();
                    e.FormattingApplied = true;
                }
            }
        }

        /// <summary>
        /// Evento que se lanza para exportar la entidad seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnExportar_Click(object sender, EventArgs e)
        {
            this.Exportar();
        }

        /// <summary>
        /// Evento que lanza un nuevo formulario para modificar los horarios del profesional seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificarHorarios_Click(object sender, EventArgs e)
        {
            FrmCentroSalud.Instancia().AbrirFormularioSecundario(new FrmSeleccionarHorariosAtencion(this.CapturarProfesionalSeleccionado()));
        }

        /// <summary>
        /// Evento que se lanza al cambiar el indice seleccionado, alterando la visibilidad segun sea necesario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmbBuscarTurnos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBuscarTurnos.Text == "Pasados")
            {
                BtnModificar.Visible = false;
                BtnConfirmarTurno.Visible = false;
            }

            this.Buscar();
        }

        /// <summary>
        /// Confirma el turno seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfirmarTurno_Click(object sender, EventArgs e)
        {
            this.ConfirmarAsistenciaTurno();
        }

        /// <summary>
        /// Abre un nuevo formulario para realizar un nuevo turno con el paciente seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnNuevoTurno_Click(object sender, EventArgs e)
        {
            FrmCentroSalud.Instancia().AbrirFormularioSecundario(new FrmNuevoTurno(this.CapturarPacienteSeleccionado()));
        }

        /// <summary>
        /// Abre la funcion modificar de la entidad seleccionada.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnModificar_Click(object sender, EventArgs e)
        {
            this.Modificar();
        }

        /// <summary>
        /// Abre un nuevo formulario para ver los turnos de la entidad.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnVerTurnos_Click(object sender, EventArgs e)
        {
            this.VerTurnos();
        }

        /// <summary>
        /// Metodo que interviene en algunos errores del dgvCoincidencias.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvCoincidencias_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
        }
    }
}
