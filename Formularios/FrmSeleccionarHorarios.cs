using Entidades;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Formularios
{
    public partial class FrmSeleccionarHorariosAtencion : FrmSecundario
    {
        private bool funcionProfesional;
        private Profesional profesionalIngresado;
        private CentroMedico centroMedicoIngresado;
        private bool modificado;
        public event Action OnModificacionRealizada;

        public FrmSeleccionarHorariosAtencion(DiasDeAtencion diasDeAtencion) : base("Seleccion de horarios")
        {
            InitializeComponent();
            this.InicializarCmbDesde();
            this.CargarDias(diasDeAtencion);
            this.modificado = false;
        }

        public FrmSeleccionarHorariosAtencion(Profesional profesional) : base("Seleccion de horarios")
        {
            InitializeComponent();
            funcionProfesional = true;
            this.InicializarCmbDesde();

            this.profesionalIngresado = profesional;
            this.CargarDias(profesional.DiasDeAtencion);
            this.OcultarDiasNoAtendidos();
        }

        public FrmSeleccionarHorariosAtencion(CentroMedico centro) : this(centro.DiasDeAtencion)
        {
            funcionProfesional = false;
            this.centroMedicoIngresado = centro;
        }


        //Carga de cmb

        /// <summary>
        /// Inicializa los ComboBox Desde con los horarios de la clase Horario.
        /// </summary>
        private void InicializarCmbDesde()
        {
            foreach (Control control in this.Controls)
            {
                if (control is ComboBox && control.Name.Contains("Desde"))
                {
                    ((ComboBox)control).DataSource = new Horario().Horarios;
                }
            }

        }

        private void CargarDias(DiasDeAtencion diasDeAtencion)
        {
            if (funcionProfesional)
            {
                this.LimitarHorarioDesde(cmbDesdeLunes, cmbHastaLunes, "lunes");
                this.LimitarHorarioDesde(cmbDesdeMartes, cmbHastaMartes, "martes");
                this.LimitarHorarioDesde(cmbDesdeMiercoles, cmbHastaMiercoles, "miercoles");
                this.LimitarHorarioDesde(cmbDesdeJueves, cmbHastaJueves, "jueves");
                this.LimitarHorarioDesde(cmbDesdeViernes, cmbHastaViernes, "viernes");
                this.LimitarHorarioDesde(cmbDesdeSabado, cmbHastaSabado, "sabado");
                this.LimitarHorarioDesde(cmbDesdeDomingo, cmbHastaDomingo, "domingo");
            }

            this.CargarDia(cmbDesdeLunes, cmbHastaLunes, diasDeAtencion.Lunes, this.cbxLunes);
            this.CargarDia(cmbDesdeMartes, cmbHastaMartes, diasDeAtencion.Martes, this.cbxMartes);
            this.CargarDia(cmbDesdeMiercoles, cmbHastaMiercoles, diasDeAtencion.Miercoles, this.cbxMiercoles);
            this.CargarDia(cmbDesdeJueves, cmbHastaJueves, diasDeAtencion.Jueves, this.cbxJueves);
            this.CargarDia(cmbDesdeViernes, cmbHastaViernes, diasDeAtencion.Viernes, this.cbxViernes);
            this.CargarDia(cmbDesdeSabado, cmbHastaSabado, diasDeAtencion.Sabado, this.cbxSabado);
            this.CargarDia(cmbDesdeDomingo, cmbHastaDomingo, diasDeAtencion.Domingo, this.cbxDomingo);
        }

        private void CargarDia(ComboBox cmbDesde, ComboBox cmbHasta, HorarioDeAtencion dia, CheckBox check)
        {

            if (dia.Atiende && !dia.EsPorDefecto)
            {
                cmbDesde.SelectedIndex = cmbDesde.Items.IndexOf(dia.Desde);

                this.CargarHorariosPosiblesCmbHasta(cmbDesde, cmbHasta);

                cmbHasta.SelectedIndex = cmbHasta.Items.IndexOf(dia.Hasta);
                check.Checked = true;

            }
            else if (dia.Atiende)
            {
            }
            else
            {
                cmbDesde.SelectedIndex = -1;
                cmbHasta.SelectedIndex = -1;
                cmbDesde.Enabled = false;
                cmbHasta.Enabled = false;
                check.Checked = false;
            }

        }

        /// <summary>
        /// Oculta los ComboBox de dias que no atienda el centro medico.
        /// </summary>
        private void OcultarDiasNoAtendidos()
        {
            try
            {
                for (int i = 1; i <= 7; i++)
                {
                    if (!centroMedico.DiasDeAtencion[i].Atiende)
                    {
                        string dia = centroMedico.DiasDeAtencion.dias[i];

                        foreach (Control control in this.Controls)
                        {
                            if (control.Name.Contains(dia))
                            {
                                control.Visible = false;
                            }
                        }
                    }
                }
            }
            catch
            {
                MessageBox.Show("Ocurrio un error al ocultar los dias no atendidos por el centro.");
            }

        }

        /// <summary>
        /// Limita las opciones del cmbDesde segun el horario de atencion del centroMedico en ese día.
        /// </summary>
        /// <param name="cmbDesde"></param>
        /// <param name="cmbHasta"></param>
        /// <param name="dia"></param>
        private void LimitarHorarioDesde(ComboBox cmbDesde, ComboBox cmbHasta, string dia)
        {

            int totalHorarios = Horario.ListaHorarios.Count;
            int indicePrimerHorarioPosible;
            int indiceUltimoHorarioPosible;

            try
            {
                switch (dia.ToString())
                {
                    case "lunes":
                        indicePrimerHorarioPosible = ((List<string>)cmbDesde.DataSource).IndexOf(this.centroMedico.DiasDeAtencion.Lunes.Desde);
                        indiceUltimoHorarioPosible = ((List<string>)cmbDesde.DataSource).IndexOf(this.centroMedico.DiasDeAtencion.Lunes.Hasta);
                        break;
                    case "martes":
                        indicePrimerHorarioPosible = ((List<string>)cmbDesde.DataSource).IndexOf(this.centroMedico.DiasDeAtencion.Martes.Desde);
                        indiceUltimoHorarioPosible = ((List<string>)cmbDesde.DataSource).IndexOf(this.centroMedico.DiasDeAtencion.Martes.Hasta);
                        break;
                    case "miercoles":
                        indicePrimerHorarioPosible = ((List<string>)cmbDesde.DataSource).IndexOf(this.centroMedico.DiasDeAtencion.Miercoles.Desde);
                        indiceUltimoHorarioPosible = ((List<string>)cmbDesde.DataSource).IndexOf(this.centroMedico.DiasDeAtencion.Miercoles.Hasta);
                        break;
                    case "jueves":
                        indicePrimerHorarioPosible = ((List<string>)cmbDesde.DataSource).IndexOf(this.centroMedico.DiasDeAtencion.Jueves.Desde);
                        indiceUltimoHorarioPosible = ((List<string>)cmbDesde.DataSource).IndexOf(this.centroMedico.DiasDeAtencion.Jueves.Hasta);
                        break;
                    case "viernes":
                        indicePrimerHorarioPosible = ((List<string>)cmbDesde.DataSource).IndexOf(this.centroMedico.DiasDeAtencion.Viernes.Desde);
                        indiceUltimoHorarioPosible = ((List<string>)cmbDesde.DataSource).IndexOf(this.centroMedico.DiasDeAtencion.Viernes.Hasta);
                        break;
                    case "sabado":
                        indicePrimerHorarioPosible = ((List<string>)cmbDesde.DataSource).IndexOf(this.centroMedico.DiasDeAtencion.Sabado.Desde);
                        indiceUltimoHorarioPosible = ((List<string>)cmbDesde.DataSource).IndexOf(this.centroMedico.DiasDeAtencion.Sabado.Hasta);
                        break;
                    case "domingo":
                        indicePrimerHorarioPosible = ((List<string>)cmbDesde.DataSource).IndexOf(this.centroMedico.DiasDeAtencion.Domingo.Desde);
                        indiceUltimoHorarioPosible = ((List<string>)cmbDesde.DataSource).IndexOf(this.centroMedico.DiasDeAtencion.Domingo.Hasta);
                        break;
                    default:
                        indicePrimerHorarioPosible = 0;
                        indiceUltimoHorarioPosible = totalHorarios;
                        break;
                }
                cmbDesde.DataSource = ((List<string>)cmbDesde.DataSource).GetRange(indicePrimerHorarioPosible, indiceUltimoHorarioPosible - indicePrimerHorarioPosible);
            }
            catch (Exception ex)
            {
                GestorDeArchivos.EscribirErrorEnLog(ex.Message);
                MessageBox.Show("Error al cargar los horarios");
            }

        }


        /// <summary>
        /// Carga los horarios posibles en los ComboBox hasta, debiendo ser el horario seleccionado desde menor al par.
        /// En caso que el formulario se abra con funcionProfesional, se agrega el horario de cierre del centro a los items de Hasta.
        /// </summary>
        /// <param name="cmbDesde"></param>
        /// <param name="cmbHasta"></param>
        private void CargarHorariosPosiblesCmbHasta(ComboBox cmbDesde, ComboBox cmbHasta)
        {
            try
            {

                int indice = cmbDesde.SelectedIndex;

                cmbHasta.Items.Clear();


                for (int i = indice + 1; i < cmbDesde.Items.Count; i++)
                {
                    cmbHasta.Items.Add(cmbDesde.Items[i]);
                }

                if (funcionProfesional)
                {
                    int items = cmbHasta.Items.Count;
                    string ultimoItem = cmbHasta.Items[items - 1].ToString();
                    int index = Horario.ListaHorarios.IndexOf(ultimoItem) + 1;

                    if (index < items)
                        cmbHasta.Items.Add(Horario.ListaHorarios[index]);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al cargar los horarios");
            }
        }


        /// <summary>
        /// Si el checkbox correspondiente al dia esta Checked. Guarda los horarios seleccionados por el usuario en el objeto HorarioDeAtencion.
        /// </summary>
        /// <param name="checkBox"></param>
        /// <param name="cmbDesde"></param>
        /// <param name="cmbHasta"></param>
        /// <param name="dia"></param>
        private void GuardarDia(CheckBox checkBox, ComboBox cmbDesde, ComboBox cmbHasta, HorarioDeAtencion dia)
        {
            if (checkBox.Checked)
            {
                dia.Atiende = true;
                dia.Desde = cmbDesde.SelectedItem.ToString();
                dia.Hasta = cmbHasta.SelectedItem.ToString();
                dia.EsPorDefecto = false;
            }
            else
            {
                dia.Atiende = false;
            }
        }

        /// <summary>
        /// Valida que si el checkBox esta Checked, el usuario haya seleccionado horarios de los combobox.
        /// </summary>
        /// <param name="checkBox"></param>
        /// <param name="cmbDesde"></param>
        /// <param name="cmbHasta"></param>
        /// <returns></returns>
        private bool ValidarHorarioCompletado(CheckBox checkBox, ComboBox cmbDesde, ComboBox cmbHasta)
        {
            if (checkBox.Checked)
            {
                bool respuesta = true;
                if (cmbHasta.SelectedIndex == -1)
                {
                    base.LanzarErrorCompletarCampo(cmbHasta);
                    respuesta = false;
                }

                if (cmbDesde.SelectedIndex == -1)
                {
                    base.LanzarErrorCompletarCampo(cmbDesde);
                    respuesta = false;
                }

                return respuesta;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Valida que todos los dias que esten checked (se atienda), esten completos.
        /// </summary>
        /// <returns></returns>
        private bool ValidarHorariosCompletados()
        {
            if (this.ValidarHorarioCompletado(cbxLunes, cmbDesdeLunes, cmbHastaLunes) &
            this.ValidarHorarioCompletado(cbxMartes, cmbDesdeMartes, cmbHastaMartes) &
            this.ValidarHorarioCompletado(cbxMiercoles, cmbDesdeMiercoles, cmbHastaMiercoles) &
            this.ValidarHorarioCompletado(cbxJueves, cmbDesdeJueves, cmbHastaJueves) &
            this.ValidarHorarioCompletado(cbxViernes, cmbDesdeViernes, cmbHastaViernes) &
            this.ValidarHorarioCompletado(cbxSabado, cmbDesdeSabado, cmbHastaSabado) &
            this.ValidarHorarioCompletado(cbxDomingo, cmbDesdeDomingo, cmbHastaDomingo))
            {
                errorProvider.Clear();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Valida y guarda los dias en un nuevo DiasDeAtencion, asignandolo segun funcionProfesional a quien corresponda.
        /// </summary>
        private void GuardarHorarios()
        {
            DiasDeAtencion diasDeAtencion = new DiasDeAtencion();

            if (this.ValidarHorariosCompletados())
            {
                this.GuardarDia(cbxLunes, cmbDesdeLunes, cmbHastaLunes, diasDeAtencion.Lunes);
                this.GuardarDia(cbxMartes, cmbDesdeMartes, cmbHastaMartes, diasDeAtencion.Martes);
                this.GuardarDia(cbxMiercoles, cmbDesdeMiercoles, cmbHastaMiercoles, diasDeAtencion.Miercoles);
                this.GuardarDia(cbxJueves, cmbDesdeJueves, cmbHastaJueves, diasDeAtencion.Jueves);
                this.GuardarDia(cbxViernes, cmbDesdeViernes, cmbHastaViernes, diasDeAtencion.Viernes);
                this.GuardarDia(cbxSabado, cmbDesdeSabado, cmbHastaSabado, diasDeAtencion.Sabado);
                this.GuardarDia(cbxDomingo, cmbDesdeDomingo, cmbHastaDomingo, diasDeAtencion.Domingo);


                if (funcionProfesional)
                {
                    profesionalIngresado.DiasDeAtencion = diasDeAtencion;
                }
                else
                {
                    centroMedicoIngresado.DiasDeAtencion = diasDeAtencion;
                }
                this.modificado = false;

                MessageBox.Show("Los datos se guardaron correctamente.", "Datos guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.OnModificacionRealizada?.Invoke();
                this.Close();
            }
            else
            {
                MessageBox.Show("Debe completar todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Cambia la propiedad Enabled de los ComboBox segun la propiedad Checked de check.
        /// </summary>
        /// <param name="check"></param>
        /// <param name="cmbDesde"></param>
        /// <param name="cmbHasta"></param>
        private void CambiarEstadoComboBox(CheckBox check, ComboBox cmbDesde, ComboBox cmbHasta)
        {
            if (check.Checked)
            {
                cmbDesde.Enabled = true;
                cmbHasta.Enabled = true;
            }
            else
            {
                cmbDesde.Enabled = false;
                cmbHasta.Enabled = false;
            }
        }

        ////------------SelectedIndexChanged Events

        private void cmbDesdeLunes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarHorariosPosiblesCmbHasta(this.cmbDesdeLunes, cmbHastaLunes);
            this.modificado = true;
        }

        private void cmbDesdeMartes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarHorariosPosiblesCmbHasta(this.cmbDesdeMartes, cmbHastaMartes);
            this.modificado = true;
        }

        private void cmbDesdeMiercoles_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarHorariosPosiblesCmbHasta(this.cmbDesdeMiercoles, cmbHastaMiercoles);
            this.modificado = true;
        }

        private void cmbDesdeJueves_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarHorariosPosiblesCmbHasta(this.cmbDesdeJueves, cmbHastaJueves);
            this.modificado = true;
        }

        private void cmbDesdeViernes_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarHorariosPosiblesCmbHasta(this.cmbDesdeViernes, cmbHastaViernes);
            this.modificado = true;
        }

        private void cmbDesdeSabado_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarHorariosPosiblesCmbHasta(this.cmbDesdeSabado, cmbHastaSabado);
            this.modificado = true;
        }

        private void cmbDesdeDomingo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.CargarHorariosPosiblesCmbHasta(this.cmbDesdeDomingo, cmbHastaDomingo);
            this.modificado = true;
        }

        //------------CheckedChanged Events

        private void cbxLunes_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarEstadoComboBox(cbxLunes, cmbDesdeLunes, cmbHastaLunes);
        }
        private void cbxMartes_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarEstadoComboBox(cbxMartes, cmbDesdeMartes, cmbHastaMartes);
        }

        private void cbxMiercoles_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarEstadoComboBox(cbxMiercoles, cmbDesdeMiercoles, cmbHastaMiercoles);
        }

        private void cbxJueves_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarEstadoComboBox(cbxJueves, cmbDesdeJueves, cmbHastaJueves);

        }

        private void cbxViernes_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarEstadoComboBox(cbxViernes, cmbDesdeViernes, cmbHastaViernes);
        }

        private void cbxSabado_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarEstadoComboBox(cbxSabado, cmbDesdeSabado, cmbHastaSabado);

        }

        private void cbxDomingo_CheckedChanged(object sender, EventArgs e)
        {
            this.CambiarEstadoComboBox(cbxDomingo, cmbDesdeDomingo, cmbHastaDomingo);

        }


        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                this.GuardarHorarios();
            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al guardar los horarios");
            }
        }

        /// <summary>
        /// Al detectar el cierre del formulario, si algun campo fue modificado, consulta si se desea cancelar la salida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmSeleccionarHorariosAtencion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (this.modificado == true)
            {
                DialogResult resultado = MessageBox.Show("Se han detectados, pero estos no se han guardado. Desea salir de todos modos?", "Alerta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
