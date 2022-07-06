using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;
using Entidades.Exceptions;

namespace Formularios
{
    public partial class FrmCentroSalud : Form
    {
        private static FrmCentroSalud instancia;

        private CentroMedico centroMedico;

        private OpenFileDialog openFile;
        private SaveFileDialog saveFile;

        private string pathAutoGuardado;
        private bool autoGuardado;
        private bool guardarEnBaseDeDatos;
        private bool guardadoLocal;
        private bool origenDeDatosLocal;
        private bool error = false;

        public string PathAutoGuardado { get => pathAutoGuardado; set => pathAutoGuardado = value; }
        public bool AutoGuardado { get => autoGuardado; set => autoGuardado = value; }
        public bool GuardarEnBaseDeDatos { get => guardarEnBaseDeDatos; set => guardarEnBaseDeDatos = value; }
        public bool GuardadoLocal { get => guardadoLocal; set => guardadoLocal = value; }
        public bool OrigenDeDatosLocal { get => origenDeDatosLocal; set => origenDeDatosLocal = value; }

        /// <summary>
        /// Si no esta inicializada la instancia de la clase, la instancia, sino simplemente la retorna.
        /// </summary>
        /// <returns>Retorna la unica instancia de la clase.</returns>
        public static FrmCentroSalud Instancia()
        {
            if (FrmCentroSalud.instancia is null)
                FrmCentroSalud.instancia = new FrmCentroSalud();

            return FrmCentroSalud.instancia;
        }

        /// <summary>
        /// Constructor de la clase, unicamente llamada por el metodo Instancia, carga todo lo necesario para el correcto funcionamiento.
        /// </summary>
        private FrmCentroSalud()
        {
            InitializeComponent();

            this.centroMedico = CentroMedico.Instanciar("Centro Medico");

        }

        /// <summary>
        /// Inicializa los fileDialogs y les carga las unicas posibles extensiones.
        /// </summary>
        public void InicializarFileDialogs()
        {
            this.openFile = new OpenFileDialog();
            this.saveFile = new SaveFileDialog();

            this.saveFile.Filter = "Archivo JSON |*.json|Archivo XML |*.xml";
            this.openFile.Filter = "Archivo JSON |*.json|Archivo XML |*.xml";
        }


        #region Diseño

        /// <summary>
        /// Carga el diseño inicial del programa, con los menus laterales ocultos.
        /// </summary>
        private void CargarDiseño()
        {
            this.pnlLogo.Visible = false;
            this.pnlArchivosSubMenu.Visible = false;
            this.pnlPacientesSubMenu.Visible = false;
            this.pnlProfesionalesSubMenu.Visible = false;
            this.pnlTurnosSubMenu.Visible = false;
            this.pnlConfiguracionSubMenu.Visible = false;
        }

        /// <summary>
        /// Cambia la visibilidad del submenu enviado por parametro, si era true, pasa a false y viceversa
        /// </summary>
        /// <param name="subMenu"></param>
        private static void CambiarVisibilidadSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
                subMenu.Visible = true;
            else
                subMenu.Visible = false;
        }

        /// <summary>
        /// Cierra todos los submenus.
        /// </summary>
        private void CerrarSubMenus()
        {
            if (pnlArchivosSubMenu.Visible == true)
                pnlArchivosSubMenu.Visible = false;
            if (pnlPacientesSubMenu.Visible == true)
                pnlPacientesSubMenu.Visible = false;
            if (pnlTurnosSubMenu.Visible == true)
                pnlTurnosSubMenu.Visible = false;
            if (pnlProfesionalesSubMenu.Visible == true)
                pnlProfesionalesSubMenu.Visible = false;
            if (pnlConfiguracionSubMenu.Visible == true)
                pnlConfiguracionSubMenu.Visible = false;
        }

        /// <summary>
        /// Actualiza la cantidad de personas en el menu principal y si hay algun cambio de nombre.
        /// </summary>
        public void ActualizarMenuPrincipal()
        {
            if (this.InvokeRequired)
            {
                Action action = ActualizarMenuPrincipal;
                lblReloj.Invoke(action);
            }
            else
            {
                this.lblCantidadPacientes.Text = $"Cantidad pacientes: {this.centroMedico.Pacientes.Count}";
                this.lblCantidadProfesionales.Text = $"Cantidad profesionales: {this.centroMedico.Profesionales.Count}";
                this.lblNombre.Text = this.centroMedico.Nombre;
            }

        }

