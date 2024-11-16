using SysAcopio.Controllers;
using SysAcopio.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SysAcopio.Views
{
    public partial class SolicitudView : Form
    {
        private readonly SolicitudController _controller;
        private int selectedRowIndex = -1;
        private SqlDataAdapter _solicitudDataAdapter;
        private BindingSource _solicitudBindingSource;
        private DataSet _solicitudDataSet;

        public SolicitudView()
        {
            InitializeComponent();
                _controller = new SolicitudController();
        }

        private void SolicitudView_Load_1(object sender, EventArgs e)
        {
            InicializarDataGrid();
            CargarSolicitudes();
        }

        

        private void InicializarDataGrid()
        {
            _solicitudDataSet = new DataSet();
            _solicitudBindingSource = new BindingSource();
            dataGridView1.DataSource = _solicitudBindingSource;
        }

        private void CargarSolicitudes()
        {
            var solicitudes = _controller.ObtenerTodasLasSolicitudes();
            ActualizarDataGrid(solicitudes);

            dataGridView1.Columns["Id"].Visible = false;
            dataGridView1.Columns["cancelado"].Visible = false;
        }

        private void ActualizarDataGrid(IEnumerable<Solicitud> solicitudes)
        {
            DataTable dtSolicitudes = ConvertirSolicitudesADatatable(solicitudes);
            _solicitudBindingSource.DataSource = dtSolicitudes;
        }

        private DataTable ConvertirSolicitudesADatatable(IEnumerable<Solicitud> solicitudes)
        {
            var dt = new DataTable();
            dt.Columns.Add("Id", typeof(long));
            dt.Columns.Add("Ubicacion", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Estado", typeof(bool));
            dt.Columns.Add("Solicitante", typeof(string));
            dt.Columns.Add("Urgencia", typeof(byte));
            dt.Columns.Add("Motivo", typeof(string));
            dt.Columns.Add("Cancelado", typeof(bool));

            foreach (var solicitud in solicitudes)
            {
                dt.Rows.Add(solicitud.IdSolicitud, solicitud.Ubicacion, solicitud.Fecha, solicitud.Estado, solicitud.NombreSolicitante, solicitud.Urgencia, solicitud.Motivo, solicitud.IsCancel);
            }
            return dt;
        }
        private bool EsFilaSeleccionada()
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("No hay ninguna solicitud seleccionada para actualizar.");
                return false;
            }
            return true;
        }

        private Solicitud ObtenerSolicitudDesdeInputs()
        {
            long solicitudId = ObtenerIdSolicitudDeFilaSeleccionada();
            var solicitud = _controller.ObtenerSolicitudPorId(solicitudId);
            return solicitud;
        }

        private long ObtenerIdSolicitudDeFilaSeleccionada()
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[selectedRowIndex];
            return Convert.ToInt64(selectedRow.Cells["Id"].Value);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var solicitudes = ObtenerSolicitudesPorFiltro(comboBox1.SelectedIndex);
            ActualizarDataGrid(solicitudes);
        }
        private IEnumerable<Solicitud> ObtenerSolicitudesPorFiltro(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    return _controller.ObtenerTodasLasSolicitudes();
                case 1:
                    return _controller.ObtenerSolicitudesActivas();
                case 2:
                    return _controller.ObtenerSolicitudesInactivas();
                default:
                    return Enumerable.Empty<Solicitud>();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            byte urgenciaSeleccionada = (byte)(comboBox2.SelectedIndex + 1);
            var solicitudes = _controller.ObtenerSolicitudesPorUrgencia(urgenciaSeleccionada);
            ActualizarDataGrid(solicitudes);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (EsFilaIndiceValido(e.RowIndex))
            {
                selectedRowIndex = e.RowIndex;
                MostrarDetallesSolicitudSeleccionada();
            }
        }

        private bool EsFilaIndiceValido(int rowIndex) => rowIndex >= 0;

        private void MostrarDetallesSolicitudSeleccionada()
        {
            long solicitudId = ObtenerIdSolicitudDeFilaSeleccionada();
            var solicitud = _controller.ObtenerSolicitudPorId(solicitudId);

            if (solicitud != null)
            {
                MessageBox.Show($"ID de la solicitud seleccionada: {solicitudId}");
            }
            else
            {
                MessageBox.Show("No se encontró la solicitud.");
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DashBoardManager.LoadForm(new RecursoSolicitudView());
        }
    }
}
