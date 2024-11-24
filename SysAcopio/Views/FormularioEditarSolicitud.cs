using SysAcopio.Controllers;
using SysAcopio.Models;
using SysAcopio.Utils;
using System;
using System.Data;
using System.Windows.Forms;

namespace SysAcopio.Views
{
    public partial class FormularioEditarSolicitud : Form
    {
        // Delegado para manejar el evento de datos guardados
        public delegate void DatosGuardadosHandler(bool result, string nombreSolicitante);

        private readonly RecursoSolicitudController _recursoSolicitudController; // Controlador para manejar recursos solicitados
        private readonly SolicitudController _solicitudController; // Controlador para manejar solicitudes
        private DataTable recursos; // Tabla para almacenar recursos
        private Recurso recursoToAdd; // Recurso seleccionado para añadir
        private long idSolicitud; // ID de la solicitud actual
        private bool isFirstLoading; // Indica si es la primera carga de datos

        
        /// <summary>
        /// Constructor de la clase. Inicializa los controladores y la ID de la solicitud.
        /// </summary>
        /// <param name="idSolicitud">ID de la solicitud a editar.</param>
        public FormularioEditarSolicitud(long idSolicitud)
        {
            InitializeComponent();
            _recursoSolicitudController = new RecursoSolicitudController();
            _solicitudController = new SolicitudController();
            this.idSolicitud = idSolicitud;
            //InitializeNuevosRecursosGrid();
        }
        
        /// <summary>
        /// Evento que se ejecuta al cargar la vista. Carga los recursos y establece los tipos de recursos.
        /// </summary>
        private void FormularioEditarSolicitud_Load(object sender, EventArgs e)
        {
            loadSolicitud(); // Carga los datos de la solicitud
            LoadRecursos(); // Carga los recursos disponibles
            setRecursosSolicitud(); // Carga los recursos específicos de la solicitud
            SetTipoRecursos(); // Establece los tipos de recursos en el combo box
        }

        /// <summary>
        /// Carga todos los recursos disponibles y los establece en el control de datos.
        /// </summary>
        private void LoadRecursos()
        {
            recursos = _recursoSolicitudController.GetAllRecurso(); // Obtiene todos los recursos
            SetRecursos(recursos); // Establece los recursos en el DataGridView
        }

