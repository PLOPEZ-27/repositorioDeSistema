namespace repositoriosistema
{
    partial class FrmEmpleados
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.txtAniosTrabajo = new System.Windows.Forms.TextBox();
            this.txtDireccion = new System.Windows.Forms.TextBox();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.txtCorreoElectro = new System.Windows.Forms.TextBox();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.txtbuscar = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnBuscador = new System.Windows.Forms.Button();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.lbErrorNombre = new System.Windows.Forms.Label();
            this.lbErrorTelefono = new System.Windows.Forms.Label();
            this.lbErrorCorreo = new System.Windows.Forms.Label();
            this.lbErrorArea = new System.Windows.Forms.Label();
            this.lbErrorDireccion = new System.Windows.Forms.Label();
            this.lbErrorAnios = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel1.Controls.Add(this.lbErrorAnios);
            this.panel1.Controls.Add(this.lbErrorDireccion);
            this.panel1.Controls.Add(this.lbErrorArea);
            this.panel1.Controls.Add(this.lbErrorCorreo);
            this.panel1.Controls.Add(this.lbErrorTelefono);
            this.panel1.Controls.Add(this.lbErrorNombre);
            this.panel1.Controls.Add(this.btnEliminar);
            this.panel1.Controls.Add(this.btnEditar);
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.txtAniosTrabajo);
            this.panel1.Controls.Add(this.txtDireccion);
            this.panel1.Controls.Add(this.txtArea);
            this.panel1.Controls.Add(this.txtCorreoElectro);
            this.panel1.Controls.Add(this.txtTelefono);
            this.panel1.Controls.Add(this.txtNombre);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 71);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(538, 636);
            this.panel1.TabIndex = 0;
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.Red;
            this.btnEliminar.Location = new System.Drawing.Point(254, 567);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(92, 47);
            this.btnEliminar.TabIndex = 17;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            // 
            // btnEditar
            // 
            this.btnEditar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnEditar.Location = new System.Drawing.Point(130, 567);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(89, 47);
            this.btnEditar.TabIndex = 16;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.Lime;
            this.btnGuardar.Location = new System.Drawing.Point(16, 567);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(97, 47);
            this.btnGuardar.TabIndex = 15;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtAniosTrabajo
            // 
            this.txtAniosTrabajo.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtAniosTrabajo.Location = new System.Drawing.Point(19, 506);
            this.txtAniosTrabajo.Name = "txtAniosTrabajo";
            this.txtAniosTrabajo.Size = new System.Drawing.Size(311, 22);
            this.txtAniosTrabajo.TabIndex = 14;
            this.txtAniosTrabajo.TextChanged += new System.EventHandler(this.txtAniosTrabajo_TextChanged);
            // 
            // txtDireccion
            // 
            this.txtDireccion.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtDireccion.Location = new System.Drawing.Point(16, 428);
            this.txtDireccion.Name = "txtDireccion";
            this.txtDireccion.Size = new System.Drawing.Size(311, 22);
            this.txtDireccion.TabIndex = 13;
            this.txtDireccion.TextChanged += new System.EventHandler(this.txtDireccion_TextChanged);
            // 
            // txtArea
            // 
            this.txtArea.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtArea.Location = new System.Drawing.Point(21, 361);
            this.txtArea.Name = "txtArea";
            this.txtArea.Size = new System.Drawing.Size(311, 22);
            this.txtArea.TabIndex = 12;
            this.txtArea.TextChanged += new System.EventHandler(this.txtArea_TextChanged);
            // 
            // txtCorreoElectro
            // 
            this.txtCorreoElectro.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtCorreoElectro.Location = new System.Drawing.Point(21, 287);
            this.txtCorreoElectro.Name = "txtCorreoElectro";
            this.txtCorreoElectro.Size = new System.Drawing.Size(311, 22);
            this.txtCorreoElectro.TabIndex = 11;
            this.txtCorreoElectro.TextChanged += new System.EventHandler(this.txtCorreoElectro_TextChanged);
            // 
            // txtTelefono
            // 
            this.txtTelefono.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtTelefono.Location = new System.Drawing.Point(16, 202);
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(314, 22);
            this.txtTelefono.TabIndex = 10;
            this.txtTelefono.TextChanged += new System.EventHandler(this.txtTelefono_TextChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.ForeColor = System.Drawing.SystemColors.InactiveCaptionText;
            this.txtNombre.Location = new System.Drawing.Point(16, 123);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(317, 22);
            this.txtNombre.TabIndex = 9;
            this.txtNombre.TextChanged += new System.EventHandler(this.txtNombre_TextChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Bodoni MT Condensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(17, 463);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 21);
            this.label8.TabIndex = 7;
            this.label8.Text = "Anios de Trabajo";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Bodoni MT Condensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(12, 395);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 21);
            this.label7.TabIndex = 6;
            this.label7.Text = "Direccion";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Bodoni MT Condensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(17, 328);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 21);
            this.label6.TabIndex = 5;
            this.label6.Text = "Area ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Bodoni MT Condensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(17, 254);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 21);
            this.label5.TabIndex = 4;
            this.label5.Text = "Correr Electronico";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Bodoni MT Condensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(17, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "Telefono";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Bodoni MT Condensed", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(103, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre Empleado";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Bodoni MT Condensed", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(183, 33);
            this.label1.TabIndex = 0;
            this.label1.Text = "DATOS EMPLEADOS";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.txtbuscar);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnBuscador);
            this.panel2.Controls.Add(this.dgvEmpleados);
            this.panel2.Location = new System.Drawing.Point(571, 71);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(713, 636);
            this.panel2.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.button4.Location = new System.Drawing.Point(581, 355);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(109, 60);
            this.button4.TabIndex = 4;
            this.button4.Text = "Exportar a Excel";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // txtbuscar
            // 
            this.txtbuscar.ForeColor = System.Drawing.Color.Black;
            this.txtbuscar.Location = new System.Drawing.Point(25, 48);
            this.txtbuscar.Name = "txtbuscar";
            this.txtbuscar.Size = new System.Drawing.Size(514, 22);
            this.txtbuscar.TabIndex = 3;
            this.txtbuscar.TextChanged += new System.EventHandler(this.txtbuscar_TextChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Bernard MT Condensed", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(22, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(171, 28);
            this.label2.TabIndex = 2;
            this.label2.Text = "Lista de productos";
            // 
            // btnBuscador
            // 
            this.btnBuscador.BackColor = System.Drawing.Color.Yellow;
            this.btnBuscador.Location = new System.Drawing.Point(545, 33);
            this.btnBuscador.Name = "btnBuscador";
            this.btnBuscador.Size = new System.Drawing.Size(145, 49);
            this.btnBuscador.TabIndex = 1;
            this.btnBuscador.Text = "Buscar";
            this.btnBuscador.UseVisualStyleBackColor = false;
            this.btnBuscador.Click += new System.EventHandler(this.btnBuscador_Click);
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Location = new System.Drawing.Point(27, 88);
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.RowHeadersWidth = 51;
            this.dgvEmpleados.RowTemplate.Height = 24;
            this.dgvEmpleados.Size = new System.Drawing.Size(663, 247);
            this.dgvEmpleados.TabIndex = 0;
            // 
            // lbErrorNombre
            // 
            this.lbErrorNombre.AutoSize = true;
            this.lbErrorNombre.ForeColor = System.Drawing.Color.Red;
            this.lbErrorNombre.Location = new System.Drawing.Point(121, 82);
            this.lbErrorNombre.Name = "lbErrorNombre";
            this.lbErrorNombre.Size = new System.Drawing.Size(0, 16);
            this.lbErrorNombre.TabIndex = 18;
            // 
            // lbErrorTelefono
            // 
            this.lbErrorTelefono.AutoSize = true;
            this.lbErrorTelefono.ForeColor = System.Drawing.Color.Red;
            this.lbErrorTelefono.Location = new System.Drawing.Point(79, 170);
            this.lbErrorTelefono.Name = "lbErrorTelefono";
            this.lbErrorTelefono.Size = new System.Drawing.Size(0, 16);
            this.lbErrorTelefono.TabIndex = 19;
            // 
            // lbErrorCorreo
            // 
            this.lbErrorCorreo.AutoSize = true;
            this.lbErrorCorreo.ForeColor = System.Drawing.Color.Red;
            this.lbErrorCorreo.Location = new System.Drawing.Point(127, 257);
            this.lbErrorCorreo.Name = "lbErrorCorreo";
            this.lbErrorCorreo.Size = new System.Drawing.Size(0, 16);
            this.lbErrorCorreo.TabIndex = 20;
            // 
            // lbErrorArea
            // 
            this.lbErrorArea.AutoSize = true;
            this.lbErrorArea.ForeColor = System.Drawing.Color.Red;
            this.lbErrorArea.Location = new System.Drawing.Point(60, 331);
            this.lbErrorArea.Name = "lbErrorArea";
            this.lbErrorArea.Size = new System.Drawing.Size(0, 16);
            this.lbErrorArea.TabIndex = 21;
            // 
            // lbErrorDireccion
            // 
            this.lbErrorDireccion.AutoSize = true;
            this.lbErrorDireccion.ForeColor = System.Drawing.Color.Red;
            this.lbErrorDireccion.Location = new System.Drawing.Point(75, 399);
            this.lbErrorDireccion.Name = "lbErrorDireccion";
            this.lbErrorDireccion.Size = new System.Drawing.Size(0, 16);
            this.lbErrorDireccion.TabIndex = 22;
            // 
            // lbErrorAnios
            // 
            this.lbErrorAnios.AutoSize = true;
            this.lbErrorAnios.ForeColor = System.Drawing.Color.Red;
            this.lbErrorAnios.Location = new System.Drawing.Point(121, 468);
            this.lbErrorAnios.Name = "lbErrorAnios";
            this.lbErrorAnios.Size = new System.Drawing.Size(0, 16);
            this.lbErrorAnios.TabIndex = 23;
            // 
            // FrmEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1341, 809);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmEmpleados";
            this.Text = "FrmEmpleados";
            this.Load += new System.EventHandler(this.FrmEmpleados_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDireccion;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.TextBox txtCorreoElectro;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.TextBox txtAniosTrabajo;
        private System.Windows.Forms.TextBox txtbuscar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnBuscador;
        private System.Windows.Forms.Button button4;
        public System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lbErrorAnios;
        private System.Windows.Forms.Label lbErrorDireccion;
        private System.Windows.Forms.Label lbErrorArea;
        private System.Windows.Forms.Label lbErrorCorreo;
        private System.Windows.Forms.Label lbErrorTelefono;
        private System.Windows.Forms.Label lbErrorNombre;
    }
}