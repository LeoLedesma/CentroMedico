namespace Formularios
{
    partial class FrmNuevoTurno
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cmbSeleccionarPor = new System.Windows.Forms.ComboBox();
            this.lblSeleccionarPor = new System.Windows.Forms.Label();
            this.lblSegundoPaso = new System.Windows.Forms.Label();
            this.cmbSegundoPaso = new System.Windows.Forms.ComboBox();
            this.lblTercerPaso = new System.Windows.Forms.Label();
            this.cmbTercerPaso = new System.Windows.Forms.ComboBox();
            this.lblSeleccioneFecha = new System.Windows.Forms.Label();
            this.cmbFechas = new System.Windows.Forms.ComboBox();
            this.lblSeleccioneHorario = new System.Windows.Forms.Label();
            this.cmbHorarios = new System.Windows.Forms.ComboBox();
            this.BtnConfirmar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cmbSeleccionarPor
            // 
            this.cmbSeleccionarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSeleccionarPor.FormattingEnabled = true;
            this.cmbSeleccionarPor.Items.AddRange(new object[] {
            "Especialidad",
            "Profesional"});
            this.cmbSeleccionarPor.Location = new System.Drawing.Point(528, 140);
            this.cmbSeleccionarPor.Name = "cmbSeleccionarPor";
            this.cmbSeleccionarPor.Size = new System.Drawing.Size(277, 28);
            this.cmbSeleccionarPor.TabIndex = 27;
            this.cmbSeleccionarPor.SelectedIndexChanged += new System.EventHandler(this.cmbSeleccionarPor_SelectedIndexChanged);
            // 
            // lblSeleccionarPor
            // 
            this.lblSeleccionarPor.AutoSize = true;
            this.lblSeleccionarPor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSeleccionarPor.Location = new System.Drawing.Point(51, 136);
            this.lblSeleccionarPor.Name = "lblSeleccionarPor";
            this.lblSeleccionarPor.Size = new System.Drawing.Size(151, 28);
            this.lblSeleccionarPor.TabIndex = 28;
            this.lblSeleccionarPor.Text = "Seleccionar por:";
            // 
            // lblSegundoPaso
            // 
            this.lblSegundoPaso.AutoSize = true;
            this.lblSegundoPaso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSegundoPaso.Location = new System.Drawing.Point(51, 183);
            this.lblSegundoPaso.Name = "lblSegundoPaso";
            this.lblSegundoPaso.Size = new System.Drawing.Size(142, 28);
            this.lblSegundoPaso.TabIndex = 30;
            this.lblSegundoPaso.Text = "Segundo paso:";
            this.lblSegundoPaso.Visible = false;
            // 
            // cmbSegundoPaso
            // 
            this.cmbSegundoPaso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSegundoPaso.FormattingEnabled = true;
            this.cmbSegundoPaso.Items.AddRange(new object[] {
            "Especialidad",
            "Profesional"});
            this.cmbSegundoPaso.Location = new System.Drawing.Point(349, 187);
            this.cmbSegundoPaso.Name = "cmbSegundoPaso";
            this.cmbSegundoPaso.Size = new System.Drawing.Size(456, 28);
            this.cmbSegundoPaso.TabIndex = 29;
            this.cmbSegundoPaso.Visible = false;
            this.cmbSegundoPaso.SelectedIndexChanged += new System.EventHandler(this.cmbSegundoPaso_SelectedIndexChanged);
            // 
            // lblTercerPaso
            // 
            this.lblTercerPaso.AutoSize = true;
            this.lblTercerPaso.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTercerPaso.Location = new System.Drawing.Point(51, 230);
            this.lblTercerPaso.Name = "lblTercerPaso";
            this.lblTercerPaso.Size = new System.Drawing.Size(114, 28);
            this.lblTercerPaso.TabIndex = 32;
            this.lblTercerPaso.Text = "Tercer paso:";
            this.lblTercerPaso.Visible = false;
            // 
            // cmbTercerPaso
            // 
            this.cmbTercerPaso.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTercerPaso.FormattingEnabled = true;
            this.cmbTercerPaso.Items.AddRange(new object[] {
            "Especialidad",
            "Profesional"});
            this.cmbTercerPaso.Location = new System.Drawing.Point(349, 234);
            this.cmbTercerPaso.Name = "cmbTercerPaso";
            this.cmbTercerPaso.Size = new System.Drawing.Size(456, 28);
            this.cmbTercerPaso.TabIndex = 31;
            this.cmbTercerPaso.Visible = false;
            this.cmbTercerPaso.SelectedIndexChanged += new System.EventHandler(this.cmbTercerPaso_SelectedIndexChanged);
            // 
            // lblSeleccioneFecha
            // 
            this.lblSeleccioneFecha.AutoSize = true;
            this.lblSeleccioneFecha.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSeleccioneFecha.Location = new System.Drawing.Point(50, 277);
            this.lblSeleccioneFecha.Name = "lblSeleccioneFecha";
            this.lblSeleccioneFecha.Size = new System.Drawing.Size(163, 28);
            this.lblSeleccioneFecha.TabIndex = 34;
            this.lblSeleccioneFecha.Text = "Seleccione Fecha:";
            this.lblSeleccioneFecha.Visible = false;
            // 
            // cmbFechas
            // 
            this.cmbFechas.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFechas.FormattingEnabled = true;
            this.cmbFechas.Items.AddRange(new object[] {
            "Especialidad",
            "Profesional"});
            this.cmbFechas.Location = new System.Drawing.Point(348, 281);
            this.cmbFechas.Name = "cmbFechas";
            this.cmbFechas.Size = new System.Drawing.Size(456, 28);
            this.cmbFechas.TabIndex = 33;
            this.cmbFechas.Visible = false;
            this.cmbFechas.SelectedIndexChanged += new System.EventHandler(this.cmbFechas_SelectedIndexChanged);
            // 
            // lblSeleccioneHorario
            // 
            this.lblSeleccioneHorario.AutoSize = true;
            this.lblSeleccioneHorario.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblSeleccioneHorario.Location = new System.Drawing.Point(51, 329);
            this.lblSeleccioneHorario.Name = "lblSeleccioneHorario";
            this.lblSeleccioneHorario.Size = new System.Drawing.Size(176, 28);
            this.lblSeleccioneHorario.TabIndex = 36;
            this.lblSeleccioneHorario.Text = "Seleccione Horario";
            this.lblSeleccioneHorario.Visible = false;
            // 
            // cmbHorarios
            // 
            this.cmbHorarios.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbHorarios.FormattingEnabled = true;
            this.cmbHorarios.Items.AddRange(new object[] {
            "Especialidad",
            "Profesional"});
            this.cmbHorarios.Location = new System.Drawing.Point(349, 333);
            this.cmbHorarios.Name = "cmbHorarios";
            this.cmbHorarios.Size = new System.Drawing.Size(456, 28);
            this.cmbHorarios.TabIndex = 35;
            this.cmbHorarios.Visible = false;
            this.cmbHorarios.SelectedIndexChanged += new System.EventHandler(this.cmbHorarios_SelectedIndexChanged);
            // 
            // BtnConfirmar
            // 
            this.BtnConfirmar.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnConfirmar.Location = new System.Drawing.Point(301, 443);
            this.BtnConfirmar.Name = "BtnConfirmar";
            this.BtnConfirmar.Size = new System.Drawing.Size(302, 70);
            this.BtnConfirmar.TabIndex = 37;
            this.BtnConfirmar.Text = "Confirmar Turno";
            this.BtnConfirmar.UseVisualStyleBackColor = true;
            this.BtnConfirmar.Click += new System.EventHandler(this.BtnConfirmar_Click);
            // 
            // FrmNuevoTurno
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 662);
            this.Controls.Add(this.BtnConfirmar);
            this.Controls.Add(this.lblSeleccioneHorario);
            this.Controls.Add(this.cmbHorarios);
            this.Controls.Add(this.lblSeleccioneFecha);
            this.Controls.Add(this.cmbFechas);
            this.Controls.Add(this.lblTercerPaso);
            this.Controls.Add(this.cmbTercerPaso);
            this.Controls.Add(this.lblSegundoPaso);
            this.Controls.Add(this.cmbSegundoPaso);
            this.Controls.Add(this.lblSeleccionarPor);
            this.Controls.Add(this.cmbSeleccionarPor);
            this.Name = "FrmNuevoTurno";
            this.Text = "FrmTurnos";
            this.Controls.SetChildIndex(this.cmbSeleccionarPor, 0);
            this.Controls.SetChildIndex(this.lblSeleccionarPor, 0);
            this.Controls.SetChildIndex(this.cmbSegundoPaso, 0);
            this.Controls.SetChildIndex(this.lblSegundoPaso, 0);
            this.Controls.SetChildIndex(this.cmbTercerPaso, 0);
            this.Controls.SetChildIndex(this.lblTercerPaso, 0);
            this.Controls.SetChildIndex(this.cmbFechas, 0);
            this.Controls.SetChildIndex(this.lblSeleccioneFecha, 0);
            this.Controls.SetChildIndex(this.cmbHorarios, 0);
            this.Controls.SetChildIndex(this.lblSeleccioneHorario, 0);
            this.Controls.SetChildIndex(this.BtnConfirmar, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbSeleccionarPor;
        private System.Windows.Forms.Label lblSeleccionarPor;
        private System.Windows.Forms.Label lblSegundoPaso;
        private System.Windows.Forms.ComboBox cmbSegundoPaso;
        private System.Windows.Forms.Label lblTercerPaso;
        private System.Windows.Forms.ComboBox cmbTercerPaso;        
        private System.Windows.Forms.Label lblSeleccioneFecha;
        private System.Windows.Forms.ComboBox cmbFechas;
        private System.Windows.Forms.Label lblSeleccioneHorario;
        private System.Windows.Forms.ComboBox cmbHorarios;
        private System.Windows.Forms.Button BtnConfirmar;
    }
}