        /// <summary>
        /// Actualiza el label que contiene el nombre del centro.
        /// </summary>
        public void ActualizarNombre()
        {
            this.lblNombre.Text = this.centroMedico.Nombre;
            this.Text = this.centroMedico.Nombre;
        }


        #endregion


        /// <summary>
        /// Abre el formulario secundario enviado por parametro.
        /// </summary>
        /// <param name="formulario">Formulario a ser abierto</param>        
        public void AbrirFormularioSecundario(FrmSecundario formulario)
        {
            if (formulario != null)
            {
                if (formulario is not FrmSeleccionarHorariosAtencion)
                    this.CerrarFormulariosAbiertos();

                formulario.TopLevel = false;
                formulario.FormBorderStyle = FormBorderStyle.None;
                formulario.Dock = DockStyle.Fill;
                formulario.WindowState = FormWindowState.Maximized;
                this.pnlContenedor.Controls.Add(formulario);
                this.pnlContenedor.Tag = formulario;
                formulario.Show();
                formulario.BringToFront();
            }
        }

        /// <summary>
        /// Cierra los formularios abiertos dentro de pnlContenedor.
        /// </summary>
        private void CerrarFormulariosAbiertos()
        {

            foreach (Control control in this.pnlContenedor.Controls)
            {
                if (control is FrmSecundario)
                {
                    control.Dispose();
                    this.pnlContenedor.Controls.Remove(control);
                }
            }
        }
        /// <summary>
        /// Abre el saveFileDialog del formulario para el guardado, permitiendo .xml y .json como extension.
        /// </summary>
        /// <returns>El path y extension del archivo./returns>
        public string SeleccionarRutaGuardado()
        {
            if (this.saveFile.ShowDialog() == DialogResult.OK)
                return this.saveFile.FileName;

            return string.Empty;
        }

        /// <summary>
        /// Abre el openFileDialog del formulario para la apertura de un archivo .xml o .json.
        /// </summary>
        /// <returns></returns>
        public string SeleccionarRutaArchivo()
        {
            if (this.openFile.ShowDialog() == DialogResult.OK)
                return this.openFile.FileName;

            return string.Empty;
        }

        /// <summary>
        /// Guarda el autoguardado y la direccion de este en el directorio donde se esta ejecutando el programa.
        /// </summary>
        /// <exception cref="Exception"></exception>
        private void GuardarConfiguracion()
        {
            GestorDeArchivos.GuardarArchivo($"{Directory.GetCurrentDirectory()}.cds", $"{this.AutoGuardado},{this.GuardadoLocal},{this.GuardarEnBaseDeDatos},{this.OrigenDeDatosLocal},{this.PathAutoGuardado}");
        }

