namespace SysAcopio.Views
{
    partial class FormularioView
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
            this.textRecurso = new System.Windows.Forms.TextBox();
            this.textCategoria = new System.Windows.Forms.TextBox();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.textEstado = new System.Windows.Forms.TextBox();
            this.Recursos = new System.Windows.Forms.Label();
            this.Nombre = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Categorias = new System.Windows.Forms.Label();
            this.Agregar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textUbicacion = new System.Windows.Forms.TextBox();
            this.textFecha = new System.Windows.Forms.TextBox();
            this.Eliminar = new System.Windows.Forms.Button();
            this.Actualizar = new System.Windows.Forms.Button();
            this.Salir = new System.Windows.Forms.Button();
            this.Limpiar = new System.Windows.Forms.Button();
            this.Ubicacion = new System.Windows.Forms.Label();
            this.Fecha = new System.Windows.Forms.Label();
            this.textId = new System.Windows.Forms.TextBox();
            this.id = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // textRecurso
            // 
            this.textRecurso.Location = new System.Drawing.Point(135, 74);
            this.textRecurso.Name = "textRecurso";
            this.textRecurso.Size = new System.Drawing.Size(201, 22);
            this.textRecurso.TabIndex = 0;
            this.textRecurso.TextChanged += new System.EventHandler(this.textSolicitud_TextChanged);
            // 
            // textCategoria
            // 
            this.textCategoria.Location = new System.Drawing.Point(421, 113);
            this.textCategoria.Name = "textCategoria";
            this.textCategoria.Size = new System.Drawing.Size(201, 22);
            this.textCategoria.TabIndex = 1;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(135, 110);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(201, 22);
            this.textNombre.TabIndex = 2;
            this.textNombre.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textEstado
            // 
            this.textEstado.Location = new System.Drawing.Point(421, 74);
            this.textEstado.Name = "textEstado";
            this.textEstado.Size = new System.Drawing.Size(201, 22);
            this.textEstado.TabIndex = 3;
            // 
            // Recursos
            // 
            this.Recursos.AutoSize = true;
            this.Recursos.Location = new System.Drawing.Point(50, 74);
            this.Recursos.Name = "Recursos";
            this.Recursos.Size = new System.Drawing.Size(65, 16);
            this.Recursos.TabIndex = 4;
            this.Recursos.Text = "Recursos";
            // 
            // Nombre
            // 
            this.Nombre.AutoSize = true;
            this.Nombre.Location = new System.Drawing.Point(59, 110);
            this.Nombre.Name = "Nombre";
            this.Nombre.Size = new System.Drawing.Size(56, 16);
            this.Nombre.TabIndex = 5;
            this.Nombre.Text = "Nombre";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(365, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "Estado";
            // 
            // Categorias
            // 
            this.Categorias.AutoSize = true;
            this.Categorias.Location = new System.Drawing.Point(349, 113);
            this.Categorias.Name = "Categorias";
            this.Categorias.Size = new System.Drawing.Size(66, 16);
            this.Categorias.TabIndex = 7;
            this.Categorias.Text = "Categoria";
            // 
            // Agregar
            // 
            this.Agregar.Location = new System.Drawing.Point(976, 43);
            this.Agregar.Name = "Agregar";
            this.Agregar.Size = new System.Drawing.Size(113, 39);
            this.Agregar.TabIndex = 8;
            this.Agregar.Text = "Agregar";
            this.Agregar.UseVisualStyleBackColor = true;
            this.Agregar.Click += new System.EventHandler(this.Agregar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(38, 243);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(924, 342);
            this.dataGridView1.TabIndex = 9;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.SelectionChanged += new System.EventHandler(this.dataGridView1_SelectionChanged);
            // 
            // textUbicacion
            // 
            this.textUbicacion.Location = new System.Drawing.Point(726, 74);
            this.textUbicacion.Name = "textUbicacion";
            this.textUbicacion.Size = new System.Drawing.Size(236, 22);
            this.textUbicacion.TabIndex = 10;
            // 
            // textFecha
            // 
            this.textFecha.Location = new System.Drawing.Point(416, 151);
            this.textFecha.Name = "textFecha";
            this.textFecha.Size = new System.Drawing.Size(201, 22);
            this.textFecha.TabIndex = 11;
            // 
            // Eliminar
            // 
            this.Eliminar.Location = new System.Drawing.Point(978, 243);
            this.Eliminar.Name = "Eliminar";
            this.Eliminar.Size = new System.Drawing.Size(111, 41);
            this.Eliminar.TabIndex = 13;
            this.Eliminar.Text = "Eliminar";
            this.Eliminar.UseVisualStyleBackColor = true;
            this.Eliminar.Click += new System.EventHandler(this.Eliminar_Click);
            // 
            // Actualizar
            // 
            this.Actualizar.Location = new System.Drawing.Point(978, 116);
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(113, 41);
            this.Actualizar.TabIndex = 14;
            this.Actualizar.Text = "Actualizar";
            this.Actualizar.UseVisualStyleBackColor = true;
            this.Actualizar.Click += new System.EventHandler(this.Actualizar_Click);
            // 
            // Salir
            // 
            this.Salir.Location = new System.Drawing.Point(978, 508);
            this.Salir.Name = "Salir";
            this.Salir.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Salir.Size = new System.Drawing.Size(113, 40);
            this.Salir.TabIndex = 15;
            this.Salir.Text = "Salir";
            this.Salir.UseVisualStyleBackColor = true;
            this.Salir.Click += new System.EventHandler(this.Salir_Click);
            // 
            // Limpiar
            // 
            this.Limpiar.Location = new System.Drawing.Point(982, 318);
            this.Limpiar.Name = "Limpiar";
            this.Limpiar.Size = new System.Drawing.Size(111, 40);
            this.Limpiar.TabIndex = 16;
            this.Limpiar.Text = "Limpiar";
            this.Limpiar.UseVisualStyleBackColor = true;
            this.Limpiar.Click += new System.EventHandler(this.Limpiar_Click);
            // 
            // Ubicacion
            // 
            this.Ubicacion.AutoSize = true;
            this.Ubicacion.Location = new System.Drawing.Point(643, 80);
            this.Ubicacion.Name = "Ubicacion";
            this.Ubicacion.Size = new System.Drawing.Size(68, 16);
            this.Ubicacion.TabIndex = 17;
            this.Ubicacion.Text = "Ubicacion";
            // 
            // Fecha
            // 
            this.Fecha.AutoSize = true;
            this.Fecha.Location = new System.Drawing.Point(365, 151);
            this.Fecha.Name = "Fecha";
            this.Fecha.Size = new System.Drawing.Size(45, 16);
            this.Fecha.TabIndex = 18;
            this.Fecha.Text = "Fecha";
            this.Fecha.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // textId
            // 
            this.textId.Location = new System.Drawing.Point(135, 145);
            this.textId.Name = "textId";
            this.textId.Size = new System.Drawing.Size(201, 22);
            this.textId.TabIndex = 12;
            // 
            // id
            // 
            this.id.AutoSize = true;
            this.id.Location = new System.Drawing.Point(81, 156);
            this.id.Name = "id";
            this.id.Size = new System.Drawing.Size(18, 16);
            this.id.TabIndex = 20;
            this.id.Text = "id";
            // 
            // FormularioView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1105, 597);
            this.Controls.Add(this.id);
            this.Controls.Add(this.Fecha);
            this.Controls.Add(this.Ubicacion);
            this.Controls.Add(this.Limpiar);
            this.Controls.Add(this.Salir);
            this.Controls.Add(this.Actualizar);
            this.Controls.Add(this.Eliminar);
            this.Controls.Add(this.textId);
            this.Controls.Add(this.textFecha);
            this.Controls.Add(this.textUbicacion);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.Agregar);
            this.Controls.Add(this.Categorias);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Nombre);
            this.Controls.Add(this.Recursos);
            this.Controls.Add(this.textEstado);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.textCategoria);
            this.Controls.Add(this.textRecurso);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormularioView";
            this.Text = "FormularioView";
            this.Load += new System.EventHandler(this.FormularioView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textRecurso;
        private System.Windows.Forms.TextBox textCategoria;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.TextBox textEstado;
        private System.Windows.Forms.Label Recursos;
        private System.Windows.Forms.Label Nombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Categorias;
        private System.Windows.Forms.Button Agregar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textUbicacion;
        private System.Windows.Forms.TextBox textFecha;
        private System.Windows.Forms.Button Eliminar;
        private System.Windows.Forms.Button Actualizar;
        private System.Windows.Forms.Button Salir;
        private System.Windows.Forms.Button Limpiar;
        private System.Windows.Forms.Label Ubicacion;
        private System.Windows.Forms.Label Fecha;
        private System.Windows.Forms.TextBox textId;
        private System.Windows.Forms.Label id;
    }
}