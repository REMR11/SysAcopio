using SysAcopio.Controllers;
using SysAcopio.Models;
using SysAcopio.Utils;
using System;
using System.Data;
using System.Windows.Forms;

namespace SysAcopio.Views
{
    /// <summary>
    /// Clase que representa la vista para gestionar solicitudes de recursos.
    /// Hereda de <see cref="Form"/> y proporciona una interfaz de usuario para crear y gestionar solicitudes de recursos.
    /// </summary>
    public partial class RecursoSolicitudView : Form
    {
        private readonly SolicitudController _solicitudController; // Controlador para gestionar solicitudes
        private readonly RecursoSolicitudController _recursoSolicitudController; // Controlador para gestionar recursos
        private Recurso _recursoToAdd; // Recurso seleccionado para añadir
        private DataTable _recursos; // Tabla que contiene los recursos disponibles
        private bool _isFirstLoading = true; // Indica si es la primera carga de la vista

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="RecursoSolicitudView"/>.
        /// </summary>
        public RecursoSolicitudView()
        {
            InitializeComponent();
            _solicitudController = new SolicitudController();
            _recursoSolicitudController = new RecursoSolicitudController();
        }


        /// <summary>
        /// Evento que se ejecuta al cargar la vista. Carga los recursos y establece los tipos de recursos.
        /// </summary>
        private void RecursoSolicitudView_Load(object sender, EventArgs e)
        {
            LoadRecursos();
            SetTipoRecursos();
        }

        /// <summary>
        /// Carga todos los recursos disponibles y los establece en el control de datos.
        /// </summary>
        private void LoadRecursos()
        {
            _recursos= _recursoSolicitudController.GetAllRecurso();
            SetRecursos(_recursos);
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
        /// Establece los recursos en el control de datos.
        /// </summary>
        /// <param name="recursos">Tabla que contiene los recursos a establecer.</param>
        private void SetRecursos(DataTable recursos)
        {
            dgvRecursos.DataSource = recursos; // Establece la fuente de datos
            HideUnnecessaryColumns(dgvRecursos, "id_recurso", "id_tipo_recurso"); // Oculta columnas innecesarias
            _isFirstLoading = false; // Marca que ya no es la primera carga
        }

        /// <summary>
        /// Oculta las columnas especificadas en el control de datos.
        /// </summary>
        /// <param name="dgv">Control de datos en el que se ocultan las columnas.</param>
        /// <param name="columnNames">Nombres de las columnas a ocultar.</param>

        private void HideUnnecessaryColumns(DataGridView dgv, params string[] columnNames)
        {
            // Oculta la columna
            foreach ( var columnName in columnNames ) dgv.Columns[columnName].Visible = false;
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

        /// <summary>
        /// Filtra los recursos según el tipo y el nombre ingresados.
        /// </summary>
        private void FilterRecursos()
        {
            string idTipoRecurso = cmbTipoRecurso.SelectedValue.ToString(); // Obtiene el tipo de recurso seleccionado
            string nombreRecurso = txtNombreRecurso.Text.Trim(); // Obtiene el nombre del recurso ingresado

            DataRow[] filteredRows = _recursoSolicitudController.FiltrarDatosRecursosGrid(_recursos, idTipoRecurso, nombreRecurso); // Filtra los recursos

            if (filteredRows.Length > 0)
            {
                DataTable dtFiltrado = filteredRows.CopyToDataTable(); // Crea una tabla filtrada
                SetRecursos(dtFiltrado); // Establece los recursos filtrados
            }
            else { dgvRecursos.DataSource = null; } // Si no hay resultados, limpia la fuente de datos
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
        /// Evento que se ejecuta al hacer clic en el botón de crear solicitud.
        /// Valida la urgencia seleccionada y crea una nueva solicitud.
        /// </summary>
        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (!IsUrgenciaSelected()) return; // Verifica si se ha seleccionado una urgencia

            var nuevaSolicitud = CreateSolicitudFromInputs(); // Crea una nueva solicitud a partir de los inputs
            long idSolicitud = _solicitudController.CrearSolicitud(nuevaSolicitud); // Crea la solicitud en el controlador

            ClearInputs(); // Limpia los inputs
            SaveRecursos(idSolicitud); // Guarda los recursos asociados a la solicitud
            RefreshDetalleGrid(); // Actualiza la vista del detalle
            Alerts.ShowAlertS("Recursos guardados exitosamente.", AlertsType.Info); // Muestra un mensaje de éxito
        }


        /// <summary>
        /// Verifica si se ha seleccionado una urgencia válida.
        /// </summary>
        /// <returns>True si se ha seleccionado una urgencia, de lo contrario false.</return
        private bool IsUrgenciaSelected()
        {
            if (cmbUrgencia.SelectedIndex >= 0) return true; // Retorna true si hay una selección válida

            MessageBox.Show("Por favor, seleccione un valor válido para la urgencia.");
            return false;
        }

        /// <summary>
        /// Crea una nueva solicitud a partir de los valores ingresados en los campos de texto.
        /// </summary>
        /// <returns>Una nueva instancia de <see cref="Solicitud"/>.</returns>
        private Solicitud CreateSolicitudFromInputs()
        {
            return new Solicitud(
                txtDireccion.Text,
                txtNombreSolicitante.Text,
                (byte)(cmbUrgencia.SelectedIndex + 1),
                txtMotivo.Text);
        }


        /// <summary>
        /// Limpia los campos de entrada de la vista.
        /// </summary>
        private void ClearInputs()
        {
            txtDireccion.Clear();
            txtNombreSolicitante.Clear();
            cmbUrgencia.SelectedIndex = 0;
            txtMotivo.Clear();
        }


        /// <summary>
        /// Guarda los recursos seleccionados en la solicitud.
        /// </summary>
        /// <param name="idSolicitud">ID de la solicitud a la que se asociarán los recursos.</param>
        private void SaveRecursos(long idSolicitud)
        {
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                var recurso = new Recurso
                {
                    IdRecurso = Convert.ToInt64(row.Cells["IdRecurso"].Value),
                    Cantidad = Convert.ToInt32(row.Cells["Cantidad"].Value)
                };

                long result = _recursoSolicitudController.Create(recurso, idSolicitud); // Guarda el recurso en el controlador
                if (result <= 0)
                {
                    Alerts.ShowAlertS("Error al guardar el recurso.", AlertsType.Error); // Muestra un mensaje de error
                    return;
                }
            }
        }

        /// <summary>
        /// Evento que se ejecuta al cambiar la selección en el control de datos de recursos.
        /// Establece el recurso seleccionado para añadir al detalle.
        /// </summary>
        private void dgvRecursos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvRecursos.SelectedRows.Count > 0)
            {
                var row = dgvRecursos.CurrentRow;
                if (row != null)
                {
                    _recursoToAdd = new Recurso
                    {
                        IdRecurso = Convert.ToInt64(row.Cells["id_recurso"].Value),
                        NombreRecurso = row.Cells["NombreRecurso"].Value.ToString()
                    };
                }
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para agregar un recurso al detalle.
        /// Valida el recurso y lo añade al detalle.
        /// </summary>
        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (!IsRecursoValid()) return; // Verifica si el recurso es válido

            if (_recursoSolicitudController.AddDetalle(_recursoToAdd, Convert.ToInt32(txtRecursoCantidad.Text)))
            {
                ResetRecursoSelection(); // Resetea la selección del recurso
                RefreshDetalleGrid(); // Actualiza la vista del detalle
            }
            DashBoardManager.LoadForm(new SolicitudView()); // Carga la vista de solicitud
        }


