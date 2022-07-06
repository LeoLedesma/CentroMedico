namespace Formularios
{
    partial class FrmBuscar
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
            this.txbBusqueda = new System.Windows.Forms.TextBox();
            this.lblTextoBusqueda = new System.Windows.Forms.Label();
            this.lblBuscarPor = new System.Windows.Forms.Label();
            this.lblCoincidencias = new System.Windows.Forms.Label();
            this.cmbBuscarPor = new System.Windows.Forms.ComboBox();
            this.dgvCoincidencias = new System.Windows.Forms.DataGridView();
            this.pnlModificar = new System.Windows.Forms.Panel();
            this.BtnModificar = new System.Windows.Forms.Button();
            this.BtnEliminar = new System.Windows.Forms.Button();
            this.BtnVerTurnos = new System.Windows.Forms.Button();
            this.BtnExportar = new System.Windows.Forms.Button();
            this.BtnModificarHorarios = new System.Windows.Forms.Button();
            this.BtnConfirmarTurno = new System.Windows.Forms.Button();
            this.cmbBuscarTurnos = new System.Windows.Forms.ComboBox();
            this.btnNuevoTurno = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoincidencias)).BeginInit();
            this.pnlModificar.SuspendLayout();
            this.SuspendLayout();
            // 
            // txbBusqueda
            // 
            this.txbBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txbBusqueda.Location = new System.Drawing.Point(221, 137);
            this.txbBusqueda.Name = "txbBusqueda";
            this.txbBusqueda.Size = new System.Drawing.Size(192, 34);
            this.txbBusqueda.TabIndex = 30;
            this.txbBusqueda.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txbBusqueda_KeyPress);
            this.txbBusqueda.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txbBusqueda_KeyUp);
            // 
            // lblTextoBusqueda
            // 
            this.lblTextoBusqueda.AutoSize = true;
            this.lblTextoBusqueda.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTextoBusqueda.Location = new System.Drawing.Point(221, 107);
            this.lblTextoBusqueda.Name = "lblTextoBusqueda";
            this.lblTextoBusqueda.Size = new System.Drawing.Size(119, 28);
            this.lblTextoBusqueda.TabIndex = 31;
            this.lblTextoBusqueda.Text = "Documento:";
            // 
            // lblBuscarPor
            // 
            this.lblBuscarPor.AutoSize = true;
            this.lblBuscarPor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblBuscarPor.Location = new System.Drawing.Point(15, 107);
            this.lblBuscarPor.Name = "lblBuscarPor";
            this.lblBuscarPor.Size = new System.Drawing.Size(108, 28);
            this.lblBuscarPor.TabIndex = 32;
            this.lblBuscarPor.Text = "Buscar por:";
            // 
            // lblCoincidencias
            // 
            this.lblCoincidencias.AutoSize = true;
            this.lblCoincidencias.Location = new System.Drawing.Point(14, 194);
            this.lblCoincidencias.Name = "lblCoincidencias";
            this.lblCoincidencias.Size = new System.Drawing.Size(103, 20);
            this.lblCoincidencias.TabIndex = 34;
            this.lblCoincidencias.Text = "Coincidencias:";
            // 
            // cmbBuscarPor
            // 
            this.cmbBuscarPor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuscarPor.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbBuscarPor.FormattingEnabled = true;
            this.cmbBuscarPor.Items.AddRange(new object[] {
            "Apellido",
            "Documento",
            "Nombre",
            "Telefono",
            "Todos"});
            this.cmbBuscarPor.Location = new System.Drawing.Point(13, 136);
            this.cmbBuscarPor.Name = "cmbBuscarPor";
            this.cmbBuscarPor.Size = new System.Drawing.Size(192, 36);
            this.cmbBuscarPor.TabIndex = 29;
            this.cmbBuscarPor.SelectedIndexChanged += new System.EventHandler(this.cmbBuscarPor_SelectedIndexChanged);
            // 
            // dgvCoincidencias
            // 
            this.dgvCoincidencias.AllowUserToAddRows = false;
            this.dgvCoincidencias.AllowUserToDeleteRows = false;
            this.dgvCoincidencias.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.dgvCoincidencias.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvCoincidencias.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvCoincidencias.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCoincidencias.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvCoincidencias.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvCoincidencias.Location = new System.Drawing.Point(0, 0);
            this.dgvCoincidencias.Name = "dgvCoincidencias";
            this.dgvCoincidencias.RowHeadersWidth = 51;
            this.dgvCoincidencias.RowTemplate.Height = 29;
            this.dgvCoincidencias.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvCoincidencias.Size = new System.Drawing.Size(814, 157);
            this.dgvCoincidencias.TabIndex = 0;
            this.dgvCoincidencias.Visible = false;
            this.dgvCoincidencias.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvCoincidencias_CellFormatting);
            this.dgvCoincidencias.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvCoincidencias_CellMouseDoubleClick);
            this.dgvCoincidencias.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvCoincidencias_DataError);
            // 
            // pnlModificar
            // 
            this.pnlModificar.AutoScroll = true;
            this.pnlModificar.BackColor = System.Drawing.Color.Transparent;
            this.pnlModificar.Controls.Add(this.dgvCoincidencias);
            this.pnlModificar.Location = new System.Drawing.Point(14, 217);
            this.pnlModificar.Name = "pnlModificar";
            this.pnlModificar.Size = new System.Drawing.Size(814, 157);
            this.pnlModificar.TabIndex = 39;
            // 
            // BtnModificar
            // 
            this.BtnModificar.Location = new System.Drawing.Point(329, 490);
            this.BtnModificar.Name = "BtnModificar";
            this.BtnModificar.Size = new System.Drawing.Size(160, 42);
            this.BtnModificar.TabIndex = 40;
            this.BtnModificar.Text = "Modificar";
            this.BtnModificar.UseVisualStyleBackColor = true;
            this.BtnModificar.Visible = false;
            this.BtnModificar.Click += new System.EventHandler(this.BtnModificar_Click);
            // 
            // BtnEliminar
            // 
            this.BtnEliminar.Location = new System.Drawing.Point(557, 490);
            this.BtnEliminar.Name = "BtnEliminar";
            this.BtnEliminar.Size = new System.Drawing.Size(160, 42);
            this.BtnEliminar.TabIndex = 41;
            this.BtnEliminar.Text = "Eliminar";
            this.BtnEliminar.UseVisualStyleBackColor = true;
            this.BtnEliminar.Visible = false;
            this.BtnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // BtnVerTurnos
            // 
            this.BtnVerTurnos.Location = new System.Drawing.Point(101, 489);
            this.BtnVerTurnos.Name = "BtnVerTurnos";
            this.BtnVerTurnos.Size = new System.Drawing.Size(160, 42);
            this.BtnVerTurnos.TabIndex = 42;
            this.BtnVerTurnos.Text = "Ver turnos";
            this.BtnVerTurnos.UseVisualStyleBackColor = true;
            this.BtnVerTurnos.Visible = false;
            this.BtnVerTurnos.Click += new System.EventHandler(this.BtnVerTurnos_Click);
            // 
            // BtnExportar
            // 
            this.BtnExportar.Location = new System.Drawing.Point(329, 555);
            this.BtnExportar.Name = "BtnExportar";
            this.BtnExportar.Size = new System.Drawing.Size(160, 42);
            this.BtnExportar.TabIndex = 43;
            this.BtnExportar.Text = "Exportar";
            this.BtnExportar.UseVisualStyleBackColor = true;
            this.BtnExportar.Visible = false;
            this.BtnExportar.Click += new System.EventHandler(this.BtnExportar_Click);
            // 
            // BtnModificarHorarios
            // 
            this.BtnModificarHorarios.Location = new System.Drawing.Point(101, 555);
            this.BtnModificarHorarios.Name = "BtnModificarHorarios";
            this.BtnModificarHorarios.Size = new System.Drawing.Size(160, 42);
            this.BtnModificarHorarios.TabIndex = 44;
            this.BtnModificarHorarios.Text = "Modificar horarios";
            this.BtnModificarHorarios.UseVisualStyleBackColor = true;
            this.BtnModificarHorarios.Visible = false;
            this.BtnModificarHorarios.Click += new System.EventHandler(this.BtnModificarHorarios_Click);
            // 
            // BtnConfirmarTurno
            // 
            this.BtnConfirmarTurno.Location = new System.Drawing.Point(557, 555);
            this.BtnConfirmarTurno.Name = "BtnConfirmarTurno";
            this.BtnConfirmarTurno.Size = new System.Drawing.Size(160, 42);
            this.BtnConfirmarTurno.TabIndex = 45;
            this.BtnConfirmarTurno.Text = "Confirmar turno";
            this.BtnConfirmarTurno.UseVisualStyleBackColor = true;
            this.BtnConfirmarTurno.Visible = false;
            this.BtnConfirmarTurno.Click += new System.EventHandler(this.BtnConfirmarTurno_Click);
            // 
            // cmbBuscarTurnos
            // 
            this.cmbBuscarTurnos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbBuscarTurnos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbBuscarTurnos.FormattingEnabled = true;
            this.cmbBuscarTurnos.Items.AddRange(new object[] {
            "Documento",
            "Nombre",
            "Apellido",
            "Telefono"});
            this.cmbBuscarTurnos.Location = new System.Drawing.Point(449, 137);
            this.cmbBuscarTurnos.Name = "cmbBuscarTurnos";
            this.cmbBuscarTurnos.Size = new System.Drawing.Size(192, 36);
            this.cmbBuscarTurnos.TabIndex = 46;
            this.cmbBuscarTurnos.Visible = false;
            this.cmbBuscarTurnos.SelectedIndexChanged += new System.EventHandler(this.cmbBuscarTurnos_SelectedIndexChanged);
            // 
            // btnNuevoTurno
            // 
            this.btnNuevoTurno.Location = new System.Drawing.Point(101, 555);
            this.btnNuevoTurno.Name = "btnNuevoTurno";
            this.btnNuevoTurno.Size = new System.Drawing.Size(160, 42);
            this.btnNuevoTurno.TabIndex = 47;
            this.btnNuevoTurno.Text = "Nuevo turno";
            this.btnNuevoTurno.UseVisualStyleBackColor = true;
            this.btnNuevoTurno.Visible = false;
            this.btnNuevoTurno.Click += new System.EventHandler(this.btnNuevoTurno_Click);
            // 
            // FrmBuscar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1097, 662);
            this.Controls.Add(this.btnNuevoTurno);
            this.Controls.Add(this.cmbBuscarTurnos);
            this.Controls.Add(this.BtnConfirmarTurno);
            this.Controls.Add(this.BtnModificarHorarios);
            this.Controls.Add(this.BtnExportar);
            this.Controls.Add(this.BtnVerTurnos);
            this.Controls.Add(this.BtnEliminar);
            this.Controls.Add(this.BtnModificar);
            this.Controls.Add(this.lblCoincidencias);
            this.Controls.Add(this.lblBuscarPor);
            this.Controls.Add(this.lblTextoBusqueda);
            this.Controls.Add(this.txbBusqueda);
            this.Controls.Add(this.cmbBuscarPor);
            this.Controls.Add(this.pnlModificar);
            this.Name = "FrmBuscar";
            this.Text = "FrmBuscarPaciente";
            this.Controls.SetChildIndex(this.pnlModificar, 0);
            this.Controls.SetChildIndex(this.cmbBuscarPor, 0);
            this.Controls.SetChildIndex(this.txbBusqueda, 0);
            this.Controls.SetChildIndex(this.lblTextoBusqueda, 0);
            this.Controls.SetChildIndex(this.lblBuscarPor, 0);
            this.Controls.SetChildIndex(this.lblCoincidencias, 0);
            this.Controls.SetChildIndex(this.BtnModificar, 0);
            this.Controls.SetChildIndex(this.BtnEliminar, 0);
            this.Controls.SetChildIndex(this.BtnVerTurnos, 0);
            this.Controls.SetChildIndex(this.BtnExportar, 0);
            this.Controls.SetChildIndex(this.BtnModificarHorarios, 0);
            this.Controls.SetChildIndex(this.BtnConfirmarTurno, 0);
            this.Controls.SetChildIndex(this.cmbBuscarTurnos, 0);
            this.Controls.SetChildIndex(this.btnNuevoTurno, 0);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCoincidencias)).EndInit();
            this.pnlModificar.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txbBusqueda;
        private System.Windows.Forms.Label lblTextoBusqueda;
        private System.Windows.Forms.Label lblBuscarPor;
        private System.Windows.Forms.Label lblCoincidencias;
        private System.Windows.Forms.ComboBox cmbBuscarPor;
        private System.Windows.Forms.DataGridView dgvCoincidencias;
        private System.Windows.Forms.Panel pnlModificar;
        private System.Windows.Forms.Button BtnModificar;
        private System.Windows.Forms.Button BtnEliminar;
        private System.Windows.Forms.Button BtnVerTurnos;
        private System.Windows.Forms.Button BtnExportar;
        private System.Windows.Forms.Button BtnModificarHorarios;
        private System.Windows.Forms.Button BtnConfirmarTurno;
        private System.Windows.Forms.ComboBox cmbBuscarTurnos;
        private System.Windows.Forms.Button btnNuevoTurno;
    }
}
