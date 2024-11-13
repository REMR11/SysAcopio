namespace SysAcopio.Views
{
    partial class SolicitudView
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
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtUbicacion = new System.Windows.Forms.TextBox();
            this.txtNombreSolicitante = new System.Windows.Forms.TextBox();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cmbUrgencia = new System.Windows.Forms.ComboBox();
            this.lblUbicacion = new System.Windows.Forms.Label();
            this.lblNombreSolicitante = new System.Windows.Forms.Label();
            this.lblUrgencia = new System.Windows.Forms.Label();
            this.lblMotivo = new System.Windows.Forms.Label();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(26, 335);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(680, 264);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // txtUbicacion
            // 
            this.txtUbicacion.Location = new System.Drawing.Point(48, 97);
            this.txtUbicacion.Name = "txtUbicacion";
            this.txtUbicacion.Size = new System.Drawing.Size(269, 20);
            this.txtUbicacion.TabIndex = 1;
            // 
            // txtNombreSolicitante
            // 
            this.txtNombreSolicitante.Location = new System.Drawing.Point(385, 97);
            this.txtNombreSolicitante.Name = "txtNombreSolicitante";
            this.txtNombreSolicitante.Size = new System.Drawing.Size(269, 20);
            this.txtNombreSolicitante.TabIndex = 2;
            // 
            // txtMotivo
            // 
            this.txtMotivo.Location = new System.Drawing.Point(385, 167);
            this.txtMotivo.Multiline = true;
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(269, 91);
            this.txtMotivo.TabIndex = 4;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(631, 296);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Todas las solicitudes",
            "Solicitudes activas",
            "solicitudes inactivas"});
            this.comboBox1.Location = new System.Drawing.Point(555, 33);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cmbUrgencia
            // 
            this.cmbUrgencia.FormattingEnabled = true;
            this.cmbUrgencia.Items.AddRange(new object[] {
            "Necesario",
            "Urgente",
            "Super urgente"});
            this.cmbUrgencia.Location = new System.Drawing.Point(48, 167);
            this.cmbUrgencia.Name = "cmbUrgencia";
            this.cmbUrgencia.Size = new System.Drawing.Size(114, 21);
            this.cmbUrgencia.TabIndex = 9;
            // 
            // lblUbicacion
            // 
            this.lblUbicacion.AutoSize = true;
            this.lblUbicacion.Location = new System.Drawing.Point(45, 70);
            this.lblUbicacion.Name = "lblUbicacion";
            this.lblUbicacion.Size = new System.Drawing.Size(52, 13);
            this.lblUbicacion.TabIndex = 10;
            this.lblUbicacion.Text = "Direccion";
            // 
            // lblNombreSolicitante
            // 
            this.lblNombreSolicitante.AutoSize = true;
            this.lblNombreSolicitante.Location = new System.Drawing.Point(382, 70);
            this.lblNombreSolicitante.Name = "lblNombreSolicitante";
            this.lblNombreSolicitante.Size = new System.Drawing.Size(56, 13);
            this.lblNombreSolicitante.TabIndex = 11;
            this.lblNombreSolicitante.Text = "Solicitante";
            // 
            // lblUrgencia
            // 
            this.lblUrgencia.AutoSize = true;
            this.lblUrgencia.Location = new System.Drawing.Point(45, 142);
            this.lblUrgencia.Name = "lblUrgencia";
            this.lblUrgencia.Size = new System.Drawing.Size(50, 13);
            this.lblUrgencia.TabIndex = 12;
            this.lblUrgencia.Text = "Urgencia";
            // 
            // lblMotivo
            // 
            this.lblMotivo.AutoSize = true;
            this.lblMotivo.Location = new System.Drawing.Point(382, 142);
            this.lblMotivo.Name = "lblMotivo";
            this.lblMotivo.Size = new System.Drawing.Size(39, 13);
            this.lblMotivo.TabIndex = 13;
            this.lblMotivo.Text = "Motivo";
            // 
            // cmbEstado
            // 
            this.cmbEstado.Enabled = false;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbEstado.Location = new System.Drawing.Point(203, 166);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(114, 21);
            this.cmbEstado.TabIndex = 14;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(200, 142);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(40, 13);
            this.lblEstado.TabIndex = 15;
            this.lblEstado.Text = "Estado";
            // 
            // btnActualizar
            // 
            this.btnActualizar.Location = new System.Drawing.Point(524, 296);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(75, 23);
            this.btnActualizar.TabIndex = 16;
            this.btnActualizar.Text = "Actualizar";
            this.btnActualizar.UseVisualStyleBackColor = true;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // SolicitudView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 650);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.lblEstado);
            this.Controls.Add(this.cmbEstado);
            this.Controls.Add(this.lblMotivo);
            this.Controls.Add(this.lblUrgencia);
            this.Controls.Add(this.lblNombreSolicitante);
            this.Controls.Add(this.lblUbicacion);
            this.Controls.Add(this.cmbUrgencia);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.txtMotivo);
            this.Controls.Add(this.txtNombreSolicitante);
            this.Controls.Add(this.txtUbicacion);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SolicitudView";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.SolicitudView_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.TextBox txtNombreSolicitante;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox cmbUrgencia;
        private System.Windows.Forms.Label lblUbicacion;
        private System.Windows.Forms.Label lblNombreSolicitante;
        private System.Windows.Forms.Label lblUrgencia;
        private System.Windows.Forms.Label lblMotivo;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.Button btnActualizar;
    }
}