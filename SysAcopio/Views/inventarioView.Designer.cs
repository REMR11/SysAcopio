namespace SysAcopio.Views
{
    partial class InventarioView
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
            this.Salir = new System.Windows.Forms.Button();
            this.Actualizar = new System.Windows.Forms.Button();
            this.Limpiar = new System.Windows.Forms.Button();
            this.Eliminar = new System.Windows.Forms.Button();
            this.Agregar = new System.Windows.Forms.Button();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.NombreRecurso = new System.Windows.Forms.Label();
            this.textIdRecurso = new System.Windows.Forms.TextBox();
            this.IdRecurso = new System.Windows.Forms.Label();
            this.textCantidad = new System.Windows.Forms.TextBox();
            this.Cantidad = new System.Windows.Forms.Label();
            this.textTipoRecurso = new System.Windows.Forms.TextBox();
            this.tiporecurso = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id_recurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Tipo_recurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cantidad_Recurso = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // Salir
            // 
            this.Salir.Location = new System.Drawing.Point(815, 464);
            this.Salir.Name = "Salir";
            this.Salir.Size = new System.Drawing.Size(89, 42);
            this.Salir.TabIndex = 0;
            this.Salir.Text = "Salir";
            this.Salir.UseVisualStyleBackColor = true;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // Actualizar
            // 
            this.Actualizar.Location = new System.Drawing.Point(814, 410);
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(90, 38);
            this.Actualizar.TabIndex = 1;
            this.Actualizar.Text = "Actualizar";
            this.Actualizar.UseVisualStyleBackColor = true;
            this.Actualizar.Click += new System.EventHandler(this.Actualizar_Click_1);
            // 
            // Limpiar
            // 
            this.Limpiar.Location = new System.Drawing.Point(815, 348);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(89, 44);
            this.Limpiar.TabIndex = 2;
            this.Limpiar.Text = "Limpiar";
            this.Limpiar.UseVisualStyleBackColor = true;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click_1);
            // 
            // Eliminar
            // 
            this.Eliminar.Location = new System.Drawing.Point(814, 289);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(90, 27);
            this.Eliminar.TabIndex = 4;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click_1);
            // 
            // Agregar
            // 
            this.Agregar.Location = new System.Drawing.Point(814, 216);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(90, 37);
            this.Agregar.TabIndex = 5;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = true;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click_1);
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(163, 55);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(147, 22);
            this.textNombre.TabIndex = 6;
            // 
            // NombreRecurso
            // 
            this.NombreRecurso.AutoSize = true;
            this.NombreRecurso.Location = new System.Drawing.Point(29, 61);
            this.NombreRecurso.Name = "NombreRecurso";
            this.NombreRecurso.Size = new System.Drawing.Size(110, 16);
            this.NombreRecurso.TabIndex = 7;
            this.NombreRecurso.Text = "Nombre Recurso";
            // 
            // textIdRecurso
            // 
            this.textIdRecurso.Location = new System.Drawing.Point(163, 104);
            this.textIdRecurso.Name = "textIdRecurso";
            this.textIdRecurso.Size = new System.Drawing.Size(100, 22);
            this.textIdRecurso.TabIndex = 8;
            // 
            // IdRecurso
            // 
            this.IdRecurso.AutoSize = true;
            this.IdRecurso.Location = new System.Drawing.Point(73, 104);
            this.IdRecurso.Name = "IdRecurso";
            this.IdRecurso.Size = new System.Drawing.Size(66, 16);
            this.IdRecurso.TabIndex = 9;
            this.IdRecurso.Text = "Id recurso";
            // 
            // textCantidad
            // 
            this.textCantidad.Location = new System.Drawing.Point(594, 55);
            this.textCantidad.Name = "textCantidad";
            this.textCantidad.Size = new System.Drawing.Size(197, 22);
            this.textCantidad.TabIndex = 10;
            // 
            // Cantidad
            // 
            this.Cantidad.AutoSize = true;
            this.Cantidad.Location = new System.Drawing.Point(502, 61);
            this.Cantidad.Name = "Cantidad";
            this.Cantidad.Size = new System.Drawing.Size(61, 16);
            this.Cantidad.TabIndex = 11;
            this.Cantidad.Text = "Cantidad";
            // 
            // textTipoRecurso
            // 
            this.textTipoRecurso.Location = new System.Drawing.Point(163, 162);
            this.textTipoRecurso.Name = "textTipoRecurso";
            this.textTipoRecurso.Size = new System.Drawing.Size(100, 22);
            this.textTipoRecurso.TabIndex = 12;
            this.textTipoRecurso.TextChanged += new System.EventHandler(this.textTipoRecurso_TextChanged);
            // 
            // tiporecurso
            // 
            this.tiporecurso.AutoSize = true;
            this.tiporecurso.Location = new System.Drawing.Point(31, 162);
            this.tiporecurso.Name = "tiporecurso";
            this.tiporecurso.Size = new System.Drawing.Size(108, 16);
            this.tiporecurso.TabIndex = 13;
            this.tiporecurso.Text = "Tipo de Recurso";
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Id_recurso,
            this.Tipo_recurso,
            this.cantidad_Recurso});
            this.dataGridView1.Location = new System.Drawing.Point(76, 212);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(715, 353);
            this.dataGridView1.TabIndex = 14;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.Width = 125;
            // 
            // Id_recurso
            // 
            this.Id_recurso.HeaderText = "Id_recurso";
            this.Id_recurso.MinimumWidth = 6;
            this.Id_recurso.Name = "Id_recurso";
            this.Id_recurso.Width = 125;
            // 
            // Tipo_recurso
            // 
            this.Tipo_recurso.HeaderText = "Tip-recurso";
            this.Tipo_recurso.MinimumWidth = 6;
            this.Tipo_recurso.Name = "Tipo_recurso";
            this.Tipo_recurso.Width = 125;
            // 
            // cantidad_Recurso
            // 
            this.cantidad_Recurso.HeaderText = "Cantida_recurso";
            this.cantidad_Recurso.MinimumWidth = 6;
            this.cantidad_Recurso.Name = "cantidad_Recurso";
            this.cantidad_Recurso.Width = 125;
            // 
            // InventarioView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(931, 577);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.tiporecurso);
            this.Controls.Add(this.textTipoRecurso);
            this.Controls.Add(this.Cantidad);
            this.Controls.Add(this.textCantidad);
            this.Controls.Add(this.IdRecurso);
            this.Controls.Add(this.textIdRecurso);
            this.Controls.Add(this.NombreRecurso);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.Agregar);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.Actualizar);
            this.Controls.Add(this.Salir);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "InventarioView";
            this.Text = "InventarioViews";
            this.Load += new System.EventHandler(this.InventarioViews_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Salir;
        private System.Windows.Forms.Button Actualizar;
        private System.Windows.Forms.Button Limpiar;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Label NombreRecurso;
        private System.Windows.Forms.TextBox textIdRecurso;
        private System.Windows.Forms.Label IdRecurso;
        private System.Windows.Forms.TextBox textCantidad;
        private System.Windows.Forms.Label Cantidad;
        private System.Windows.Forms.TextBox textTipoRecurso;
        private System.Windows.Forms.Label tiporecurso;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id_recurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn Tipo_recurso;
        private System.Windows.Forms.DataGridViewTextBoxColumn cantidad_Recurso;
    }
}