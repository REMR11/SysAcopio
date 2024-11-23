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
    public partial class FormularioEditarSolicitud : Form
    {
        public delegate void DatosGuardadosHandler(bool result, string nombreSolicitante);

        private readonly RecursoSolicitudController _recursoSolicitudController;
        private readonly SolicitudController _solicitudController;
        private DataTable recursos;
        private long idSolicitud;
        private bool isFirstLoading;
        public FormularioEditarSolicitud(long idSolicitud)
        {
            InitializeComponent();
            _recursoSolicitudController = new RecursoSolicitudController();
            _solicitudController = new SolicitudController();
            this.idSolicitud = idSolicitud;
        }

        /// <summary>
        /// Evento que se ejecuta al cargar la vista. Carga los recursos y establece los tipos de recursos.
        /// </summary>
        private void FormularioEditarSolicitud_Load(object sender, EventArgs e)
        {
            LoadRecursos();
            SetTipoRecursos();
        }
        /// <summary>
        /// Carga todos los recursos disponibles y los establece en el control de datos.
        /// </summary>
        private void LoadRecursos()
        {
            recursos = _recursoSolicitudController.GetAllRecurso();
            SetRecursos(recursos);
        }

        /// <summary>
        /// Actualiza el control de datos que muestra los detalles de los recursos seleccionados.
        /// </summary>
        private void RefreshDetalleGrid()
        {
            dgvDetalle.DataSource = null; // Limpia la fuente de datos
            RemoveDetailButtonColumn();  // Elimina la columna de botón de detalle
            dgvDetalle.DataSource = _recursoSolicitudController.detalleRecursoSolicitud; // Establece la nueva fuente de datos
            HideUnnecessaryColumns(dgvDetalle, "IdRecurso", "IdTipoRecurso"); // Oculta columnas innecesarias
            AddDeleteButtonColumn(); // Añade la columna de botón para eliminar recursos
        }

        /// <summary>
        /// Elimina la columna de botón de detalle del control de datos.
        /// </summary>
        private void RemoveDetailButtonColumn()
        {   // Elimina la columna si existe
            if (dgvDetalle.Columns.Contains("deletDetailButton")) dgvDetalle.Columns.Remove("deletDetailButton");
        }

        /// <summary>
        /// Añade una columna de botón para eliminar recursos del detalle.
        /// </summary>
        private void AddDeleteButtonColumn()
        {
            dgvDetalle.Columns.Add(new DataGridViewButtonColumn
            {
                Name = "deletDetailButton",
                HeaderText = "Eliminar Recurso del Detalle",
                Text = "Eliminar",
                UseColumnTextForButtonValue = true,
                Width = 100,
                FlatStyle = FlatStyle.Flat,
            });
        }
        /// <summary>
        /// Establece los recursos en el control de datos.
        /// </summary>
        /// <param name="recursos">Tabla que contiene los recursos a establecer.</param>
        private void SetRecursos(DataTable recursos)
        {
            dgvRecursos.DataSource = recursos; // Establece la fuente de datos
            HideUnnecessaryColumns(dgvRecursos, "id_recurso", "id_tipo_recurso"); // Oculta columnas innecesarias
            isFirstLoading = false; // Marca que ya no es la primera carga
        }

        /// <summary>
        /// Oculta las columnas especificadas en el control de datos.
        /// </summary>
        /// <param name="dgv">Control de datos en el que se ocultan las columnas.</param>
        /// <param name="columnNames">Nombres de las columnas a ocultar.</param>

        private void HideUnnecessaryColumns(DataGridView dgv, params string[] columnNames)
        {
            // Oculta la columna
            foreach (var columnName in columnNames) dgv.Columns[columnName].Visible = false;
        }

        /// <summary>
        /// Establece los tipos de recursos en el combo box.
        /// </summary>
        public void SetTipoRecursos()
        {
            DataTable tipoData = _recursoSolicitudController.GetAllTipoRecurso(); // Obtiene los tipos de recursos
            tipoData.Rows.Add(0, "Todos"); // Añade la opción "Todos"
            cmbTipoRecurso.DataSource = tipoData; // Establece la fuente de datos del combo box
            cmbTipoRecurso.DisplayMember = "nombre_tipo"; // Establece el campo a mostrar
            cmbTipoRecurso.ValueMember = "id_tipo_recurso"; // Establece el campo del val
            cmbTipoRecurso.SelectedValue = 0; // Selecciona "Todos" por defecto
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {

        }
    }
}
