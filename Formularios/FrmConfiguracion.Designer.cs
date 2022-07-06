namespace Formularios
{
    partial class FrmConfiguracion
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmConfiguracion));
            this.lblAutoGuardado = new System.Windows.Forms.Label();
            this.BtnAutoGuardado = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.txtDirectorio = new System.Windows.Forms.TextBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.BtnSeleccionarDirectorio = new System.Windows.Forms.Button();
            this.lblHorariosDeAtencion = new System.Windows.Forms.Label();
            this.lblNombreCentroMedico = new System.Windows.Forms.Label();
            this.txtNombreCentro = new System.Windows.Forms.TextBox();
            this.BtnGuardarNombre = new System.Windows.Forms.Button();
            this.btnCambiarHorarios = new System.Windows.Forms.Button();
            this.btnAgregarEspecialidad = new System.Windows.Forms.Button();
            this.lblEspecialidades = new System.Windows.Forms.Label();
            this.cmbEspecialidades = new System.Windows.Forms.ComboBox();
            this.BtnEliminarEspecialidad = new System.Windows.Forms.Button();
            this.lblHorarioDelCentro = new System.Windows.Forms.Label();
            this.txtAgregarEspecialidad = new System.Windows.Forms.TextBox();
            this.lblAgregarEspecialidad = new System.Windows.Forms.Label();
            this.btnGuardarEnBaseDeDatos = new System.Windows.Forms.Button();
            this.lblGuardarEnBaseDeDatos = new System.Windows.Forms.Label();
            this.lblOrigenDeDatos = new System.Windows.Forms.Label();
            this.cmbOrigenDeDatos = new System.Windows.Forms.ComboBox();
            this.btnGuardadoLocal = new System.Windows.Forms.Button();
            this.lblGuardadoLocal = new System.Windows.Forms.Label();
            this.btnConfirmarGuardado = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblAutoGuardado
            // 
            this.lblAutoGuardado.AutoSize = true;
            this.lblAutoGuardado.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAutoGuardado.Location = new System.Drawing.Point(31, 94);
            this.lblAutoGuardado.Name = "lblAutoGuardado";
            this.lblAutoGuardado.Size = new System.Drawing.Size(110, 21);
            this.lblAutoGuardado.TabIndex = 27;
            this.lblAutoGuardado.Text = "Autoguardado";
            // 
            // BtnAutoGuardado
            // 
            this.BtnAutoGuardado.BackColor = System.Drawing.Color.Transparent;
            this.BtnAutoGuardado.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.BtnAutoGuardado.FlatAppearance.BorderSize = 0;
            this.BtnAutoGuardado.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnAutoGuardado.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnAutoGuardado.ForeColor = System.Drawing.Color.Transparent;
            this.BtnAutoGuardado.ImageIndex = 1;
            this.BtnAutoGuardado.ImageList = this.imageList1;
            this.BtnAutoGuardado.Location = new System.Drawing.Point(237, 86);
            this.BtnAutoGuardado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnAutoGuardado.Name = "BtnAutoGuardado";
            this.BtnAutoGuardado.Size = new System.Drawing.Size(61, 34);
            this.BtnAutoGuardado.TabIndex = 28;
            this.BtnAutoGuardado.UseVisualStyleBackColor = false;
            this.BtnAutoGuardado.Click += new System.EventHandler(this.BtnAutoGuardado_Click);
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit;
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "habilitar.png");
            this.imageList1.Images.SetKeyName(1, "palanca.png");
            // 
            // txtDirectorio
            // 
            this.txtDirectorio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtDirectorio.Location = new System.Drawing.Point(226, 226);
            this.txtDirectorio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtDirectorio.Name = "txtDirectorio";
            this.txtDirectorio.Size = new System.Drawing.Size(340, 29);
            this.txtDirectorio.TabIndex = 29;
            this.txtDirectorio.Visible = false;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblUbicacion.Location = new System.Drawing.Point(29, 226);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(81, 21);
            this.lblUbicacion.TabIndex = 30;
            this.lblUbicacion.Text = "Ubicación:";
            this.lblUbicacion.Visible = false;
            // 
            // BtnSeleccionarDirectorio
            // 
            this.BtnSeleccionarDirectorio.Location = new System.Drawing.Point(580, 226);
            this.BtnSeleccionarDirectorio.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnSeleccionarDirectorio.Name = "BtnSeleccionarDirectorio";
            this.BtnSeleccionarDirectorio.Size = new System.Drawing.Size(89, 26);
            this.BtnSeleccionarDirectorio.TabIndex = 31;
            this.BtnSeleccionarDirectorio.Text = "Abrir";
            this.BtnSeleccionarDirectorio.UseVisualStyleBackColor = true;
            this.BtnSeleccionarDirectorio.Visible = false;
            this.BtnSeleccionarDirectorio.Click += new System.EventHandler(this.BtnSeleccionarDirectorio_Click);
            // 
            // lblHorariosDeAtencion
            // 
            this.lblHorariosDeAtencion.AutoSize = true;
            this.lblHorariosDeAtencion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblHorariosDeAtencion.Location = new System.Drawing.Point(29, 476);
            this.lblHorariosDeAtencion.Name = "lblHorariosDeAtencion";
            this.lblHorariosDeAtencion.Size = new System.Drawing.Size(149, 42);
            this.lblHorariosDeAtencion.TabIndex = 32;
            this.lblHorariosDeAtencion.Text = "Horario de Atención\r\ndel Centro Medico:";
            // 
            // lblNombreCentroMedico
            // 
            this.lblNombreCentroMedico.AutoSize = true;
            this.lblNombreCentroMedico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblNombreCentroMedico.Location = new System.Drawing.Point(29, 357);
            this.lblNombreCentroMedico.Name = "lblNombreCentroMedico";
            this.lblNombreCentroMedico.Size = new System.Drawing.Size(147, 21);
            this.lblNombreCentroMedico.TabIndex = 33;
            this.lblNombreCentroMedico.Text = "Nombre del Centro:";
            // 
            // txtNombreCentro
            // 
            this.txtNombreCentro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtNombreCentro.Location = new System.Drawing.Point(226, 357);
            this.txtNombreCentro.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtNombreCentro.Name = "txtNombreCentro";
            this.txtNombreCentro.Size = new System.Drawing.Size(340, 29);
            this.txtNombreCentro.TabIndex = 34;
            // 
            // BtnGuardarNombre
            // 
            this.BtnGuardarNombre.Location = new System.Drawing.Point(580, 357);
            this.BtnGuardarNombre.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnGuardarNombre.Name = "BtnGuardarNombre";
            this.BtnGuardarNombre.Size = new System.Drawing.Size(89, 26);
            this.BtnGuardarNombre.TabIndex = 35;
            this.BtnGuardarNombre.Text = "Guardar";
            this.BtnGuardarNombre.UseVisualStyleBackColor = true;
            this.BtnGuardarNombre.Click += new System.EventHandler(this.BtnGuardarNombre_Click);
            // 
            // btnCambiarHorarios
            // 
            this.btnCambiarHorarios.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCambiarHorarios.Location = new System.Drawing.Point(226, 671);
            this.btnCambiarHorarios.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnCambiarHorarios.Name = "btnCambiarHorarios";
            this.btnCambiarHorarios.Size = new System.Drawing.Size(347, 27);
            this.btnCambiarHorarios.TabIndex = 41;
            this.btnCambiarHorarios.Text = "Cambiar horarios";
            this.btnCambiarHorarios.UseVisualStyleBackColor = true;
            this.btnCambiarHorarios.Click += new System.EventHandler(this.btnCambiarHorarios_Click);
            // 
            // btnAgregarEspecialidad
            // 
            this.btnAgregarEspecialidad.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnAgregarEspecialidad.Location = new System.Drawing.Point(580, 399);
            this.btnAgregarEspecialidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnAgregarEspecialidad.Name = "btnAgregarEspecialidad";
            this.btnAgregarEspecialidad.Size = new System.Drawing.Size(89, 26);
            this.btnAgregarEspecialidad.TabIndex = 44;
            this.btnAgregarEspecialidad.Text = "Guardar";
            this.btnAgregarEspecialidad.UseVisualStyleBackColor = true;
            this.btnAgregarEspecialidad.Click += new System.EventHandler(this.BtnAgregarEspecialidad_Click);
            // 
            // lblEspecialidades
            // 
            this.lblEspecialidades.AutoSize = true;
            this.lblEspecialidades.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblEspecialidades.Location = new System.Drawing.Point(29, 443);
            this.lblEspecialidades.Name = "lblEspecialidades";
            this.lblEspecialidades.Size = new System.Drawing.Size(113, 21);
            this.lblEspecialidades.TabIndex = 42;
            this.lblEspecialidades.Text = "Especialidades:";
            // 
            // cmbEspecialidades
            // 
            this.cmbEspecialidades.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEspecialidades.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbEspecialidades.FormattingEnabled = true;
            this.cmbEspecialidades.Location = new System.Drawing.Point(226, 441);
            this.cmbEspecialidades.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbEspecialidades.Name = "cmbEspecialidades";
            this.cmbEspecialidades.Size = new System.Drawing.Size(340, 29);
            this.cmbEspecialidades.TabIndex = 45;
            // 
            // BtnEliminarEspecialidad
            // 
            this.BtnEliminarEspecialidad.BackColor = System.Drawing.Color.LightCoral;
            this.BtnEliminarEspecialidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.BtnEliminarEspecialidad.Location = new System.Drawing.Point(580, 438);
            this.BtnEliminarEspecialidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.BtnEliminarEspecialidad.Name = "BtnEliminarEspecialidad";
            this.BtnEliminarEspecialidad.Size = new System.Drawing.Size(36, 31);
            this.BtnEliminarEspecialidad.TabIndex = 46;
            this.BtnEliminarEspecialidad.Text = "X";
            this.BtnEliminarEspecialidad.UseVisualStyleBackColor = false;
            this.BtnEliminarEspecialidad.Click += new System.EventHandler(this.BtnEliminarEspecialidad_Click);
            // 
            // lblHorarioDelCentro
            // 
            this.lblHorarioDelCentro.AutoSize = true;
            this.lblHorarioDelCentro.Location = new System.Drawing.Point(228, 482);
            this.lblHorarioDelCentro.Name = "lblHorarioDelCentro";
            this.lblHorarioDelCentro.Size = new System.Drawing.Size(160, 15);
            this.lblHorarioDelCentro.TabIndex = 47;
            this.lblHorarioDelCentro.Text = "Descripción de todos los dias";
            // 
            // txtAgregarEspecialidad
            // 
            this.txtAgregarEspecialidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAgregarEspecialidad.Location = new System.Drawing.Point(226, 399);
            this.txtAgregarEspecialidad.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtAgregarEspecialidad.Name = "txtAgregarEspecialidad";
            this.txtAgregarEspecialidad.PlaceholderText = "Inserte especialidad";
            this.txtAgregarEspecialidad.Size = new System.Drawing.Size(340, 29);
            this.txtAgregarEspecialidad.TabIndex = 49;
            // 
            // lblAgregarEspecialidad
            // 
            this.lblAgregarEspecialidad.AutoSize = true;
            this.lblAgregarEspecialidad.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblAgregarEspecialidad.Location = new System.Drawing.Point(29, 399);
            this.lblAgregarEspecialidad.Name = "lblAgregarEspecialidad";
            this.lblAgregarEspecialidad.Size = new System.Drawing.Size(158, 21);
            this.lblAgregarEspecialidad.TabIndex = 48;
            this.lblAgregarEspecialidad.Text = "Agregar especialidad:";
            // 
            // btnGuardarEnBaseDeDatos
            // 
            this.btnGuardarEnBaseDeDatos.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardarEnBaseDeDatos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGuardarEnBaseDeDatos.FlatAppearance.BorderSize = 0;
            this.btnGuardarEnBaseDeDatos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarEnBaseDeDatos.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGuardarEnBaseDeDatos.ForeColor = System.Drawing.Color.Transparent;
            this.btnGuardarEnBaseDeDatos.ImageIndex = 1;
            this.btnGuardarEnBaseDeDatos.ImageList = this.imageList1;
            this.btnGuardarEnBaseDeDatos.Location = new System.Drawing.Point(237, 124);
            this.btnGuardarEnBaseDeDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardarEnBaseDeDatos.Name = "btnGuardarEnBaseDeDatos";
            this.btnGuardarEnBaseDeDatos.Size = new System.Drawing.Size(61, 34);
            this.btnGuardarEnBaseDeDatos.TabIndex = 51;
            this.btnGuardarEnBaseDeDatos.UseVisualStyleBackColor = false;
            this.btnGuardarEnBaseDeDatos.Visible = false;
            this.btnGuardarEnBaseDeDatos.Click += new System.EventHandler(this.btnGuardarEnBaseDeDatos_Click);
            // 
            // lblGuardarEnBaseDeDatos
            // 
            this.lblGuardarEnBaseDeDatos.AutoSize = true;
            this.lblGuardarEnBaseDeDatos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGuardarEnBaseDeDatos.Location = new System.Drawing.Point(29, 133);
            this.lblGuardarEnBaseDeDatos.Name = "lblGuardarEnBaseDeDatos";
            this.lblGuardarEnBaseDeDatos.Size = new System.Drawing.Size(202, 21);
            this.lblGuardarEnBaseDeDatos.TabIndex = 50;
            this.lblGuardarEnBaseDeDatos.Text = "Guardado en base de datos:";
            this.lblGuardarEnBaseDeDatos.Visible = false;
            // 
            // lblOrigenDeDatos
            // 
            this.lblOrigenDeDatos.AutoSize = true;
            this.lblOrigenDeDatos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblOrigenDeDatos.Location = new System.Drawing.Point(29, 180);
            this.lblOrigenDeDatos.Name = "lblOrigenDeDatos";
            this.lblOrigenDeDatos.Size = new System.Drawing.Size(124, 21);
            this.lblOrigenDeDatos.TabIndex = 53;
            this.lblOrigenDeDatos.Text = "Origen de datos:";
            this.lblOrigenDeDatos.Visible = false;
            // 
            // cmbOrigenDeDatos
            // 
            this.cmbOrigenDeDatos.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbOrigenDeDatos.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cmbOrigenDeDatos.FormattingEnabled = true;
            this.cmbOrigenDeDatos.Location = new System.Drawing.Point(228, 177);
            this.cmbOrigenDeDatos.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.cmbOrigenDeDatos.Name = "cmbOrigenDeDatos";
            this.cmbOrigenDeDatos.Size = new System.Drawing.Size(340, 29);
            this.cmbOrigenDeDatos.TabIndex = 54;
            this.cmbOrigenDeDatos.Visible = false;
            // 
            // btnGuardadoLocal
            // 
            this.btnGuardadoLocal.BackColor = System.Drawing.Color.Transparent;
            this.btnGuardadoLocal.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGuardadoLocal.FlatAppearance.BorderSize = 0;
            this.btnGuardadoLocal.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardadoLocal.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnGuardadoLocal.ForeColor = System.Drawing.Color.Transparent;
            this.btnGuardadoLocal.ImageIndex = 1;
            this.btnGuardadoLocal.ImageList = this.imageList1;
            this.btnGuardadoLocal.Location = new System.Drawing.Point(538, 124);
            this.btnGuardadoLocal.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnGuardadoLocal.Name = "btnGuardadoLocal";
            this.btnGuardadoLocal.Size = new System.Drawing.Size(60, 34);
            this.btnGuardadoLocal.TabIndex = 57;
            this.btnGuardadoLocal.UseVisualStyleBackColor = false;
            this.btnGuardadoLocal.Visible = false;
            this.btnGuardadoLocal.Click += new System.EventHandler(this.btnGuardadoLocal_Click);
            // 
            // lblGuardadoLocal
            // 
            this.lblGuardadoLocal.AutoSize = true;
            this.lblGuardadoLocal.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblGuardadoLocal.Location = new System.Drawing.Point(339, 133);
            this.lblGuardadoLocal.Name = "lblGuardadoLocal";
            this.lblGuardadoLocal.Size = new System.Drawing.Size(118, 21);
            this.lblGuardadoLocal.TabIndex = 56;
            this.lblGuardadoLocal.Text = "Guardado local:";
            this.lblGuardadoLocal.Visible = false;
            // 
            // btnConfirmarGuardado
            // 
            this.btnConfirmarGuardado.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnConfirmarGuardado.Location = new System.Drawing.Point(226, 293);
            this.btnConfirmarGuardado.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnConfirmarGuardado.Name = "btnConfirmarGuardado";
            this.btnConfirmarGuardado.Size = new System.Drawing.Size(347, 27);
            this.btnConfirmarGuardado.TabIndex = 58;
            this.btnConfirmarGuardado.Text = "Confirmar Guardado";
            this.btnConfirmarGuardado.UseVisualStyleBackColor = true;
            this.btnConfirmarGuardado.Click += new System.EventHandler(this.btnConfirmarGuardaro_Click);
            // 
            // FrmConfiguracion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 729);
            this.Controls.Add(this.btnConfirmarGuardado);
            this.Controls.Add(this.btnGuardadoLocal);
            this.Controls.Add(this.lblGuardadoLocal);
            this.Controls.Add(this.cmbOrigenDeDatos);
            this.Controls.Add(this.lblOrigenDeDatos);
            this.Controls.Add(this.btnGuardarEnBaseDeDatos);
            this.Controls.Add(this.lblGuardarEnBaseDeDatos);
            this.Controls.Add(this.txtAgregarEspecialidad);
            this.Controls.Add(this.lblAgregarEspecialidad);
            this.Controls.Add(this.lblHorarioDelCentro);
            this.Controls.Add(this.BtnEliminarEspecialidad);
            this.Controls.Add(this.cmbEspecialidades);
            this.Controls.Add(this.btnAgregarEspecialidad);
            this.Controls.Add(this.lblEspecialidades);
            this.Controls.Add(this.btnCambiarHorarios);
            this.Controls.Add(this.BtnGuardarNombre);
            this.Controls.Add(this.txtNombreCentro);
            this.Controls.Add(this.lblNombreCentroMedico);
            this.Controls.Add(this.lblHorariosDeAtencion);
            this.Controls.Add(this.BtnSeleccionarDirectorio);
            this.Controls.Add(this.lblUbicacion);
            this.Controls.Add(this.txtDirectorio);
            this.Controls.Add(this.BtnAutoGuardado);
            this.Controls.Add(this.lblAutoGuardado);
            this.Name = "FrmConfiguracion";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmConfiguracion_Load);
            this.Controls.SetChildIndex(this.lblAutoGuardado, 0);
            this.Controls.SetChildIndex(this.BtnAutoGuardado, 0);
            this.Controls.SetChildIndex(this.txtDirectorio, 0);
            this.Controls.SetChildIndex(this.lblUbicacion, 0);
            this.Controls.SetChildIndex(this.BtnSeleccionarDirectorio, 0);
            this.Controls.SetChildIndex(this.lblHorariosDeAtencion, 0);
            this.Controls.SetChildIndex(this.lblNombreCentroMedico, 0);
            this.Controls.SetChildIndex(this.txtNombreCentro, 0);
            this.Controls.SetChildIndex(this.BtnGuardarNombre, 0);
            this.Controls.SetChildIndex(this.btnCambiarHorarios, 0);
            this.Controls.SetChildIndex(this.lblEspecialidades, 0);
            this.Controls.SetChildIndex(this.btnAgregarEspecialidad, 0);
            this.Controls.SetChildIndex(this.cmbEspecialidades, 0);
            this.Controls.SetChildIndex(this.BtnEliminarEspecialidad, 0);
            this.Controls.SetChildIndex(this.lblHorarioDelCentro, 0);
            this.Controls.SetChildIndex(this.lblAgregarEspecialidad, 0);
            this.Controls.SetChildIndex(this.txtAgregarEspecialidad, 0);
            this.Controls.SetChildIndex(this.lblGuardarEnBaseDeDatos, 0);
            this.Controls.SetChildIndex(this.btnGuardarEnBaseDeDatos, 0);
            this.Controls.SetChildIndex(this.lblOrigenDeDatos, 0);
            this.Controls.SetChildIndex(this.cmbOrigenDeDatos, 0);
            this.Controls.SetChildIndex(this.lblGuardadoLocal, 0);
            this.Controls.SetChildIndex(this.btnGuardadoLocal, 0);
            this.Controls.SetChildIndex(this.btnConfirmarGuardado, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblAutoGuardado;
        private System.Windows.Forms.Button BtnAutoGuardado;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.TextBox txtDirectorio;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.Button BtnSeleccionarDirectorio;
        private System.Windows.Forms.Label lblHorariosDeAtencion;
        private System.Windows.Forms.Label lblNombreCentroMedico;
        private System.Windows.Forms.TextBox txtNombreCentro;
        private System.Windows.Forms.Button BtnGuardarNombre;
        private System.Windows.Forms.Button btnCambiarHorarios;
        private System.Windows.Forms.Button btnAgregarEspecialidad;
        private System.Windows.Forms.Label lblEspecialidades;
        private System.Windows.Forms.ComboBox cmbEspecialidades;
        private System.Windows.Forms.Button BtnEliminarEspecialidad;
        private System.Windows.Forms.Label lblHorarioDelCentro;
        private System.Windows.Forms.TextBox txtAgregarEspecialidad;
        private System.Windows.Forms.Label lblAgregarEspecialidad;
        private System.Windows.Forms.Button btnGuardarEnBaseDeDatos;
        private System.Windows.Forms.Label lblGuardarEnBaseDeDatos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnGuardadoLocal;
        private System.Windows.Forms.Label lblGuardadoLocal;
        private System.Windows.Forms.Label lblOrigenDeDatos;
        private System.Windows.Forms.ComboBox cmbOrigenDeDatos;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnConfirmarGuardado;
    }
}