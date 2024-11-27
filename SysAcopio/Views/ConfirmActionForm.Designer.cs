namespace SysAcopio.Views
{
    partial class ConfirmActionForm
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
            this.btnSi = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtMensaje = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSi
            // 
            this.btnSi.BackColor = System.Drawing.Color.Crimson;
            this.btnSi.FlatAppearance.BorderSize = 0;
            this.btnSi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSi.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSi.ForeColor = System.Drawing.Color.White;
            this.btnSi.Location = new System.Drawing.Point(61, 126);
            this.btnSi.Margin = new System.Windows.Forms.Padding(4);
            this.btnSi.Name = "btnSi";
            this.btnSi.Size = new System.Drawing.Size(147, 57);
            this.btnSi.TabIndex = 28;
            this.btnSi.Text = "Si eliminalo";
            this.btnSi.UseVisualStyleBackColor = false;
            this.btnSi.Click += new System.EventHandler(this.btnSi_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Black;
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(277, 126);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(147, 57);
            this.btnCancelar.TabIndex = 29;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.txtMensaje);
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 80);
            this.panel1.TabIndex = 30;
            // 
            // txtMensaje
            // 
            this.txtMensaje.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMensaje.BackColor = System.Drawing.SystemColors.ControlLight;
            this.txtMensaje.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMensaje.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMensaje.Location = new System.Drawing.Point(4, 0);
            this.txtMensaje.Multiline = true;
            this.txtMensaje.Name = "txtMensaje";
            this.txtMensaje.ReadOnly = true;
            this.txtMensaje.Size = new System.Drawing.Size(479, 97);
            this.txtMensaje.TabIndex = 2;
            this.txtMensaje.TabStop = false;
            this.txtMensaje.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ConfirmActionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 253);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSi);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ConfirmActionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnSi;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtMensaje;
    }
}