        /// <summary>
        /// Carga los recursos específicos de la solicitud actual.
        /// </summary>
        private void setRecursosSolicitud()
        {
            DataTable recursos = GetRecursosBySolicitudId(this.idSolicitud); // Obtiene los recursos por ID de solicitud

            if (HasRecursos(recursos)) // Verifica si hay recursos
            {
                BindRecursosToGrid(recursos); // Vincula los recursos al DataGridView
            }
            else
            {
                ShowNoRecursosFoundMessage(); // Muestra un mensaje si no se encuentran recursos
            }
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

        private void RefreshNewRecurso()
        {
            dgvNuevosRecursos.DataSource = null;
            dgvNuevosRecursos.DataSource = _recursoSolicitudController.nuevosRecursoSolicitud;
            HideUnnecessaryColumns(dgvNuevosRecursos, "IdRecurso", "IdTipoRecurso"); // Oculta columnas innecesarias

        }
        /// <summary>
        /// Elimina la columna de botón de detalle del control de datos.
        /// </summary>
        private void RemoveDetailButtonColumn()
        {
            // Elimina la columna si existe
            if (dgvDetalle.Columns.Contains("deletDetailButton"))
                dgvDetalle.Columns.Remove("deletDetailButton");
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
            foreach (var columnName in columnNames)
                dgv.Columns[columnName].Visible = false;
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
            cmbTipoRecurso.ValueMember = "id_tipo_recurso"; // Establece el campo del valor
            cmbTipoRecurso.SelectedValue = 0; // Selecciona "Todos" por defecto
            AddDeleteButtonColumn(); // Añade la columna de botón para eliminar recursos
        }

        /// <summary>
        /// Filtra los recursos según el tipo y el nombre ingresados.
        /// </summary>
        private void FilterRecursos()
        {
            string idTipoRecurso = cmbTipoRecurso.SelectedValue.ToString(); // Obtiene el tipo de recurso seleccionado
            string nombreRecurso = txtNombreRecurso.Text.Trim(); // Obtiene el nombre del recurso ingresado

            DataRow[] filteredRows = _recursoSolicitudController.FiltrarDatosRecursosGrid(recursos, idTipoRecurso, nombreRecurso); // Filtra los recursos

            if (filteredRows.Length > 0)
            {
                DataTable dtFiltrado = filteredRows.CopyToDataTable(); // Crea una tabla filtrada
                SetRecursos(dtFiltrado); // Establece los recursos filtrados
            }
            else { dgvRecursos.DataSource = null; } // Si no hay resultados, limpia la fuente de datos
        }

        /// <summary>
        /// Obtiene los recursos asociados a una solicitud específica.
        /// </summary>
        /// <param name="solicitudId">ID de la solicitud.</param>
        /// <returns>Tabla de recursos asociados a la solicitud.</returns>
        private DataTable GetRecursosBySolicitudId(long solicitudId)
        {
            return _recursoSolicitudController.GetDetailSolicitud(solicitudId); // Llama al controlador para obtener los detalles
        }

        /// <summary>
        /// Verifica si hay recursos disponibles.
        /// </summary>
        /// <param name="recursos">Tabla de recursos a verificar.</param>
        /// <returns>True si hay recursos, de lo contrario false.</returns>
        private bool HasRecursos(DataTable recursos)
        {
            return recursos != null && recursos.Rows.Count > 0; // Verifica si la tabla no es nula y tiene filas
        }

        /// <summary>
        /// Vincula los recursos al control de datos.
        /// </summary>
        /// <param name="recursos">Tabla de recursos a vincular.</param>
        private void BindRecursosToGrid(DataTable recursos)
        {
            dgvDetalle.DataSource = recursos; // Establece la fuente de datos
            ConfigureGridColumns(); // Configura las columnas del DataGridView
        }

        /// <summary>
        /// Configura las columnas del DataGridView para mostrar los recursos.
        /// </summary>
        private void ConfigureGridColumns()
        {

            dgvDetalle.Columns["id_recurso_solicitud"].Visible = false; // Ocultar columna ID si no es necesaria
            dgvDetalle.Columns["id_solicitud"].Visible = false; // Ocultar columna ID de solicitud si no es necesaria  
            dgvDetalle.Columns["nombre_recurso"].HeaderText = "Nombre del Producto"; // Cambia el encabezado de la columna
            dgvDetalle.Columns["cantidad"].HeaderText = "Cantidad"; // Cambia el encabezado de la columna
        }

        /// <summary>
        /// Muestra un mensaje si no se encuentran recursos para la solicitud.
        /// </summary>
        private void ShowNoRecursosFoundMessage()
        {
            MessageBox.Show("No se encontraron recursos para la solicitud.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information); // Muestra un mensaje informativo
        }

        /// <summary>
        /// Carga los datos de la solicitud actual.
        /// </summary>
        private void loadSolicitud()
        {
            Solicitud solicitud = _solicitudController.ObtenerSolicitudPorId(this.idSolicitud); // Obtiene la solicitud por ID
            cmbUrgencia.SelectedIndex = solicitud.Urgencia; // Establece la urgencia en el combo box
            cmbEstado.SelectedIndex = Convert.ToInt16(solicitud.Estado); // Establece el estado en el combo box
            txtDireccion.Text = solicitud.Ubicacion.ToString();  // Establece la direcicon a la que se solicita entregar productos
            txtMotivo.Text = solicitud.Motivo; // Establece el motivo en el campo de texto
        }

        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para agregar un recurso al detalle.
        /// Valida el recurso y lo añade al detalle.
        /// </summary>
        /// <summary>
        /// Evento que se ejecuta al hacer clic en el botón para agregar un recurso al detalle.
        /// Valida el recurso y lo añade al detalle.
        /// </summary>
        private void btnAgregarDetalle_Click(object sender, EventArgs e)
        {
            if (!IsRecursoValid()) return; // Verifica si el recurso es válido

            bool exists = false;

            // Verifica si el recurso ya existe en dgvDetalle
            foreach (DataGridViewRow row in dgvDetalle.Rows)
            {
                if (row.Cells["id_recurso"].Value != null &&
                    Convert.ToInt64(row.Cells["id_recurso"].Value) == recursoToAdd.IdRecurso)
                {
                    // Si el recurso ya existe, actualiza la cantidad
                    int cantidadActual = Convert.ToInt32(row.Cells["cantidad"].Value);
                    int nuevaCantidad = cantidadActual + Convert.ToInt32(txtRecursoCantidad.Text);
                    row.Cells["cantidad"].Value = nuevaCantidad;

                    exists = true;
                    break;
                }
            }

            // Si el recurso no existe, lo agrega a dgvNuevosRecursos
            if (!exists)
            {
                int cantidadRecursos = Convert.ToInt32(txtRecursoCantidad.Text);
                _recursoSolicitudController.AddNuevoDetalle(recursoToAdd, cantidadRecursos); // Agrega la nueva fila al dgvNuevosRecursos
                RefreshNewRecurso();
            }

            ResetRecursoSelection(); // Resetea la selección del recurso
        }


        /// <summary>
        /// Verifica si el recurso seleccionado y la cantidad son válidos.
        /// </summary>
        /// <returns>True si el recurso es válido, de lo contrario false.</returns>
        private bool IsRecursoValid()
        {
            if (recursoToAdd == null || string.IsNullOrWhiteSpace(txtRecursoCantidad.Text.Trim()))
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
                    recursoToAdd = new Recurso
                    {
                        IdRecurso = Convert.ToInt64(row.Cells["id_recurso"].Value),
                        NombreRecurso = row.Cells["NombreRecurso"].Value.ToString()
                    };
                }
            }
        }

