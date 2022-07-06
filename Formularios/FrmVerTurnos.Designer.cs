namespace Formularios
{
    partial class FrmVerTurnos
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
            this.cmbProfesionales = new System.Windows.Forms.ComboBox();
            this.lblFecha = new System.Windows.Forms.Label();
            this.lblProfesionales = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvTurnos = new System.Windows.Forms.DataGridView();
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblDocumento = new System.Windows.Forms.Label();
            this.txtDocumentoPaciente = new System.Windows.Forms.TextBox();
            this.cbxTodasLasFechas = new System.Windows.Forms.CheckBox();
            this.btnExportarCoincidencias = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbProfesionales
            // 
            this.cmbProfesionales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfesionales.FormattingEnabled = true;
            this.cmbProfesionales.Location = new System.Drawing.Point(314, 113);
            this.cmbProfesionales.Name = "cmbProfesionales";
            this.cmbProfesionales.Size = new System.Drawing.Size(151, 28);
            this.cmbProfesionales.TabIndex = 28;
            // 
            // lblFecha
            // 
            this.lblFecha.AutoSize = true;
            this.lblFecha.Location = new System.Drawing.Point(121, 90);
            this.lblFecha.Name = "lblFecha";
            this.lblFecha.Size = new System.Drawing.Size(50, 20);
            this.lblFecha.TabIndex = 30;
            this.lblFecha.Text = "Fecha:";
            // 
            // lblProfesionales
            // 
            this.lblProfesionales.AutoSize = true;
            this.lblProfesionales.Location = new System.Drawing.Point(345, 90);
            this.lblProfesionales.Name = "lblProfesionales";
            this.lblProfesionales.Size = new System.Drawing.Size(86, 20);
            this.lblProfesionales.TabIndex = 31;
            this.lblProfesionales.Text = "Profesional:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvTurnos);
            this.panel1.Location = new System.Drawing.Point(0, 309);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(825, 239);
            this.panel1.TabIndex = 32;
            // 
            // dgvTurnos
            // 
            this.dgvTurnos.AllowUserToAddRows = false;
            this.dgvTurnos.AllowUserToDeleteRows = false;
            this.dgvTurnos.AllowUserToOrderColumns = true;
            this.dgvTurnos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTurnos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvTurnos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvTurnos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTurnos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTurnos.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvTurnos.Location = new System.Drawing.Point(0, 0);
            this.dgvTurnos.Name = "dgvTurnos";
            this.dgvTurnos.RowHeadersWidth = 51;
            this.dgvTurnos.RowTemplate.Height = 29;
            this.dgvTurnos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTurnos.Size = new System.Drawing.Size(825, 239);
            this.dgvTurnos.TabIndex = 1;
            this.dgvTurnos.Visible = false;
            // 
            // dtpFecha
            // 
            this.dtpFecha.Location = new System.Drawing.Point(21, 148);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(250, 27);
            this.dtpFecha.TabIndex = 33;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(665, 113);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(94, 29);
            this.btnBuscar.TabIndex = 34;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblDocumento
            // 
            this.lblDocumento.AutoSize = true;
            this.lblDocumento.Location = new System.Drawing.Point(497, 90);
            this.lblDocumento.Name = "lblDocumento";
            this.lblDocumento.Size = new System.Drawing.Size(151, 20);
            this.lblDocumento.TabIndex = 35;
            this.lblDocumento.Text = "Documento paciente:";
            this.lblDocumento.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // txtDocumentoPaciente
            // 
            this.txtDocumentoPaciente.Location = new System.Drawing.Point(484, 113);
            this.txtDocumentoPaciente.Name = "txtDocumentoPaciente";
            this.txtDocumentoPaciente.PlaceholderText = "Todos";
            this.txtDocumentoPaciente.Size = new System.Drawing.Size(175, 27);
            this.txtDocumentoPaciente.TabIndex = 36;
            this.txtDocumentoPaciente.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtDocumentoPaciente_KeyPress);
            // 
            // cbxTodasLasFechas
            // 
            this.cbxTodasLasFechas.AutoSize = true;
            this.cbxTodasLasFechas.Location = new System.Drawing.Point(111, 117);
            this.cbxTodasLasFechas.Name = "cbxTodasLasFechas";
            this.cbxTodasLasFechas.Size = new System.Drawing.Size(71, 24);
            this.cbxTodasLasFechas.TabIndex = 37;
            this.cbxTodasLasFechas.Text = "Todos";
            this.cbxTodasLasFechas.UseVisualStyleBackColor = true;
            this.cbxTodasLasFechas.CheckedChanged += new System.EventHandler(this.cbxFecha_CheckedChanged);
            // 
            // btnExportarCoincidencias
            // 
            this.btnExportarCoincidencias.Location = new System.Drawing.Point(274, 215);
            this.btnExportarCoincidencias.Name = "btnExportarCoincidencias";
            this.btnExportarCoincidencias.Size = new System.Drawing.Size(191, 29);
            this.btnExportarCoincidencias.TabIndex = 38;
            this.btnExportarCoincidencias.Text = "Exportar coincidencias";
            this.btnExportarCoincidencias.UseVisualStyleBackColor = true;
            this.btnExportarCoincidencias.Visible = false;
            this.btnExportarCoincidencias.Click += new System.EventHandler(this.btnExportarCoincidencias_Click);
            // 
            // FrmVerTurnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(840, 662);
            this.Controls.Add(this.btnExportarCoincidencias);
            this.Controls.Add(this.cbxTodasLasFechas);
            this.Controls.Add(this.txtDocumentoPaciente);
            this.Controls.Add(this.lblDocumento);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.dtpFecha);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lblProfesionales);
            this.Controls.Add(this.lblFecha);
            this.Controls.Add(this.cmbProfesionales);
            this.Name = "FrmVerTurnos";
            this.Text = "FrmVerTurnos";
            this.Controls.SetChildIndex(this.cmbProfesionales, 0);
            this.Controls.SetChildIndex(this.lblFecha, 0);
            this.Controls.SetChildIndex(this.lblProfesionales, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.dtpFecha, 0);
            this.Controls.SetChildIndex(this.btnBuscar, 0);
            this.Controls.SetChildIndex(this.lblDocumento, 0);
            this.Controls.SetChildIndex(this.txtDocumentoPaciente, 0);
            this.Controls.SetChildIndex(this.cbxTodasLasFechas, 0);
            this.Controls.SetChildIndex(this.btnExportarCoincidencias, 0);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTurnos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ComboBox cmbProfesionales;
        private System.Windows.Forms.Label lblFecha;
        private System.Windows.Forms.Label lblProfesionales;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView dgvTurnos;
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblDocumento;
        private System.Windows.Forms.TextBox txtDocumentoPaciente;
        private System.Windows.Forms.CheckBox cbxTodasLasFechas;
        private System.Windows.Forms.Button btnExportarCoincidencias;
    }
}