        /// <summary>
        /// Evento que se ejecuta al cambiar el texto en el campo de nombre de recurso.
        /// Filtra los recursos según el texto ingresado.
        /// </summary>
        private void txtNombreRecurso_TextChanged(object sender, EventArgs e)
        {
            FilterRecursos(); // Filtra los recursos
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para reiniciar el detalle.
        /// Limpia el detalle de recursos seleccionados.
        /// </summary>
        private void btnReiniciarDetalle_Click(object sender, EventArgs e)
        {
            _recursoSolicitudController.detalleRecursoSolicitud.Clear(); // Limpia el detalle
            RefreshDetalleGrid(); // Actualiza la vista del detalle
        }

        /// <summary>
        /// Verifica si el recurso seleccionado y la cantidad son válidos.
        /// </summary>
        /// <returns>True si el recurso es válido, de lo contrario false.</returns>
        private bool IsRecursoValid()
        {
            if (_recursoToAdd == null || string.IsNullOrWhiteSpace(txtRecursoCantidad.Text.Trim()))
            {
                Alerts.ShowAlertS("Debe seleccionar un recurso e indicar la cantidad para añadir", AlertsType.Info); // Muestra un mensaje de error
                return false;
            }

            if (Convert.ToInt32(txtRecursoCantidad.Text) <= 0)
            {
                Alerts.ShowAlertS("La cantidad a donar debe ser mayor que 0", AlertsType.Info); // Muestra un mensaje de error
                return false;
            }

            return true; // Retorna true si es válido
        }


        /// <summary>
        /// Resetea la selección del recurso y limpia el campo de cantidad.
        /// </summary>
        private void ResetRecursoSelection()
        {
            _recursoToAdd = null; // Resetea el recurso a añadir
            txtRecursoCantidad.Clear(); // Limpia el campo de cantidad
            dgvRecursos.ClearSelection(); // Limpia la selección en el control de datos
            dgvRecursos.CurrentCell = null; // Resetea la celda actual
        }


        /// <summary>
        /// Evento que se ejecuta al cambiar la selección en el combo box de tipo de recurso.
        /// Filtra los recursos si no es la primera carga.
        /// </summary>
        private void cmbTipoRecurso_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isFirstLoading) return; // No filtra si es la primera carga
            FilterRecursos(); // Filtra los recursos
        }


        /// <summary>
        /// Evento que se ejecuta al presionar una tecla en el campo de cantidad de recurso.
        /// Permite solo la entrada de dígitos.
        /// </summary>
        private void txtRecursoCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Evita la entrada de caracteres no numéricos
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private DataTable _detalleDataTable; // Add this field to hold the detail data



        /// <summary>
        /// Evento que se ejecuta al hacer clic en una celda del detalle.
        /// Elimina el recurso del detalle si se hace clic en el botón de eliminar.
        /// </summary>
        private void dgvDetalle_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvDetalle.Columns["deletDetailButton"].Index && e.RowIndex >= 0)
            {
                long idRecurso = Convert.ToInt64(dgvDetalle.Rows[e.RowIndex].Cells["idRecurso"].Value);

                _recursoSolicitudController.RemoveFromDetail(idRecurso); // Elimina el recurso del deta
                RefreshDetalleGrid(); // Actualiza la vista del detalle
            }
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de reiniciar.
        /// Limpia todos los campos de entrada y resetea la selección del recurso.
        /// </summary>
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            ClearInputs(); // Limpia los campos de entrada
            ResetRecursoSelection(); // Resetea la selección del recurso
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón de cancelar.
        /// Carga la vista de solicitudes.
        /// </summary>
        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            DashBoardManager.LoadForm(new SolicitudView()); // Carga la vista de solicitud
        }
    }
}