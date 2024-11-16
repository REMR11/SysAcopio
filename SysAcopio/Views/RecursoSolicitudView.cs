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
        private bool primerLoading = true;

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

        /// <summary>
        /// Método para renderizar los recursos
        /// </summary>
        /// <param name="data"></param>
        void SetRecursos(DataTable data)
        {
            dgvRecursos.DataSource = data;
            dgvRecursos.Columns["id_recurso"].Visible = false;
            dgvRecursos.Columns["id_tipo_recurso"].Visible = false;
            primerLoading = false;
        }

        /// <summary>
        /// Método para filtrar los datos de los recursos
        /// </summary>
        void FiltrarDatos()
        {
            string idTipoRecurso = cmbTipoRecurso.SelectedValue.ToString();
            string nobreRecurso = txtNombreRecurso.Text.Trim();

            // Filtrar los datos
            DataRow[] filasFiltradas = SolicitudController.FiltrarDatosRecursosGrid(recursos, idTipoRecurso, nobreRecurso);

            // Verificar si hay filas filtradas
            if (!(filasFiltradas.Length > 0)) dgvRecursos.DataSource = null;
            
                // Crear un nuevo DataTable para almacenar las filas filtradas
                DataTable dtFiltrado = filasFiltradas.CopyToDataTable();
                SetRecursos(dtFiltrado);
            
        }
    }
}
