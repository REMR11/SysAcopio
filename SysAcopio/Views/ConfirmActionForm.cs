using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysAcopio.Views
{
    public partial class ConfirmActionForm : Form
    {
        public delegate void ConfirmCallback(); // Delegado para el callback
        private ConfirmCallback callback; // Variable para almacenar el callback
        public ConfirmActionForm(string pregunta, ConfirmCallback callback)
        {
            InitializeComponent();
            txtMensaje.Text = pregunta;
            this.callback = callback;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSi_Click(object sender, EventArgs e)
        {
            callback?.Invoke(); // Invocar el callback si no es nulo
            this.Close(); // Cerrar el formulario
        }
    }
}
