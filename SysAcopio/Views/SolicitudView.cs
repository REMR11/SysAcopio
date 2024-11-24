using SysAcopio.Controllers;
using SysAcopio.Models;
using SysAcopio.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;

namespace SysAcopio.Views
{
    /// <summary>
    /// Clase que representa la vista para gestionar solicitudes.
    /// Hereda de <see cref="Form"/> y proporciona una interfaz de usuario para visualizar y filtrar solicitudes.
    /// </summary>
    public partial class SolicitudView : Form
    {
        private readonly SolicitudController _controller; // Controlador para gestionar solicitudes
        private int selectedRowIndex = -1; // Índice de la fila seleccionada en el DataGridView
        private SqlDataAdapter _solicitudDataAdapter; // Adaptador de datos para las solicitudes
        private BindingSource _solicitudBindingSource; // Fuente de datos para enlazar al DataGridView
        private DataSet _solicitudDataSet; // Conjunto de datos para las solicitudes

        // variables utilizadas en filtros de urgencia en solicitud
        //--------------------------------------------------------------------------------------------
        private const int EstadoTodasLasSolicitudes = 0;
        private const int EstadoSolicitudesNecesarias = 1;
        private const int EstadoSolicitudesUrgentes = 2;
        private const int EstadoSolicitudesSuperUrgentes = 3;
        //--------------------------------------------------------------------------------------------
        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="SolicitudView"/>.
        /// </summary>
        public SolicitudView()
        {
            InitializeComponent();
            _controller = new SolicitudController(); // Inicializa el controlador de solicitudes
            dbgSolicitudes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /// <summary>
        /// Evento que se ejecuta al cargar la vista. Inicializa el DataGrid y carga las solicitudes.
        /// </summary>
        private void SolicitudView_Load_1(object sender, EventArgs e)
        {
            InicializarDataGrid(); // Inicializa el DataGridView
            CargarSolicitudes(); // Carga las solicitudes desde el controlador
        }

        /// <summary>
        /// Inicializa el DataGridView y su fuente de datos.
        /// </summary>
        private void InicializarDataGrid()
        {
            _solicitudDataSet = new DataSet(); // Crea un nuevo conjunto de datos
            _solicitudBindingSource = new BindingSource(); // Crea una nueva fuente de datos
            dbgSolicitudes.DataSource = _solicitudBindingSource; // Establece la fuente de datos del DataGridView
        }

        /// <summary>
        /// Carga todas las solicitudes y actualiza el DataGridView.
        /// </summary>
        private void CargarSolicitudes()
        {
            var solicitudes = _controller.ObtenerTodasLasSolicitudes(); // Obtiene todas las solicitudes
            ActualizarDataGrid(solicitudes); // Actualiza el DataGridView con las solicitudes

            // Oculta columnas innecesarias en el DataGridView
            dbgSolicitudes.Columns["Id"].Visible = false;
            dbgSolicitudes.Columns["cancelado"].Visible = false;
        }

        /// <summary>
        /// Actualiza la fuente de datos del DataGridView con la lista de solicitudes.
        /// </summary>
        /// <param name="solicitudes">Lista de solicitudes a mostrar.</param>
        private void ActualizarDataGrid(IEnumerable<Solicitud> solicitudes)
        {
            DataTable dtSolicitudes = ConvertirSolicitudesADatatable(solicitudes); // Convierte las solicitudes a DataTable
            _solicitudBindingSource.DataSource = dtSolicitudes; // Establece la fuente de datos del BindingSource
        }

        /// <summary>
        /// Convierte una lista de solicitudes a un DataTable.
        /// </summary>
        /// <param name="solicitudes">Lista de solicitudes a convertir.</param>
        /// <returns>DataTable con la información de las solicitudes.</returns>
        private DataTable ConvertirSolicitudesADatatable(IEnumerable<Solicitud> solicitudes)
        {
            var dt = new DataTable(); // Crea un nuevo DataTable
            dt.Columns.Add("Id", typeof(long)); // Añade columna para ID
            dt.Columns.Add("Ubicacion", typeof(string)); // Añade columna para ubicación
            dt.Columns.Add("Fecha", typeof(DateTime)); // Añade columna para fecha
            dt.Columns.Add("Estado", typeof(bool)); // Añade columna para estado
            dt.Columns.Add("Solicitante", typeof(string)); // Añade columna para solicitante
            dt.Columns.Add("Urgencia", typeof(byte)); // Añade columna para urgencia
            dt.Columns.Add("Motivo", typeof(string)); // Añade columna para motivo
            dt.Columns.Add("Cancelado", typeof(bool)); // Añade columna para estado de cancelación

            // Añade cada solicitud al DataTable
            foreach (var solicitud in solicitudes)
            {
                dt.Rows.Add(solicitud.IdSolicitud, solicitud.Ubicacion, solicitud.Fecha, solicitud.Estado, solicitud.NombreSolicitante, solicitud.Urgencia, solicitud.Motivo, solicitud.IsCancel);
            }
            return dt; // Retorna el DataTable con las solicitudes
        }

        /// <summary>
        /// Evento que se ejecuta al cambiar la selección en el combo box de filtros.
        /// Filtra las solicitudes según el filtro seleccionado.
        /// </summary>
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.SelectedIndex = 0;
            var solicitudes = ObtenerSolicitudesPorFiltro(comboBox1.SelectedIndex); // Obtiene las solicitudes filtradas
            ActualizarDataGrid(solicitudes); // Actualiza el DataGridView con las solicitudes filtradas
        }


