namespace SysAcopio.Views
{
    partial class RecursoDonacionView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFormulario = new System.Windows.Forms.Panel();
            this.btnReiniciar = new System.Windows.Forms.Button();
            this.btnCrear = new System.Windows.Forms.Button();
            this.txtUbicación = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbProveedores = new System.Windows.Forms.ComboBox();
            this.pnlGrids = new System.Windows.Forms.Panel();
            this.pnlDetalle = new System.Windows.Forms.Panel();
            this.btnRegistrarRecurso = new System.Windows.Forms.Button();
            this.btnRegistrarProveedor = new System.Windows.Forms.Button();
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.btnReiniciarDetalle = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvRecursos = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTipoRecurso = new System.Windows.Forms.ComboBox();
            this.txtNombreRecurso = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAgregarDetalle = new System.Windows.Forms.Button();
            this.txtRecursoCantidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.pnlGrids.SuspendLayout();
            this.pnlDetalle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecursos)).BeginInit();
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
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(436, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(254, 47);
            this.label1.TabIndex = 0;
            this.label1.Text = "Donaciones";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlFormulario
            // 
            this.pnlFormulario.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlFormulario.Controls.Add(this.btnReiniciar);
            this.pnlFormulario.Controls.Add(this.btnCrear);
            this.pnlFormulario.Controls.Add(this.txtUbicación);
            this.pnlFormulario.Controls.Add(this.label6);
            this.pnlFormulario.Controls.Add(this.label3);
            this.pnlFormulario.Controls.Add(this.label2);
            this.pnlFormulario.Controls.Add(this.cmbProveedores);
            this.pnlFormulario.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlFormulario.Location = new System.Drawing.Point(0, 85);
            this.pnlFormulario.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(1126, 144);
            this.pnlFormulario.TabIndex = 4;
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BackColor = System.Drawing.Color.LightGray;
            this.btnReiniciar.FlatAppearance.BorderSize = 0;
            this.btnReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReiniciar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.ForeColor = System.Drawing.Color.Black;
            this.btnReiniciar.Location = new System.Drawing.Point(870, 71);
            this.btnReiniciar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(241, 40);
            this.btnReiniciar.TabIndex = 25;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            this.btnReiniciar.Click += new System.EventHandler(this.btnReiniciar_Click);
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCrear.FlatAppearance.BorderSize = 0;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Location = new System.Drawing.Point(598, 71);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(241, 40);
            this.btnCrear.TabIndex = 24;
            this.btnCrear.Text = "Guardar";
            this.btnCrear.UseVisualStyleBackColor = false;
            this.btnCrear.Click += new System.EventHandler(this.btnCrear_Click);
            // 
            // txtUbicación
            // 
            this.txtUbicación.Location = new System.Drawing.Point(273, 71);
            this.txtUbicación.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtUbicación.Multiline = true;
            this.txtUbicación.Name = "txtUbicación";
            this.txtUbicación.Size = new System.Drawing.Size(294, 55);
            this.txtUbicación.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(270, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(93, 19);
            this.label6.TabIndex = 22;
            this.label6.Text = "Ubicación:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(489, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(151, 30);
            this.label3.TabIndex = 16;
            this.label3.Text = "Formulario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 15;
            this.label2.Text = "Proveedores";
            // 
            // cmbProveedores
            // 
            this.cmbProveedores.FormattingEnabled = true;
            this.cmbProveedores.Location = new System.Drawing.Point(12, 79);
            this.cmbProveedores.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbProveedores.Name = "cmbProveedores";
            this.cmbProveedores.Size = new System.Drawing.Size(230, 28);
            this.cmbProveedores.TabIndex = 14;
            // 
            // pnlGrids
            // 
            this.pnlGrids.Controls.Add(this.pnlDetalle);
            this.pnlGrids.Controls.Add(this.panel2);
            this.pnlGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrids.Location = new System.Drawing.Point(0, 229);
            this.pnlGrids.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlGrids.Name = "pnlGrids";
            this.pnlGrids.Size = new System.Drawing.Size(1126, 771);
            this.pnlGrids.TabIndex = 5;
            // 
            // pnlDetalle
            // 
            this.pnlDetalle.Controls.Add(this.btnRegistrarRecurso);
            this.pnlDetalle.Controls.Add(this.btnRegistrarProveedor);
            this.pnlDetalle.Controls.Add(this.dgvDetalle);
            this.pnlDetalle.Controls.Add(this.btnReiniciarDetalle);
            this.pnlDetalle.Controls.Add(this.label8);
            this.pnlDetalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlDetalle.Location = new System.Drawing.Point(376, 0);
            this.pnlDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pnlDetalle.Name = "pnlDetalle";
            this.pnlDetalle.Size = new System.Drawing.Size(750, 771);
            this.pnlDetalle.TabIndex = 1;
            // 
            // btnRegistrarRecurso
            // 
            this.btnRegistrarRecurso.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnRegistrarRecurso.FlatAppearance.BorderSize = 0;
            this.btnRegistrarRecurso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarRecurso.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarRecurso.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarRecurso.Location = new System.Drawing.Point(168, 75);
            this.btnRegistrarRecurso.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRegistrarRecurso.Name = "btnRegistrarRecurso";
            this.btnRegistrarRecurso.Size = new System.Drawing.Size(140, 60);
            this.btnRegistrarRecurso.TabIndex = 34;
            this.btnRegistrarRecurso.Text = "Registrar Recurso";
            this.btnRegistrarRecurso.UseVisualStyleBackColor = false;
            this.btnRegistrarRecurso.Click += new System.EventHandler(this.btnRegistrarRecurso_Click);
            // 
            // btnRegistrarProveedor
            // 
            this.btnRegistrarProveedor.BackColor = System.Drawing.Color.MediumTurquoise;
            this.btnRegistrarProveedor.FlatAppearance.BorderSize = 0;
            this.btnRegistrarProveedor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarProveedor.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarProveedor.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarProveedor.Location = new System.Drawing.Point(19, 75);
            this.btnRegistrarProveedor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRegistrarProveedor.Name = "btnRegistrarProveedor";
            this.btnRegistrarProveedor.Size = new System.Drawing.Size(140, 60);
            this.btnRegistrarProveedor.TabIndex = 33;
            this.btnRegistrarProveedor.Text = "Registrar Proveedor";
            this.btnRegistrarProveedor.UseVisualStyleBackColor = false;
            this.btnRegistrarProveedor.Click += new System.EventHandler(this.btnRegistrarProveedor_Click);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalle.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.MediumTurquoise;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDetalle.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDetalle.Location = new System.Drawing.Point(19, 141);
            this.dgvDetalle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvDetalle.MultiSelect = false;
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersWidth = 51;
            this.dgvDetalle.RowTemplate.Height = 24;
            this.dgvDetalle.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDetalle.Size = new System.Drawing.Size(717, 613);
            this.dgvDetalle.TabIndex = 32;
            this.dgvDetalle.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDetalle_CellContentClick);
            this.dgvDetalle.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvDetalle_DataBindingComplete);
            // 
            // btnReiniciarDetalle
            // 
            this.btnReiniciarDetalle.BackColor = System.Drawing.Color.LightGray;
            this.btnReiniciarDetalle.FlatAppearance.BorderSize = 0;
            this.btnReiniciarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReiniciarDetalle.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciarDetalle.ForeColor = System.Drawing.Color.Black;
            this.btnReiniciarDetalle.Location = new System.Drawing.Point(495, 91);
            this.btnReiniciarDetalle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnReiniciarDetalle.Name = "btnReiniciarDetalle";
            this.btnReiniciarDetalle.Size = new System.Drawing.Size(241, 40);
            this.btnReiniciarDetalle.TabIndex = 26;
            this.btnReiniciarDetalle.Text = "Reiniciar Detalle";
            this.btnReiniciarDetalle.UseVisualStyleBackColor = false;
            this.btnReiniciarDetalle.Click += new System.EventHandler(this.btnReiniciarDetalle_Click);
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(218, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(403, 30);
            this.label8.TabIndex = 18;
            this.label8.Text = "Detalle de los recursos a Donar";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.dgvRecursos);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cmbTipoRecurso);
            this.panel2.Controls.Add(this.txtNombreRecurso);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.btnAgregarDetalle);
            this.panel2.Controls.Add(this.txtRecursoCantidad);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblCantidad);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(376, 771);
            this.panel2.TabIndex = 0;
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
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.MediumTurquoise;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvRecursos.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvRecursos.Location = new System.Drawing.Point(17, 201);
            this.dgvRecursos.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvRecursos.MultiSelect = false;
            this.dgvRecursos.Name = "dgvRecursos";
            this.dgvRecursos.ReadOnly = true;
            this.dgvRecursos.RowHeadersWidth = 51;
            this.dgvRecursos.RowTemplate.Height = 24;
            this.dgvRecursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecursos.Size = new System.Drawing.Size(339, 552);
            this.dgvRecursos.TabIndex = 31;
            this.dgvRecursos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRecursos_DataBindingComplete);
            this.dgvRecursos.SelectionChanged += new System.EventHandler(this.dgvRecursos_SelectionChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(190, 140);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(117, 19);
            this.label7.TabIndex = 30;
            this.label7.Text = "Filtrar por tipo:";
            // 
            // cmbTipoRecurso
            // 
            this.cmbTipoRecurso.FormattingEnabled = true;
            this.cmbTipoRecurso.Location = new System.Drawing.Point(194, 164);
            this.cmbTipoRecurso.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cmbTipoRecurso.Name = "cmbTipoRecurso";
            this.cmbTipoRecurso.Size = new System.Drawing.Size(164, 28);
            this.cmbTipoRecurso.TabIndex = 29;
            this.cmbTipoRecurso.SelectedValueChanged += new System.EventHandler(this.cmbTipoRecurso_SelectedValueChanged);
            // 
            // txtNombreRecurso
            // 
            this.txtNombreRecurso.Location = new System.Drawing.Point(17, 165);
            this.txtNombreRecurso.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtNombreRecurso.Name = "txtNombreRecurso";
            this.txtNombreRecurso.Size = new System.Drawing.Size(169, 26);
            this.txtNombreRecurso.TabIndex = 28;
            this.txtNombreRecurso.TextChanged += new System.EventHandler(this.txtNombreRecurso_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(14, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 19);
            this.label4.TabIndex = 27;
            this.label4.Text = "Filtrar por nombre:";
            // 
            // btnAgregarDetalle
            // 
            this.btnAgregarDetalle.BackColor = System.Drawing.Color.ForestGreen;
            this.btnAgregarDetalle.FlatAppearance.BorderSize = 0;
            this.btnAgregarDetalle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregarDetalle.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarDetalle.ForeColor = System.Drawing.Color.White;
            this.btnAgregarDetalle.Location = new System.Drawing.Point(195, 90);
            this.btnAgregarDetalle.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAgregarDetalle.Name = "btnAgregarDetalle";
            this.btnAgregarDetalle.Size = new System.Drawing.Size(163, 40);
            this.btnAgregarDetalle.TabIndex = 26;
            this.btnAgregarDetalle.Text = "Agregar Recurso";
            this.btnAgregarDetalle.UseVisualStyleBackColor = false;
            this.btnAgregarDetalle.Click += new System.EventHandler(this.btnAgregarDetalle_Click);
            // 
            // txtRecursoCantidad
            // 
            this.txtRecursoCantidad.Location = new System.Drawing.Point(17, 98);
            this.txtRecursoCantidad.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtRecursoCantidad.Name = "txtRecursoCantidad";
            this.txtRecursoCantidad.Size = new System.Drawing.Size(169, 26);
            this.txtRecursoCantidad.TabIndex = 22;
            this.txtRecursoCantidad.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRecursoCantidad_KeyPress);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(51, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(296, 30);
            this.label5.TabIndex = 17;
            this.label5.Text = "Seleccionar el recurso";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(14, 74);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(87, 19);
            this.lblCantidad.TabIndex = 16;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // RecursoDonacionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1126, 1000);
            this.Controls.Add(this.pnlGrids);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "RecursoDonacionView";
            this.Text = "RecursoDonacionView";
            this.Load += new System.EventHandler(this.RecursoDonacionView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlGrids.ResumeLayout(false);
            this.pnlDetalle.ResumeLayout(false);
            this.pnlDetalle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecursos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlFormulario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbProveedores;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUbicación;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCrear;
        private System.Windows.Forms.Button btnReiniciar;
        private System.Windows.Forms.Panel pnlGrids;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtRecursoCantidad;
        private System.Windows.Forms.TextBox txtNombreRecurso;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnAgregarDetalle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbTipoRecurso;
        private System.Windows.Forms.DataGridView dgvRecursos;
        private System.Windows.Forms.Panel pnlDetalle;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.Button btnReiniciarDetalle;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnRegistrarRecurso;
        private System.Windows.Forms.Button btnRegistrarProveedor;
    }
}