        /// <summary>
        /// Carga la configuracion del programa.
        /// </summary>
        private void CargarConfiguracion()
        {
            try
            {
                string lectura = GestorDeArchivos.LeerArchivo($"{Directory.GetCurrentDirectory()}.cds");

                if (!string.IsNullOrEmpty(lectura))
                {
                    string[] datos = lectura.Split(',', '\r');
                    this.AutoGuardado = bool.Parse(datos[0]);
                    this.GuardadoLocal = bool.Parse(datos[1]);
                    this.GuardarEnBaseDeDatos = bool.Parse(datos[2]);
                    this.OrigenDeDatosLocal = bool.Parse(datos[3]);
                    this.PathAutoGuardado = datos[4];
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al abrir el archivo de configuracion.");
            }
        }


        /// <summary>
        /// Recupera el centro medico segun la configuracion guardada en el archivo de configuracion.
        /// </summary>
        private void RecuperarCentroMedico()
        {
            if (this.AutoGuardado && this.origenDeDatosLocal && !string.IsNullOrEmpty(this.PathAutoGuardado))
                this.centroMedico.ImportarCentroMedico(this.PathAutoGuardado);
            else if (this.AutoGuardado && !this.origenDeDatosLocal)
                this.RecuperarCentroMedicoSQL();
        }

        /// <summary>
        /// Recupera el centro medico desde la base de datos.
        /// </summary>
        private void RecuperarCentroMedicoSQL()
        {
            GestorSQL.OnRecuperarException += this.RecuperarCentroMedicoException;
            Task.Run(() => GestorSQL.RecuperarCentroMedico(centroMedico));

        }

        /// <summary>
        /// Guarda el centro medico en la base de datos.
        /// </summary>
        /// <returns></returns>
        private bool GuardarCentroMedicoSQL()
        {
            if (!error)
            {
                GestorSQL.OnGuardarException += this.RecuperarCentroMedicoException;
                return GestorSQL.GuardarCentroMedico(centroMedico);
            }
            return false;
        }

        /// <summary>
        /// Metodo que controla el evento de excepcion al momento de cargar el centro medico.
        /// </summary>
        private void RecuperarCentroMedicoException()
        {
            if (this.InvokeRequired)
            {
                Action delegado = RecuperarCentroMedicoException;
                this.Invoke(delegado);
            }
            else
            {
                MessageBox.Show("Ocurrió un error al recuperar el centro medico.");
                error = true;
            }
        }

        /// <summary>
        /// Metodo que controla el evento de exepcion al momento de guardar el centor medico.
        /// </summary>
        private void GuardarCentroMedicoException()
        {
            if (this.InvokeRequired)
            {
                Action delegado = GuardarCentroMedicoException;
                this.Invoke(delegado);
            }
            else
            {
                MessageBox.Show("Ocurrió un error al guardar el centro medico.");
            }
        }


        #region eventos

        #region botones



        #region botones Titulares

        /// <summary>
        /// Despliega/oculta la lista de opciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnPacientesSubMenu_Click(object sender, EventArgs e)
        {
            CambiarVisibilidadSubMenu(pnlPacientesSubMenu);
        }

        /// <summary>
        /// Despliega/oculta la lista de opciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnTurnosSubMenu_Click(object sender, EventArgs e)
        {
            CambiarVisibilidadSubMenu(pnlTurnosSubMenu);
        }

        /// <summary>
        /// Despliega/oculta la lista de opciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnProfesionalesSubMenu_Click(object sender, EventArgs e)
        {
            CambiarVisibilidadSubMenu(pnlProfesionalesSubMenu);
        }

        /// <summary>
        /// Despliega/oculta la lista de opciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOtrosSubMenu_Click(object sender, EventArgs e)
        {
            CambiarVisibilidadSubMenu(pnlArchivosSubMenu);
        }

        /// <summary>
        /// Despliega/oculta la lista de opciones.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConfiguracionSubMenu_Click(object sender, EventArgs e)
        {
            CambiarVisibilidadSubMenu(pnlConfiguracionSubMenu);
        }
        #endregion

        #region pacientes

        /// <summary>
        /// Abre un formulario para crear un nuevo paciente en el pnlContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNuevoPaciente_Click(object sender, EventArgs e)
        {
            this.AbrirFormularioSecundario(new FrmNuevaPersona(true, "Nuevo paciente"));
            this.CerrarSubMenus();
        }

        /// <summary>
        /// Abre un formulario para crear un buscar pacientes en el pnlContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBuscarPaciente_Click(object sender, EventArgs e)
        {
            this.AbrirFormularioSecundario(new FrmBuscar(true, "Buscar paciente"));
            this.CerrarSubMenus();
        }
        #endregion

        #region turnos

        /// <summary>
        /// Abre un formulario para ver los turnos en el pnlContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnVerTurnos_Click(object sender, EventArgs e)
        {
            this.AbrirFormularioSecundario(new FrmVerTurnos());
            this.CerrarSubMenus();
        }

        /// <summary>
        /// Abre un formulario para crear un nuevo turno, buscando primero al paciente en el pnlContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNuevoTurno_Click(object sender, EventArgs e)
        {
            this.AbrirFormularioSecundario(new FrmBuscar(true, "Buscar paciente"));
            CerrarSubMenus();
        }

        /// <summary>
        /// Abre un formulario para buscar turnos en el pnlContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBuscarTurno_Click(object sender, EventArgs e)
        {
            this.AbrirFormularioSecundario(new FrmBuscar(true));
            CerrarSubMenus();
        }
        #endregion

        #region profesionales
        /// <summary>
        /// Abre un formulario para crear un nuevo profesional en el pnlContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnNuevoProfesional_Click(object sender, EventArgs e)
        {
            AbrirFormularioSecundario(new FrmNuevaPersona(false, "Nuevo profesional"));
            CerrarSubMenus();
        }

        /// <summary>
        /// Abre un formulario para buscar profesional en el pnlContenedor
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnBuscarProfesional_Click(object sender, EventArgs e)
        {
            AbrirFormularioSecundario(new FrmBuscar(false, "Buscar profesional"));
            CerrarSubMenus();
        }

        #endregion

        #region Importar

        /// <summary>
        /// Exporta el centro medico segun el usuario desee.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGuardarCentro_Click(object sender, EventArgs e)
        {
            try
            {
                string fullPath = this.SeleccionarRutaGuardado();
                if (!string.IsNullOrEmpty(fullPath))
                    centroMedico.SerializarToJSON(fullPath);
            }
            catch (SerializarException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Exporta todos los pacientes del centro medico segun el usuario desee.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGuardarPacientes_Click(object sender, EventArgs e)
        {
            try
            {
                string fullPath = this.SeleccionarRutaGuardado();
                if (!string.IsNullOrEmpty(fullPath))
                {
                    centroMedico.GuardarPacientes(fullPath);
                    MessageBox.Show("Se exportaron correctamente los pacientes.");
                }
            }
            catch (SerializarException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Importa una lista de pacientes desde el path seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnImportarPacientes_Click(object sender, EventArgs e)
        {
            try
            {
                string fullPath = this.SeleccionarRutaArchivo();
                if (!string.IsNullOrEmpty(fullPath))
                {
                    int cantidadImportados = centroMedico.ImportarPacientes(fullPath);
                    MessageBox.Show($"Se importaron {cantidadImportados} pacientes");
                    this.CerrarFormulariosAbiertos();
                }

            }
            catch (DeserializarException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error.");
            }

        }

        /// <summary>
        /// Importa una lista de profesionales desde el path seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnImportarProfesionales_Click(object sender, EventArgs e)
        {
            try
            {
                string fullPath = this.SeleccionarRutaArchivo();
                if (!string.IsNullOrEmpty(fullPath))
                {
                    int cantidadImportados = centroMedico.ImportarProfesionales(fullPath);
                    MessageBox.Show($"Se importaron {cantidadImportados} profesionales");
                    this.CerrarFormulariosAbiertos();
                }
            }
            catch (DeserializarException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Guarda todos los profesionales del centor medico en el path seleccionado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGuardarProfesionales_Click(object sender, EventArgs e)
        {
            try
            {
                string fullPath = this.SeleccionarRutaGuardado();
                if (!string.IsNullOrEmpty(fullPath))
                {
                    centroMedico.GuardarProfesionales(fullPath);
                    MessageBox.Show($"Se guardaron correctamente los profesionales.");
                }

            }
            catch (SerializarException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Importa todos los datos de un centro medico, reemplazando los existentes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnImportarCentro_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("Al hacer esto, se eliminaran todos los datos del centro medico actual. Desea continuar?", "Alerta", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning))
            {
                try
                {
                    string fullPath = this.SeleccionarRutaArchivo();
                    if (!string.IsNullOrEmpty(fullPath))
                    {
                        centroMedico.ImportarCentroMedico(fullPath);
                        MessageBox.Show("Se importó el Centro Medico Correctamente");
                        this.CerrarFormulariosAbiertos();
                    }
                }
                catch (DeserializarException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Se canceló la importación del centro medico. Los datos siguen a salvo.");
            }
        }

        #endregion

        #region Configuracion
        /// <summary>
        /// Abre el formulario de configuracion del centro medico.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            this.AbrirFormularioSecundario(new FrmConfiguracion());
        }

        #endregion

        #endregion


        /// <summary>
        /// Al cerrar el programa, guarda la configuración de autoguardado y la dirección donde se guardan los datos del centro medico.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="Exception"></exception>
        private void FrmCentroSalud_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (this.AutoGuardado && this.GuardadoLocal)
                    this.centroMedico.GuardarCentroMedico(this.PathAutoGuardado);
                
                if (this.autoGuardado && this.GuardarEnBaseDeDatos)
                    this.GuardarCentroMedicoSQL();

                this.GuardarConfiguracion();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error al cerrar el programa.");
            }
        }
        #endregion

        public void AsignarTiempo(Reloj reloj)
        {
            if (lblReloj.InvokeRequired)
            {
                Action<Reloj> delegado = AsignarTiempo;
                lblReloj.Invoke(delegado, reloj);
            }
            else
            {
                lblReloj.Text = reloj.ToString(false);
                label1.Text = reloj.ToString(true);
            }
        }

        /// <summary>
        /// Carga el diseño
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmCentroSalud_Load(object sender, EventArgs e)
        {
            this.Text = centroMedico.Nombre;
            this.CargarDiseño();
            this.ActualizarNombre();
            this.InicializarFileDialogs();
            this.CargarConfiguracion();
            this.RecuperarCentroMedico();
            this.centroMedico.OnCambioRealizado += this.ActualizarMenuPrincipal;


            Reloj reloj = new Reloj();
            reloj.OnNotificarCambio += this.AsignarTiempo;
            reloj.Iniciar();
        }

    }
}