        /// <summary>
        /// Obtiene las solicitudes según el filtro seleccionado.
        /// </summary>
        /// <param name="selectedIndex">Índice del filtro seleccionado.</param>
        /// <returns>Lista de solicitudes filtradas.</returns>
        private IEnumerable<Solicitud> ObtenerSolicitudesPorFiltro(int selectedIndex)
        {
            switch (selectedIndex)
            {
                case 0:
                    return _controller.ObtenerTodasLasSolicitudes(); // Todas las solicitudes
                case 1:
                    return _controller.ObtenerSolicitudesActivas(); // Solicitudes activas
                case 2:
                    return _controller.ObtenerSolicitudesInactivas(); // Solicitudes inactivas
                default:
                    return Enumerable.Empty<Solicitud>(); // Retorna una lista vacía si no hay coincidencias
            }
        }

        /// <summary>
        /// Evento que se ejecuta al cambiar la selección en el combo box de urgencias.
        /// Filtra las solicitudes según la urgencia seleccionada y actualiza el DataGridView.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            byte urgenciaSeleccionada = ObtenerUrgenciaSeleccionada();
            var solicitudesFiltradas = ObtenerSolicitudesPorEstado(urgenciaSeleccionada); // Obtenemos IEnumerable con las solicitudes filtradas.
            ActualizarDataGrid(solicitudesFiltradas); // Actualiza el dataGrid
        }

        /// <summary>
        /// Obtiene el valor de la urgencia seleccionada en el combo box.
        /// </summary>
        /// <returns>Un byte que representa la urgencia seleccionada (1 basado en el índice).</returns>
        private byte ObtenerUrgenciaSeleccionada()
        {
            return (byte)(comboBox2.SelectedIndex); // Convierte el indice seleccionado a byte para su posterios uso.
        }

        /// <summary>
        /// Obtiene las solicitudes filtradas por urgencia.
        /// </summary>
        /// <param name="urgencia">El valor de la urgencia para filtrar las solicitudes.</param>
        /// <returns>Una colección de solicitudes que cumplen con el criterio de urgencia.</returns>
        private IEnumerable<Solicitud> ObtenerSolicitudesFiltradasPorUrgencia(byte urgencia)
        {
            return _controller.ObtenerSolicitudesPorUrgencia(urgencia);
        }

        /// <summary>
        /// Obtiene las solicitudes según el estado seleccionado en el combo box.
        /// </summary>
        /// <param name="selectIndex">El índice seleccionado en el combo box que determina el estado.</param>
        /// <returns>Una colección de solicitudes que corresponden al estado seleccionado.</returns>
        private IEnumerable<Solicitud> ObtenerSolicitudesPorEstado(int selectIndex)
        {
            switch (selectIndex)
            {
                case EstadoTodasLasSolicitudes: return _controller.ObtenerTodasLasSolicitudes(); ;
                case EstadoSolicitudesNecesarias:
                case EstadoSolicitudesUrgentes:
                case EstadoSolicitudesSuperUrgentes:
                    byte urgencia = ObtenerUrgenciaSeleccionada();
                    return ObtenerSolicitudesFiltradasPorUrgencia(urgencia);
                default: return Enumerable.Empty<Solicitud>();
            }
        }
        /// <summary>
        /// Evento que se ejecuta al hacer clic en una celda del DataGridView.
        /// Guarda el índice de la fila seleccionada.
        /// </summary>
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) selectedRowIndex = e.RowIndex; // Guarda el índice de la fila seleccionada
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de guardar.
        /// Carga la vista para gestionar recursos.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            DashBoardManager.LoadForm(new RecursoSolicitudView()); // Carga la vista de solicitud de recursos
        }

        private void btnEditarSolicitud_Click_1(object sender, EventArgs e)
        {

            if (!Sesion.isAdmin)
            {
                Alerts.ShowAlertS("¡Solo un administrador puede editar la solicitud!", AlertsType.Error);
                return;
            }
            if (dbgSolicitudes.SelectedRows.Count > 0) {
                var row = dbgSolicitudes.CurrentRow;
                if (row != null)
                {
                    long idSolicitud = Convert.ToInt32(row.Cells["Id"].Value);
                    DashBoardManager.LoadForm(new FormularioEditarSolicitud(idSolicitud));

                   //FormularioEditarSolicitud.DatosGuardadosHandler += FormularioEditar_DatosGuardados;

                }
            }
        }

        // Método que maneja el evento
        private void FormularioEditar_DatosGuardados(string campo1, string campo2)
        {
            // Aquí puedes actualizar el DataGridView o realizar otras acciones
            MessageBox.Show($"Datos guardados: {campo1}, {campo2}");
            // Actualiza el DataGridView según sea necesario
        }
    }
}