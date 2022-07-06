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
using Entidades.Models;

namespace Formularios
{
    public partial class FrmConfiguracion : FrmSecundario
    {
        private SaveFileDialog saveFile;

        public FrmConfiguracion() : base("Configuración")
        {
            InitializeComponent();
            this.saveFile = new SaveFileDialog();
            this.saveFile.Filter = "Archivo JSON |*.json|Archivo XML |*.xml";
        }

        public bool AutoGuardado { get => FrmCentroSalud.Instancia().AutoGuardado; set => FrmCentroSalud.Instancia().AutoGuardado = value; }
        public string PathAutoguardado { get => FrmCentroSalud.Instancia().PathAutoGuardado; set => FrmCentroSalud.Instancia().PathAutoGuardado = value; }

        public bool GuardarEnBaseDeDatos { get => FrmCentroSalud.Instancia().GuardarEnBaseDeDatos; set => FrmCentroSalud.Instancia().GuardarEnBaseDeDatos = value; }

        public bool GuardadoLocal { get => FrmCentroSalud.Instancia().GuardadoLocal; set => FrmCentroSalud.Instancia().GuardadoLocal = value; }

        public bool OrigenDeDatosLocal { get => FrmCentroSalud.Instancia().OrigenDeDatosLocal; set => FrmCentroSalud.Instancia().OrigenDeDatosLocal = value; }


        /// <summary>
        /// Carga los datos de la configuración en los controles
        /// </summary>
        public void CargarConfiguracionAutoGuardado()
        {
            if (this.AutoGuardado)
            {
                BtnAutoGuardado.ImageIndex = 0;
                CambiarVisibilidadGuardadoEn();

                if (this.GuardadoLocal)
                {
                    this.btnGuardadoLocal.ImageIndex = 0;
                    this.txtDirectorio.Text = this.PathAutoguardado;
                    this.cmbOrigenDeDatos.Items.Add("Archivo local");

                    CambiarVisibilidadDirectorio(true);
                }

                if(this.GuardarEnBaseDeDatos)
                {
                    this.btnGuardarEnBaseDeDatos.Visible = true;
                    this.btnGuardarEnBaseDeDatos.ImageIndex = 0;
                    this.cmbOrigenDeDatos.Items.Add("Base de datos");
                }

                if (this.OrigenDeDatosLocal)
                    this.cmbOrigenDeDatos.SelectedItem = "Archivo local";
                else
                    this.cmbOrigenDeDatos.SelectedItem = "Base de datos";
                
            }
            else
            {
                BtnAutoGuardado.ImageIndex = 1;
                CambiarVisibilidadDirectorio(false);
            }
        }

        /// <summary>
        /// Cambia la visibilidad del directorio de guardado
        /// </summary>
        /// <param name="visibilidad"></param>
        public void CambiarVisibilidadDirectorio(bool visibilidad)
        {

            lblUbicacion.Visible = visibilidad;
            txtDirectorio.Visible = visibilidad;
            BtnSeleccionarDirectorio.Visible = visibilidad;
        }

        /// <summary>
        /// Cambia la visibilidad de controles de guardado
        /// </summary>
        private void CambiarVisibilidadGuardadoEn()
        {
            if (this.AutoGuardado == true)
            {
                lblGuardarEnBaseDeDatos.Visible = true;
                lblGuardadoLocal.Visible = true;
                btnGuardadoLocal.Visible = true;
                btnGuardarEnBaseDeDatos.Visible = true;
                lblOrigenDeDatos.Visible = true;
                cmbOrigenDeDatos.Visible = true;                
            }
            else
            {
                lblGuardarEnBaseDeDatos.Visible = false;
                lblGuardadoLocal.Visible = false;
                btnGuardadoLocal.Visible = false;
                btnGuardarEnBaseDeDatos.Visible = false;
                lblOrigenDeDatos.Visible = false;
                cmbOrigenDeDatos.Visible = false;                
            }
        }


        /// <summary>
        /// Modifica la visibilidad de los controles segun sea necesario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAutoGuardado_Click(object sender, EventArgs e)
        {
            if (BtnAutoGuardado.ImageIndex == 1)
            {
                BtnAutoGuardado.ImageIndex = 0;
                this.CambiarVisibilidadDirectorio(true);
                this.CambiarVisibilidadGuardadoEn();
            }
            else
            {
                BtnAutoGuardado.ImageIndex = 1;
                this.CambiarVisibilidadDirectorio(false);
                this.CambiarVisibilidadGuardadoEn();
            }
        }

        /// <summary>
        /// Abre una ventana para seleccionar un directorio de guardado.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnSeleccionarDirectorio_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == saveFile.ShowDialog())
            {
                this.PathAutoguardado = saveFile.FileName;
                this.txtDirectorio.Text = PathAutoguardado;
            }
        }
        
        /// <summary>
        /// Actualiza el nombre del centro medico.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnGuardarNombre_Click(object sender, EventArgs e)
        {
            CentroMedico.Instancia.Nombre = txtNombreCentro.Text;
            FrmCentroSalud.Instancia().ActualizarNombre();            
        }

