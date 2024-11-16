using SysAcopio.Controllers;
using SysAcopio.Models;
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
    public partial class RecursoSolicitudView : Form
    {
        private readonly SolicitudController _controller;

        public RecursoSolicitudView()
        {
            InitializeComponent();
            _controller = new SolicitudController();
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!EsUrgenciaSeleccionada()) return;

            var nuevaSolicitud = CrearNuevaSolicitudDesdeInputs();
            _controller.CrearSolicitud(nuevaSolicitud);

            LimpiarInputs();
        }

        private bool EsUrgenciaSeleccionada()
        {
            if (cmbUrgencia.SelectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione un valor válido para la urgencia.");
                return false;
            }
            return true;
        }

        private Solicitud CrearNuevaSolicitudDesdeInputs()
        {
            return new Solicitud(
                txtDireccion.Text,
                txtNombreSolicitante.Text,
                (byte)(cmbUrgencia.SelectedIndex + 1),
                txtMotivo.Text);
        }

        private void LimpiarInputs()
        {
            txtDireccion.Clear();
            txtNombreSolicitante.Clear();
            cmbUrgencia.SelectedIndex = 0;
            cmbEstado.Enabled = false;
            cmbEstado.SelectedIndex = 0;
            txtMotivo.Clear();
        }
    }
}
