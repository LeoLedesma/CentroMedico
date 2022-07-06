using Entidades;
using Entidades.Exceptions;
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
    public partial class FrmVerTurnos : FrmSecundario
    {

        public FrmVerTurnos() : this("Ver turnos")
        {
        }

        public FrmVerTurnos(string titulo) : base(titulo)
        {
            InitializeComponent();
            cmbProfesionales.Items.Add("Todos");
            cmbProfesionales.Items.AddRange(centroMedico.Profesionales.ToArray());
            cmbProfesionales.SelectedIndex = 0;
            dtpFecha.Visible = false;
            cbxTodasLasFechas.Checked = true;
        }

        public FrmVerTurnos(Paciente paciente) : this($"Turnos de {paciente}")
        {

            txtDocumentoPaciente.Text = paciente.Documento;
        }
        public FrmVerTurnos(Profesional profesional) : this($"Turnos de {profesional}")
        {

            cmbProfesionales.SelectedItem = profesional;
        }

        public void BuscarTurnos()
        {
            try
            {
                List<Turno> coincidencias = new List<Turno>();

                if (cbxTodasLasFechas.Checked)
                {
                    coincidencias = this.BuscarTurnosTodasLasFechas();
                }
                else //No son todas las fechas
                {
                    coincidencias = this.BuscarTurnosFechaEspecifica();
                }

                if (coincidencias.Count > 0)
                {
                    dgvTurnos.DataSource = coincidencias;
                    dgvTurnos.Visible = true;
                    btnExportarCoincidencias.Visible = true;
                }
                else
                {
                    this.OcultarCoincidencias();
                    MessageBox.Show("No hubo coincidencias en la busqueda.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OcultarCoincidencias()
        {
            dgvTurnos.Visible = false;
            this.OcultarBotones();
        }

        private void OcultarBotones()
        {
            this.btnExportarCoincidencias.Visible = false;
        }

        private List<Turno> BuscarTurnosTodasLasFechas()
        {
            try
            {
                if (cmbProfesionales.Text == "Todos" && txtDocumentoPaciente.Text == "")
                    return centroMedico.Turnos;

                else if (cmbProfesionales.Text == "Todos" && txtDocumentoPaciente.Text != "")
                    return centroMedico.BuscarTurnos(centroMedico.BuscarPaciente(txtDocumentoPaciente.Text));

                else if (cmbProfesionales.Text != "Todos" && txtDocumentoPaciente.Text == "")
                    return centroMedico.BuscarTurnos((Profesional)cmbProfesionales.SelectedItem);

                else if (cmbProfesionales.Text != "Todos" && txtDocumentoPaciente.Text != "")
                    return centroMedico.BuscarTurnos((Profesional)cmbProfesionales.SelectedItem, centroMedico.BuscarPaciente(txtDocumentoPaciente.Text));

            }
            catch (BusquedaException ex)
            {
                MessageBox.Show(ex.Message);
            }

            return new List<Turno>();
        }

        private List<Turno> BuscarTurnosFechaEspecifica()
        {
            if(cmbProfesionales.Text == "Todos" && txtDocumentoPaciente.Text == "")            
                return centroMedico.BuscarTurnos(dtpFecha.Value);
            else if (txtDocumentoPaciente.Text == "" && cmbProfesionales.Text != "Todos")            
                return centroMedico.BuscarTurnos(dtpFecha.Value, (Profesional)cmbProfesionales.SelectedItem);
            else
                return centroMedico.BuscarTurnos(dtpFecha.Value, (Profesional)cmbProfesionales.SelectedItem, txtDocumentoPaciente.Text);            
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (cmbProfesionales.SelectedIndex != -1)
            {
                try
                {
                this.BuscarTurnos();

                }catch(BusquedaException ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void cbxFecha_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxTodasLasFechas.Checked)
            {
                dtpFecha.Visible = false;
            }
            else
            {
                dtpFecha.Visible = true;
            }
        }

        private void btnExportarCoincidencias_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.Filter = "Archivo JSON |*.json|Archivo XML |*.xml|Archivo de texto .txt |*.txt";

                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string fullPath = saveFile.FileName;
                    if (!string.IsNullOrEmpty(fullPath))
                    {
                        List<Turno> coincidencias = (List<Turno>)dgvTurnos.DataSource;
                        if (fullPath.Contains(".xml"))                        
                            centroMedico.SerializarListaToXML(fullPath, (List<Turno>)dgvTurnos.DataSource);                        
                        else if (fullPath.Contains(".json"))                        
                            centroMedico.SerializarListaToJSON(fullPath, (List<Turno>)dgvTurnos.DataSource);                        
                        else                        
                           GestorDeArchivos.GuardarArchivo(fullPath, coincidencias);                        
                    }
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Ocurrio un error al intentar exportar");
            }
        }

        private void FrmVerTurnos_Load(object sender, EventArgs e)
        {

        }

        private void txtDocumentoPaciente_KeyPress(object sender, KeyPressEventArgs e)
        {
            this.ValidarCampoNumerico(sender, e);
        }
    }
}
