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
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgvRecursos = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbTipoRecurso = new System.Windows.Forms.ComboBox();
            this.txtNombreRecurso = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtRecursoCantidad = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.pnlFormulario.SuspendLayout();
            this.pnlGrids.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRecursos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1001, 68);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(388, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 40);
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
            this.pnlFormulario.Location = new System.Drawing.Point(0, 68);
            this.pnlFormulario.Name = "pnlFormulario";
            this.pnlFormulario.Size = new System.Drawing.Size(1001, 116);
            this.pnlFormulario.TabIndex = 4;
            // 
            // btnReiniciar
            // 
            this.btnReiniciar.BackColor = System.Drawing.Color.LightGray;
            this.btnReiniciar.FlatAppearance.BorderSize = 0;
            this.btnReiniciar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReiniciar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReiniciar.ForeColor = System.Drawing.Color.Black;
            this.btnReiniciar.Location = new System.Drawing.Point(773, 57);
            this.btnReiniciar.Margin = new System.Windows.Forms.Padding(4);
            this.btnReiniciar.Name = "btnReiniciar";
            this.btnReiniciar.Size = new System.Drawing.Size(214, 32);
            this.btnReiniciar.TabIndex = 25;
            this.btnReiniciar.Text = "Reiniciar";
            this.btnReiniciar.UseVisualStyleBackColor = false;
            // 
            // btnCrear
            // 
            this.btnCrear.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCrear.FlatAppearance.BorderSize = 0;
            this.btnCrear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrear.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCrear.ForeColor = System.Drawing.Color.White;
            this.btnCrear.Location = new System.Drawing.Point(532, 57);
            this.btnCrear.Margin = new System.Windows.Forms.Padding(4);
            this.btnCrear.Name = "btnCrear";
            this.btnCrear.Size = new System.Drawing.Size(214, 32);
            this.btnCrear.TabIndex = 24;
            this.btnCrear.Text = "Guardar";
            this.btnCrear.UseVisualStyleBackColor = false;
            // 
            // txtUbicación
            // 
            this.txtUbicación.Location = new System.Drawing.Point(243, 57);
            this.txtUbicación.Multiline = true;
            this.txtUbicación.Name = "txtUbicación";
            this.txtUbicación.Size = new System.Drawing.Size(262, 45);
            this.txtUbicación.TabIndex = 23;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(240, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(77, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "Ubicación:";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(435, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 26);
            this.label3.TabIndex = 16;
            this.label3.Text = "Formulario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 16);
            this.label2.TabIndex = 15;
            this.label2.Text = "Proveedores";
            // 
            // cmbProveedores
            // 
            this.cmbProveedores.FormattingEnabled = true;
            this.cmbProveedores.Location = new System.Drawing.Point(11, 63);
            this.cmbProveedores.Name = "cmbProveedores";
            this.cmbProveedores.Size = new System.Drawing.Size(205, 24);
            this.cmbProveedores.TabIndex = 14;
            // 
            // pnlGrids
            // 
            this.pnlGrids.Controls.Add(this.panel2);
            this.pnlGrids.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlGrids.Location = new System.Drawing.Point(0, 184);
            this.pnlGrids.Name = "pnlGrids";
            this.pnlGrids.Size = new System.Drawing.Size(1001, 616);
            this.pnlGrids.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.dgvRecursos);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.cmbTipoRecurso);
            this.panel2.Controls.Add(this.txtNombreRecurso);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.txtRecursoCantidad);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.lblCantidad);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(334, 616);
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
            this.dgvRecursos.Location = new System.Drawing.Point(15, 161);
            this.dgvRecursos.MultiSelect = false;
            this.dgvRecursos.Name = "dgvRecursos";
            this.dgvRecursos.ReadOnly = true;
            this.dgvRecursos.RowHeadersWidth = 51;
            this.dgvRecursos.RowTemplate.Height = 24;
            this.dgvRecursos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRecursos.Size = new System.Drawing.Size(303, 443);
            this.dgvRecursos.TabIndex = 31;
            this.dgvRecursos.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvRecursos_DataBindingComplete);
            this.dgvRecursos.SelectionChanged += new System.EventHandler(this.dgvRecursos_SelectionChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(169, 112);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 16);
            this.label7.TabIndex = 30;
            this.label7.Text = "Filtrar por tipo:";
            // 
            // cmbTipoRecurso
            // 
            this.cmbTipoRecurso.FormattingEnabled = true;
            this.cmbTipoRecurso.Location = new System.Drawing.Point(172, 131);
            this.cmbTipoRecurso.Name = "cmbTipoRecurso";
            this.cmbTipoRecurso.Size = new System.Drawing.Size(146, 24);
            this.cmbTipoRecurso.TabIndex = 29;
            this.cmbTipoRecurso.SelectedValueChanged += new System.EventHandler(this.cmbTipoRecurso_SelectedValueChanged);
            // 
            // txtNombreRecurso
            // 
            this.txtNombreRecurso.Location = new System.Drawing.Point(15, 132);
            this.txtNombreRecurso.Name = "txtNombreRecurso";
            this.txtNombreRecurso.Size = new System.Drawing.Size(151, 22);
            this.txtNombreRecurso.TabIndex = 28;
            this.txtNombreRecurso.TextChanged += new System.EventHandler(this.txtNombreRecurso_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(128, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Filtrar por nombre:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.ForestGreen;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(173, 72);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 32);
            this.button1.TabIndex = 26;
            this.button1.Text = "Agregar al detalle";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // txtRecursoCantidad
            // 
            this.txtRecursoCantidad.Location = new System.Drawing.Point(15, 78);
            this.txtRecursoCantidad.Name = "txtRecursoCantidad";
            this.txtRecursoCantidad.Size = new System.Drawing.Size(151, 22);
            this.txtRecursoCantidad.TabIndex = 22;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Century Gothic", 13F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(45, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(248, 26);
            this.label5.TabIndex = 17;
            this.label5.Text = "Seleccionar el recurso";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Font = new System.Drawing.Font("Century Gothic", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCantidad.Location = new System.Drawing.Point(12, 59);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(73, 16);
            this.lblCantidad.TabIndex = 16;
            this.lblCantidad.Text = "Cantidad:";
            // 
            // RecursoDonacionView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1001, 800);
            this.Controls.Add(this.pnlGrids);
            this.Controls.Add(this.pnlFormulario);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "RecursoDonacionView";
            this.Text = "RecursoDonacionView";
            this.Load += new System.EventHandler(this.RecursoDonacionView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.pnlFormulario.ResumeLayout(false);
            this.pnlFormulario.PerformLayout();
            this.pnlGrids.ResumeLayout(false);
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cmbTipoRecurso;
        private System.Windows.Forms.DataGridView dgvRecursos;
    }
}