        /// <summary>
        /// Carga toda la configuracion del centro medico.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmConfiguracion_Load(object sender, EventArgs e)
        {
            this.CargarConfiguracionAutoGuardado();
            this.txtNombreCentro.Text = this.centroMedico.Nombre;
            this.cmbEspecialidades.DataSource = this.centroMedico.ListaEspecialidades;            
            this.ActualizarHorario();
        }

        /// <summary>
        /// Actualiza el horario del centro medico.
        /// </summary>
        public void ActualizarHorario()
        {
            this.lblHorarioDelCentro.Text = this.centroMedico.DiasDeAtencion.ToString();
        }

        /// <summary>
        /// Abre un nuevo formulario para seleccionar los horarios del centro medico.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCambiarHorarios_Click(object sender, EventArgs e)
        {
            FrmSeleccionarHorariosAtencion horarios = new FrmSeleccionarHorariosAtencion(centroMedico);
            horarios.OnModificacionRealizada += ActualizarHorario;
            FrmCentroSalud.Instancia().AbrirFormularioSecundario(horarios);
        }

        /// <summary>
        /// Agrega una especialidad a la lista de especialidades del centro si esta ya no existe.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnAgregarEspecialidad_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.centroMedico.AgregarEspecialidad(this.txtAgregarEspecialidad.Text))
                {
                    cmbEspecialidades.DataSource = null;
                    cmbEspecialidades.DataSource = this.centroMedico.ListaEspecialidades;
                    cmbEspecialidades.SelectedItem = txtAgregarEspecialidad.Text;
                    txtAgregarEspecialidad.Text = "";
                    MessageBox.Show("Especialidad agregada correctamente");
                }
                else
                {
                    MessageBox.Show("Especialidad ya existe");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Elimina una especialidad de la lista de especialidades del centro medico.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnEliminarEspecialidad_Click(object sender, EventArgs e)
        {
            this.centroMedico.ListaEspecialidades.RemoveAt(this.cmbEspecialidades.SelectedIndex);
            cmbEspecialidades.DataSource = null;
            cmbEspecialidades.DataSource = this.centroMedico.ListaEspecialidades;
            MessageBox.Show("Especialidad eliminada correctamente");
        }


        /// <summary>
        /// Modifica los controles para la configuracion del guardado de los datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardarEnBaseDeDatos_Click(object sender, EventArgs e)
        {
            if (btnGuardarEnBaseDeDatos.ImageIndex == 1)
            {
                btnGuardarEnBaseDeDatos.ImageIndex = 0;
                cmbOrigenDeDatos.Items.Add("Base de datos");
            }
            else
            {
                btnGuardarEnBaseDeDatos.ImageIndex = 1;
                cmbOrigenDeDatos.Items.Remove("Base de datos");
            }

        }

        /// <summary>
        /// Modifica los controles para la configuracion del guardado de los datos.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnGuardadoLocal_Click(object sender, EventArgs e)
        {
            if (btnGuardadoLocal.ImageIndex == 1)
            {
                btnGuardadoLocal.ImageIndex = 0;
                cmbOrigenDeDatos.Items.Add("Archivo local");
                this.CambiarVisibilidadDirectorio(true);
            }
            else
            {
                btnGuardadoLocal.ImageIndex = 1;
                cmbOrigenDeDatos.Items.Remove("Archivo local");
                this.CambiarVisibilidadDirectorio(false);
            }

        }

        /// <summary>
        /// Verifica que la configuracion de guardado sea correcta y que no falte ningun dato
        /// </summary>
        /// <returns></returns>
        private bool VerificarGuardado()
        {
            if (BtnAutoGuardado.ImageIndex == 0 && 
                ((btnGuardadoLocal.ImageIndex == 0 && txtDirectorio.Text != "") || btnGuardadoLocal.ImageIndex == 1) && 
                (btnGuardadoLocal.ImageIndex == 0 || btnGuardarEnBaseDeDatos.ImageIndex == 0) && cmbOrigenDeDatos.SelectedIndex != -1)
                return true;
            else
                return false;
        }


        /// Guarda la configuracion de guardado.
        private void btnConfirmarGuardaro_Click(object sender, EventArgs e)
        {
            if (BtnAutoGuardado.ImageIndex == 1)
            {
                this.AutoGuardado = false;
                MessageBox.Show("Guardado realizado con exito.");
            }
            else if (VerificarGuardado())
            {

                if (BtnAutoGuardado.ImageIndex == 0)
                    this.AutoGuardado = true;
                else
                    this.AutoGuardado = false;

                if (btnGuardadoLocal.ImageIndex == 0)
                {
                    this.GuardadoLocal = true;
                    this.PathAutoguardado = txtDirectorio.Text;
                }
                else
                {
                    this.GuardadoLocal = false;
                    this.PathAutoguardado = "";
                }

                if (btnGuardarEnBaseDeDatos.ImageIndex == 0)
                    this.GuardarEnBaseDeDatos = true;
                else
                    this.GuardarEnBaseDeDatos = false;

                if (cmbOrigenDeDatos.SelectedItem == "Archivo local")
                    this.OrigenDeDatosLocal = true;
                else
                    this.OrigenDeDatosLocal = false;

                MessageBox.Show("Guardado realizado con exito.");

            }
            else
            {
                MessageBox.Show("Por favor complete los campos correctamente.");
            }
        }
    }
}
