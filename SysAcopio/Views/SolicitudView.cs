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
        public SolicitudView()
        {
            InitializeComponent();
            _controller = new SolicitudController(); // Asegúrate de inicializar el controlador
        }

        SqlDataAdapter solicituDataAdapter;
        BindingSource solicitudBindingSource;
        DataSet SolicitudDS;
        private void SolicitudView_Load(object sender, EventArgs e)
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
            dt.Columns.Add("Estado", typeof(bool));
            dt.Columns.Add("Urgencia", typeof(byte));
            // Agrega otras columnas según sea necesario

            foreach (var solicitud in solicitudes)
            {
                dt.Rows.Add(solicitud.IdSolicitud, solicitud.Estado, solicitud.Urgencia); // Asegúrate de que las propiedades sean correctas
            }

            return dt;
        }
    }
}
