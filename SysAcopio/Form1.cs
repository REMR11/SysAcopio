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
            byte urgencia;

            // Intentar convertir el texto de urgencia a byte
            if (!byte.TryParse(txtUrgencia.Text, out urgencia))
            {
                MessageBox.Show("Por favor, ingrese un valor numérico válido para la urgencia.");
                return; // Salir del método si la conversión falla
            }

            string motivo = txtMotivo.Text;

            // Crear una nueva instancia de Solicitud
            Solicitud nuevaSolicitud = new Solicitud(ubicacion, nombreSolicitante, urgencia, motivo);

            // Agregar la nueva solicitud a la lista
            long idSolicitud = _controller.CrearSolicitud(nuevaSolicitud);

            // (Opcional) Limpiar los TextBox después de guardar
            txtUbicacion.Clear();
            txtNombreSolicitante.Clear();
            txtUrgencia.Clear();
            txtMotivo.Clear();
            
            var solicitudes = _controller.ObtenerTodasLasSolicitudes();

            actualizarDataGrid(solicitudes);

        }
        private void actualizarDataGrid(IEnumerable<Solicitud> solicitudes) {
            DataTable dt = ConvertToDataTable(solicitudes);
            solicitudBindingSource.DataSource = dt;
            dataGridView1.DataSource = solicitudBindingSource;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            var solicitudes = ObtenerSolicitudesPorEstado(checkBox1.Checked);
            actualizarDataGrid(solicitudes);

        }

        private IEnumerable<Solicitud> ObtenerSolicitudesPorEstado(bool isChecked)
        {
            return isChecked ? _controller.ObtenerSolicitudesActivas() : _controller.ObtenerTodasLasSolicitudes();
        }
    }
}
