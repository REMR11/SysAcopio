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
    public partial class ConfirmDialogEstate : Form
    {
        public delegate void ConfirmCallback(); // Delegado para el callback
        public delegate void CancelCallback(); // Delegado para el callback de cancelación

        private ConfirmCallback confirmCallback; // Variable para almacenar el callback de confirmación
        private CancelCallback cancelCallback; // Variable para almacenar el callback de cancelación
        public ConfirmDialogEstate(string pregunta, ConfirmCallback confirmCallback, CancelCallback cancelCallback)
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            txtMensaje.Text = pregunta;
            this.confirmCallback = confirmCallback;
            this.cancelCallback = cancelCallback;
        }
        private void btnCompletar_Click_1(object sender, EventArgs e)
        {
            confirmCallback?.Invoke(); // Invocar el callback de confirmación si no es nulo
            this.Close(); // Cerrar el formulario
        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            cancelCallback?.Invoke(); // Invocar el callback de cancelación si no es nulo
            this.Close(); // Cerrar el formulario
        }
    }
}
