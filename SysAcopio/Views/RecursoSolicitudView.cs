using SysAcopio.Controllers;
using SysAcopio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysAcopio.Views
{
    public partial class RecursoSolicitudView : Form
    {
        private readonly SolicitudController _controller;
        private readonly RecursoSolicitudController _recursoSolicitudController;
        private Recurso recursoToAdd;
        private DataTable recursos;
        private bool primerLoading = true;

        public RecursoSolicitudView()
        {
            InitializeComponent();
            _controller= new SolicitudController();
            _recursoSolicitudController = new RecursoSolicitudController();
        }

        private void RecursoSolicitudView_Load(object sender, EventArgs e)
        {
            var recursos = _recursoSolicitudController.GetAllRecurso();
            SetRecursos(recursos);
        }
        /// <summary>
        /// Método para renderizar los recursos
        /// </summary>
        /// <param name="data"></param>
        private void SetRecursos(DataTable data)
        {
            dgvRecursos.DataSource = data;
            dgvRecursos.Columns["id_recurso"].Visible = false;
            dgvRecursos.Columns["id_tipo_recurso"].Visible = false;
            primerLoading = false;
        }

        /// <summary>
        /// Método para setar los tipos de recursos
        /// </summary>
        private void SetTipoRecursos()
        {
            DataTable tipoData = _recursoSolicitudController.GetAllTipoRecurso();
            tipoData.Rows.Add(0, "Todos");
            cmbTipoRecurso.DataSource = tipoData;
            cmbTipoRecurso.DisplayMember = "nombre_tipo";
            cmbTipoRecurso.ValueMember = "id_tipo_recurso";
            cmbTipoRecurso.SelectedValue = 0;
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
            if (cmbUrgencia.SelectedIndex >= 0) return true;

            MessageBox.Show("Por favor, seleccione un valor válido para la urgencia.");
            return false;
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
        /// Método para filtrar los datos de los recursos
        /// </summary>
        void FiltrarDatos()
        {
            string idTipoRecurso = cmbTipoRecurso.SelectedValue.ToString();
            string nobreRecurso = txtNombreRecurso.Text.Trim();

            // Filtrar los datos
            DataRow[] filasFiltradas = _recursoSolicitudController.FiltrarDatosRecursosGrid(recursos, idTipoRecurso, nobreRecurso);

            // Verificar si hay filas filtradas
            if (!(filasFiltradas.Length > 0)) dgvRecursos.DataSource = null;
            
            // Crear un nuevo DataTable para almacenar las filas filtradas
            DataTable dtFiltrado = filasFiltradas.CopyToDataTable();
            SetRecursos(dtFiltrado);
            
        }

        private void dgvRecursos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecursos.SelectedRows.Count > 0)
            {
                var row = dgvRecursos.CurrentRow;
                if (row != null)
                {
                    recursoToAdd = new Recurso()
                    {
                        IdRecurso = Convert.ToInt64(row.Cells["id_recurso"].Value),
                        NombreRecurso = row.Cells["NombreRecurso"].Value.ToString()
                    };
                }
            }
        }

        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {

        }
    }
}
