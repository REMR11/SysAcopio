namespace SysAcopio.Views
{
    partial class Inventario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbEstadoFiltro = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.txtNombreRecursoFiltro = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbTipoRecursoFiltro = new System.Windows.Forms.ComboBox();
            this.dgvRecursos = new System.Windows.Forms.DataGridView();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.txtId = new System.Windows.Forms.TextBox();
            this.cmbTipoRecurso = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.txtNombreRecurso = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnGenerateReport = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecursos)).BeginInit();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1126, 85);
            this.panel1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(461, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Inventario";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 85);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1126, 915);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.White;
            this.tabPage1.Controls.Add(this.btnGenerateReport);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.cmbEstadoFiltro);
            this.tabPage1.Controls.Add(this.btnBuscar);
            this.tabPage1.Controls.Add(this.btnModificar);
            this.tabPage1.Controls.Add(this.btnCrear);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.btnReiniciar);
            this.tabPage1.Controls.Add(this.txtNombreRecursoFiltro);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.cmbTipoRecursoFiltro);
            this.tabPage1.Controls.Add(this.dgvRecursos);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage1.Size = new System.Drawing.Size(1118, 882);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Gestion de Inventario";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(369, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 19);
            this.label10.TabIndex = 30;
            this.label10.Text = "Estado";
            // 
            // cmbEstadoFiltro
            // 
            this.cmbEstadoFiltro.FormattingEnabled = true;
            this.cmbEstadoFiltro.Location = new System.Drawing.Point(372, 71);
            this.cmbEstadoFiltro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbEstadoFiltro.Name = "cmbEstadoFiltro";
            this.cmbEstadoFiltro.Size = new System.Drawing.Size(141, 28);
            this.cmbEstadoFiltro.TabIndex = 29;
            // 
            // btnBuscar
            // 
            this.btnBuscar.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBuscar.ForeColor = System.Drawing.Color.Black;
            this.btnBuscar.Location = new System.Drawing.Point(540, 40);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(148, 60);
            this.btnBuscar.TabIndex = 28;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.DarkOrange;
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Location = new System.Drawing.Point(872, 202);
            this.btnModificar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(241, 40);
            this.btnModificar.TabIndex = 27;
            this.btnModificar.Text = "Modificar Recurso";
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCrear.FlatAppearance.BorderSize = 0;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Location = new System.Drawing.Point(872, 109);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(241, 40);
            this.btnCrear.TabIndex = 26;
            this.btnCrear.Text = "Crear un Recurso";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Crimson;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(872, 296);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(241, 40);
            this.button1.TabIndex = 25;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BackColor = System.Drawing.Color.LightGray;
            this.btnReiniciar.FlatAppearance.BorderSize = 0;
            this.btnReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReiniciar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.ForeColor = System.Drawing.Color.Black;
            this.btnReiniciar.Location = new System.Drawing.Point(714, 40);
            this.btnReiniciar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(148, 60);
            this.btnReiniciar.TabIndex = 24;
            this.btnReiniciar.Text = "Reiniciar Filtros";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // txtNombreRecursoFiltro
            // 
            this.txtNombreRecursoFiltro.Location = new System.Drawing.Point(189, 74);
            this.txtNombreRecursoFiltro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombreRecursoFiltro.Name = "txtNombreRecursoFiltro";
            this.txtNombreRecursoFiltro.Size = new System.Drawing.Size(157, 26);
            this.txtNombreRecursoFiltro.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(186, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(161, 19);
            this.label9.TabIndex = 22;
            this.label9.Text = "Nombre del recuso:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(16, 4);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 30);
            this.label8.TabIndex = 16;
            this.label8.Text = "Filtros:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(18, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Tipo de Recurso";
            // 
            // cmbTipoRecursoFiltro
            // 
            this.cmbTipoRecursoFiltro.FormattingEnabled = true;
            this.cmbTipoRecursoFiltro.Location = new System.Drawing.Point(21, 70);
            this.cmbTipoRecursoFiltro.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoRecursoFiltro.Name = "cmbTipoRecursoFiltro";
            this.cmbTipoRecursoFiltro.Size = new System.Drawing.Size(141, 28);
            this.cmbTipoRecursoFiltro.TabIndex = 14;
            // 
            // dgvRecursos
            // 
            this.dgvRecursos.AllowUserToAddRows = false;
            this.dgvRecursos.AllowUserToDeleteRows = false;
            this.dgvRecursos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRecursos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvRecursos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MediumTurquoise;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecursos.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvRecursos.Location = new System.Drawing.Point(21, 109);
            this.dgvRecursos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvRecursos.MultiSelect = false;
            this.dgvRecursos.Name = "dgvRecursos";
            this.dgvRecursos.ReadOnly = true;
            this.dgvRecursos.RowHeadersWidth = 51;
            this.dgvRecursos.RowTemplate.Height = 24;
            this.dgvRecursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecursos.Size = new System.Drawing.Size(844, 760);
            this.dgvRecursos.TabIndex = 6;
            this.dgvRecursos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRecursos_DataBindingComplete);
            this.dgvRecursos.SelectionChanged += new System.EventHandler(this.dgvRecursos_SelectionChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.btnCancelar);
            this.tabPage2.Controls.Add(this.button2);
            this.tabPage2.Controls.Add(this.txtId);
            this.tabPage2.Controls.Add(this.cmbTipoRecurso);
            this.tabPage2.Controls.Add(this.label7);
            this.tabPage2.Controls.Add(this.txtCantidad);
            this.tabPage2.Controls.Add(this.txtNombreRecurso);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabPage2.Size = new System.Drawing.Size(1118, 882);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Formulario Recurso";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.LightGray;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.Black;
            this.btnCancelar.Location = new System.Drawing.Point(676, 281);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(241, 111);
            this.btnCancelar.TabIndex = 28;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.ForestGreen;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(306, 281);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(241, 111);
            this.button2.TabIndex = 27;
            this.button2.Text = "Guardar";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(96, 439);
            this.txtId.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(255, 26);
            this.txtId.TabIndex = 16;
            this.txtId.Visible = false;
            // 
            // cmbTipoRecurso
            // 
            this.cmbTipoRecurso.FormattingEnabled = true;
            this.cmbTipoRecurso.Items.AddRange(new object[] {
            "Activo",
            "Inactivo"});
            this.cmbTipoRecurso.Location = new System.Drawing.Point(789, 110);
            this.cmbTipoRecurso.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoRecurso.Name = "cmbTipoRecurso";
            this.cmbTipoRecurso.Size = new System.Drawing.Size(250, 28);
            this.cmbTipoRecurso.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(432, 54);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "Cantidad";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(436, 112);
            this.txtCantidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(255, 26);
            this.txtCantidad.TabIndex = 12;
            this.txtCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCantidad_KeyPress);
            // 
            // txtNombreRecurso
            // 
            this.txtNombreRecurso.Location = new System.Drawing.Point(84, 112);
            this.txtNombreRecurso.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombreRecurso.Name = "txtNombreRecurso";
            this.txtNombreRecurso.Size = new System.Drawing.Size(255, 26);
            this.txtNombreRecurso.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(785, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(125, 20);
            this.label6.TabIndex = 5;
            this.label6.Text = "Tipo de Recurso";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(81, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre ";
            // 
            // btnGenerateReport
            // 
            this.btnGenerateReport.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnGenerateReport.FlatAppearance.BorderSize = 0;
            this.btnGenerateReport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGenerateReport.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerateReport.ForeColor = System.Drawing.Color.Black;
            this.btnGenerateReport.Location = new System.Drawing.Point(872, 381);
            this.btnGenerateReport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnGenerateReport.Name = "btnGenerateReport";
            this.btnGenerateReport.Size = new System.Drawing.Size(237, 60);
            this.btnGenerateReport.TabIndex = 31;
            this.btnGenerateReport.Text = "Generar Reporte";
            this.btnGenerateReport.UseVisualStyleBackColor = false;
            this.btnGenerateReport.Click += new System.EventHandler(this.btnGenerateReport_Click);
            // 
            // Inventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 1000);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Inventario";
            this.Text = "Inventario";
            this.Load += new System.EventHandler(this.Inventario_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecursos)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmbTipoRecurso;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.TextBox txtNombreRecurso;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvRecursos;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbTipoRecursoFiltro;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtNombreRecursoFiltro;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbEstadoFiltro;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnGenerateReport;
    }
}