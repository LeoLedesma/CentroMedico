using System;
using System.Windows.Forms;
using Entidades;

namespace Formularios
{
    public partial class FrmSecundario : Form
    {
        public static ErrorProvider errorProvider;
        public CentroMedico centroMedico;        

        private FrmSecundario()
        {
            InitializeComponent();
            this.Size = new System.Drawing.Size(835, 637);
            this.centroMedico = CentroMedico.Instancia;
            FrmSecundario.errorProvider = new ErrorProvider();
        }

        public FrmSecundario(string titulo) : this()
        {            
            this.lblTitulo.Text = titulo;         
        }

        static FrmSecundario()
        {
            FrmSecundario.errorProvider = new ErrorProvider();
        }


        public void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        public void VaciarCampos()
        { 
            foreach (Control control in this.Controls)
            {
                if (control is TextBox)
                {
                    control.Text = "";
                }
            }
        }


        //Validaciones

        #region Validaciones
        public bool SoloNumeros(object sender, KeyPressEventArgs e)
        {
            
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                return false;
            }
            return true;
        }

        public void ValidarCampoNumerico(object sender, KeyPressEventArgs e)
        {
            if (!SoloNumeros(sender, e))
            {
                FrmSecundario.errorProvider.SetError((TextBox)sender, "Error. Solo pueden ser numeros");
            }
            else
            {
                FrmSecundario.errorProvider.Clear();
            }
        }

        public bool SoloLetras(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsSeparator(e.KeyChar))
            {
                e.Handled = true;
                return false;
            }

            return true;
        }

        public void ValidarCampoChars(object sender, KeyPressEventArgs e)
        {
            if (!SoloLetras(sender, e))
            {
                FrmSecundario.errorProvider.SetError((TextBox)sender, "Error. Solo pueden ser letras");
            }
            else
            {
                FrmSecundario.errorProvider.Clear();
            }
        }

        public bool ValidarCampos()
        {
            bool valido = true;

            foreach (Control control in this.Controls)
            {
                if (control.GetType().Name == "TextBox" && string.IsNullOrEmpty(control.Text) && control.CausesValidation)
                {
                    this.LanzarErrorCompletarCampo(control);
                    valido = false;
                }
            }

            return valido;
        }

        public bool ValidarListas()
        {
            foreach (Control control in this.Controls)
            {
                if (control is ListBox && ((ListBox)control).Items.Count == 0 && control.CausesValidation)                
                {
                    this.LanzarErrorCompletarCampo(control);
                    return false;
                }
            }

            return true;
        }

        public bool ComprobarTextboxs()
        {
            foreach (Control control in this.Controls)
            {
                if (control is TextBox && !string.IsNullOrEmpty(control.Text))
                {
                    this.LanzarErrorCompletarCampo(control);
                    return false;
                }
            }
            return true;
        }

        public void LanzarErrorCompletarCampo(Control sender)
        {
            FrmSecundario.errorProvider.SetError(sender, "Error. Debe completar este campo");
        }
        #endregion




    }
}
