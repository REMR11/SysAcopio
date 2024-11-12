using SysAcopio.Controllers;
using SysAcopio.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SysAcopio.Views
{
    public partial class SolicitudView : Form
    {

        private readonly SolicitudController _controller;
        private int selectedRowIndex = -1; // Variable para almacenar el índice de la fila seleccionada
        public SolicitudView()
        {
            InitializeComponent();
            _controller = new SolicitudController(); // Asegúrate de inicializar el controlador
        }

        SqlDataAdapter solicituDataAdapter;
        BindingSource solicitudBindingSource;
        DataSet SolicitudDS;
        private void SolicitudView_Load_1(object sender, EventArgs e)
        {
            SolicitudDS = new DataSet();
            var solicitudes = _controller.ObtenerTodasLasSolicitudes(); // Obtén las solicitudes

            DataTable dtSolicitudes = ConvertToDataTable(solicitudes);
            solicitudBindingSource = new BindingSource { DataSource = dtSolicitudes };
            dataGridView1.DataSource = solicitudBindingSource;
            dataGridView1.Columns["Id"].Visible = false;
            
            dataGridView1.Columns.Add(new DataGridViewColumn
            {
                Name = "EstadoString",
                HeaderText = "Estado",
                ReadOnly = true
            });


            // Llenar la columna "estado" con los valores formateados
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells["Estado"].Value is bool isActive)
                {
                    row.Cells["EstadoString"].Value = isActive ? "Completado" : "Pendiente";
                }
            }
        }




        private DataTable ConvertToDataTable(IEnumerable<Solicitud> solicitudes)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(long));
            dt.Columns.Add("Ubicacion", typeof(string));
            dt.Columns.Add("Fecha", typeof(DateTime));
            dt.Columns.Add("Estado", typeof(bool));
            dt.Columns.Add("Solicitante", typeof(string));
            dt.Columns.Add("Urgencia", typeof(byte));
            dt.Columns.Add("Motivo", typeof(string));
            dt.Columns.Add("cancelado", typeof(bool));
            foreach (var solicitud in solicitudes)
            {
                dt.Rows.Add(solicitud.IdSolicitud, solicitud.Ubicacion, solicitud.Fecha, solicitud.Estado, solicitud.NombreSolicitante, solicitud.Urgencia, solicitud.Motivo, solicitud.IsCancel); // Asegúrate de que las propiedades sean correctas
            }

            return dt;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Obtener los valores de los TextBox
            string ubicacion = txtUbicacion.Text;
            string nombreSolicitante = txtNombreSolicitante.Text;
            // Obtener el índice seleccionado del ComboBox
            int selectedIndex = cmbUrgencia.SelectedIndex;

            // Verificar que se haya seleccionado un índice válido
            if (selectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione un valor válido para la urgencia.");
                return; // Salir del método si no hay selección
            }

            // Asignar el valor de urgencia basado en el índice seleccionado
            byte urgencia = (byte)(selectedIndex + 1);

            string motivo = txtMotivo.Text;

            // Crear una nueva instancia de Solicitud
            Solicitud nuevaSolicitud = new Solicitud(ubicacion, nombreSolicitante, urgencia, motivo);

            // Agregar la nueva solicitud a la lista
            long idSolicitud = _controller.CrearSolicitud(nuevaSolicitud);

            // (Opcional) Limpiar los TextBox después de guardar
            clearInputs();

            var solicitudes = _controller.ObtenerTodasLasSolicitudes();

            actualizarDataGrid(solicitudes);
        }

        private void actualizarDataGrid(IEnumerable<Solicitud> solicitudes)
        {
            DataTable dt = ConvertToDataTable(solicitudes);
            solicitudBindingSource.DataSource = dt;
            dataGridView1.DataSource = solicitudBindingSource;
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var solicitudes = ObtenerSolicitudesPorSeleccion(comboBox1.SelectedIndex);
            actualizarDataGrid(solicitudes);
        }

        private IEnumerable<Solicitud> ObtenerSolicitudesPorSeleccion(int selectedIndex)
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
                    return Enumerable.Empty<Solicitud>(); // Retorna una colección vacía si no hay coincidencia
            }
        }
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (IsRowIndexValid(e.RowIndex))
            {
                selectedRowIndex = e.RowIndex;
                long solicitudId = GetSolicitudIdFromSelectedRow(e.RowIndex);
                DisplaySolicitudDetails(solicitudId);
            }
        }

        private bool IsRowIndexValid(int rowIndex)
        {
            return rowIndex >= 0;
        }

        private long GetSolicitudIdFromSelectedRow(int rowIndex)
        {
            DataGridViewRow selectedRow = dataGridView1.Rows[rowIndex];
            return Convert.ToInt64(selectedRow.Cells["Id"].Value);
        }

        private void DisplaySolicitudDetails(long solicitudId)
        {
            var solicitud = _controller.ObtenerSolicitudPorId(solicitudId);
            if (solicitud != null)
            {
                ShowSolicitudId(solicitudId);
                PopulateSolicitudFields(solicitud);
            }
            else
            {
                MessageBox.Show("No se encontró la solicitud.");
            }
        }

        private void ShowSolicitudId(long solicitudId)
        {
            MessageBox.Show($"ID de la solicitud seleccionada: {solicitudId}");
        }

        private void PopulateSolicitudFields(Solicitud solicitud)
        {
            txtUbicacion.Text = solicitud.Ubicacion;
            txtNombreSolicitante.Text = solicitud.NombreSolicitante;
            cmbUrgencia.SelectedIndex = solicitud.Urgencia;
            cmbEstado.Enabled = true;
            cmbEstado.SelectedIndex = solicitud.Estado ? 0 : 1;
            txtMotivo.Text = solicitud.Motivo;
        }
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (selectedRowIndex < 0)
            {
                MessageBox.Show("No hay ninguna solicitud seleccionada para actualizar.");
                return;
            }

            // Obtener los valores de los TextBox
            string ubicacion = txtUbicacion.Text;
            string nombreSolicitante = txtNombreSolicitante.Text;

            // Obtener el índice seleccionado del ComboBox
            int selectedIndex = cmbUrgencia.SelectedIndex;

            // Verificar que se haya seleccionado un índice válido
            if (selectedIndex < 0)
            {
                MessageBox.Show("Por favor, seleccione un valor válido para la urgencia.");
                return; // Salir del método si no hay selección
            }

            // Asignar el valor de urgencia basado en el índice seleccionado
            byte urgencia = (byte)(selectedIndex + 1);

            int selectedIndexActive = cmbEstado.SelectedIndex;
            bool isActive = selectedIndexActive == 0; // 0 para "Activo", 1 para "Inactivo"

            // Verificar que se haya seleccionado un índice válido
            if (selectedIndexActive < 0)
            {
                MessageBox.Show("Por favor, seleccione un valor válido para verificar si está activo o no.");
                return; // Salir del método si no hay selección
            }

            string motivo = txtMotivo.Text;

            long idSolicitud = GetSolicitudIdFromSelectedRow(selectedRowIndex);
            // Crear una nueva instancia de Solicitud
            var solicitudObjetivo = _controller.ObtenerSolicitudPorId(idSolicitud);

            solicitudObjetivo.Ubicacion = ubicacion;
            solicitudObjetivo.NombreSolicitante = nombreSolicitante;
            solicitudObjetivo.Urgencia = urgencia;
            solicitudObjetivo.Estado = isActive;
            solicitudObjetivo.Motivo = motivo;

            // Agregar la nueva solicitud a la lista
            bool isCompleted = _controller.ActualizarSolicitud(solicitudObjetivo);

            MessageBox.Show("Operación realizada? " + isCompleted);
            // (Opcional) Limpiar los TextBox después de guardar
            clearInputs();

            var solicitudes = _controller.ObtenerTodasLasSolicitudes();
            actualizarDataGrid(solicitudes);
        }

        private void clearInputs()
        {
            txtUbicacion.Clear();
            txtNombreSolicitante.Clear();
            cmbUrgencia.SelectedIndex = 0;
            cmbEstado.Enabled = false;
            cmbEstado.SelectedIndex = 0;
            txtMotivo.Clear();
        }
    }
}