        /// <summary>
        /// Resetea la selección del recurso y limpia el campo de cantidad.
        /// </summary>
        private void ResetRecursoSelection()
        {
            recursoToAdd = null; // Resetea el recurso a añadir
            txtRecursoCantidad.Clear(); // Limpia el campo de cantidad
            dgvRecursos.ClearSelection(); // Limpia la selección en el control de datos
            dgvRecursos.CurrentCell = null; // Resetea la celda actual
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            // Lógica para actualizar la solicitud
        }

        private void btn_Cancelar_Click(object sender, EventArgs e)
        {
            DashBoardManager.LoadForm(new SolicitudView());
        }

        private void txtRecursoCantidad_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Verifica si la tecla presionada es un número (del 0 al 9)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                // Cancela el evento si la tecla no es un número
                Alerts.ShowAlertS("Debes asegurarte de ingresar numeros en este campo", AlertsType.Error); // Muestra un mensaje de error
                e.Handled = true;
            }
        }
        private void cmbEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verifica si la opción seleccionada es "Completado"
            if (cmbEstado.SelectedIndex == 0)
            {
                // Crea el formulario de confirmación
                ConfirmDialogEstate confirm = new ConfirmDialogEstate(
                    @"¿Quieres completar la solicitud? 
Esto provocará clasificar esta tarea como inactiva.",
                    ConfirmarAccion, // Callback para la acción de confirmación
                    () => cmbEstado.SelectedIndex = 1 // Callback para la acción de cancelación
                );

                // Muestra el formulario como un cuadro de diálogo modal
                confirm.ShowDialog();
            }
        }

        private void ConfirmarAccion()
        {
            // Cambia el estado a "Completado"
            cmbEstado.SelectedIndex = 0;
        }

        /// <summary>
        /// Evento que se ejecuta al cambiar la selección en el combo box de tipo de recurso.
        /// Filtra los recursos si no es la primera carga.
        /// </summary>
        private void cmbTipoRecurso_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (isFirstLoading) return; // No filtra si es la primera carga
            FilterRecursos(); // Filtra los recursos
        }

        /// <summary>
        /// Evento que se ejecuta al cambiar el texto en el campo de nombre de recurso.
        /// Filtra los recursos según el texto ingresado.
        /// </summary>
        private void txtNombreRecurso_TextChanged(object sender, EventArgs e)
        {
            FilterRecursos(); // Filtra los recursos
        }
    }
}