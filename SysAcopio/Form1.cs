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

namespace SysAcopio
{
    public partial class Form1 : Form
    {
        private readonly SolicitudController _controller;
        public Form1()
        {
            InitializeComponent();
            _controller = new SolicitudController();
        }

        SqlDataAdapter solicituDataAdapter;
        BindingSource solicitudBindingSource;
        DataSet SolicitudDS;
        private void Form1_Load(object sender, EventArgs e)
        {
            SolicitudDS = new DataSet();
            var solicitudes = _controller.ObtenerTodasLasSolicitudes(); // Obtén las solicitudes

            DataTable dtSolicitudes = ConvertToDataTable(solicitudes);
            solicitudBindingSource = new BindingSource { DataSource = dtSolicitudes };
            dataGridView1.DataSource = solicitudBindingSource;
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
            dt.Columns.Add("Motivo", typeof (string));
            dt.Columns.Add("cancelado", typeof(bool));
            // Agrega otras columnas según sea necesario

            foreach (var solicitud in solicitudes)
            {
                dt.Rows.Add(solicitud.IdSolicitud, solicitud.Ubicacion,solicitud.Fecha, solicitud.Estado, solicitud.NombreSolicitante, solicitud.Urgencia, solicitud.Motivo, solicitud.IsCancel); // Asegúrate de que las propiedades sean correctas
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
            txtUbicacion.Clear();
            txtNombreSolicitante.Clear();
            cmbUrgencia.SelectedIndex = 0;
            txtMotivo.Clear();
            
            var solicitudes = _controller.ObtenerTodasLasSolicitudes();

            actualizarDataGrid(solicitudes);

        }
        private void actualizarDataGrid(IEnumerable<Solicitud> solicitudes) {
            DataTable dt = ConvertToDataTable(solicitudes);
            solicitudBindingSource.DataSource = dt;
            dataGridView1.DataSource = solicitudBindingSource;
        }

     

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Asegúrate de que se haya hecho clic en una fila válida
            if (e.RowIndex >= 0)
            {
                // Obtener la fila seleccionada
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                // Extraer el ID de la columna correspondiente (asumiendo que la columna del ID es la primera)
                long idSolicitud = Convert.ToInt64(selectedRow.Cells["Id"].Value);

                // Ahora puedes usar idSolicitud en tus métodos
                MessageBox.Show($"ID de la solicitud seleccionada: {idSolicitud}");

                // Aquí puedes llamar a otros métodos y pasar el idSolicitud como parámetro
                // Por ejemplo: RealizarAccionConSolicitud(idSolicitud);

                var solicitud = _controller.ObtenerSolicitudPorId(idSolicitud);
                txtUbicacion.Text = solicitud.Ubicacion;
                txtNombreSolicitante.Text = solicitud.NombreSolicitante;
                cmbUrgencia.SelectedIndex = solicitud.Urgencia;
                txtMotivo.Text = solicitud.Motivo;

            }
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
