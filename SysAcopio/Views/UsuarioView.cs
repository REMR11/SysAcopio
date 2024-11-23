using SysAcopio.Controllers;
using SysAcopio.Models;
using SysAcopio.Repositories;
using SysAcopio.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;


namespace SysAcopio.Views
{
    public partial class UsuarioView : Form
    {
        private UsuarioRepository usuarioRepository;
        private UsuarioController usuarioController;
        private long usuarioIdSeleccionado; 
        public UsuarioView()
        {
            InitializeComponent();
            usuarioController = new UsuarioController();// inicializa el controlador de usuarios 
            usuarioRepository = new UsuarioRepository();//inicializa el repositorio de usuarios
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;// establece la seleccion de filas
            ConfigureComboBoxes();// configura los comboBoxes de la vista
 
        }
        // Evento que se ejecuta al cargar la vista 
        private void UsuarioView_Load(object sender, EventArgs e)
        {
            LoadUsuarios(); // Carga los usuarios en el DataGrid
            MostrarTabPage1(); //Muestra la primemra pestaña del Tabcontrol
        }
        //Metodo para cargar los usuarios desde el controlador 
        private void LoadUsuarios()
        {
            try
            {
                // Obtener los datos de usuarios desde el controlador
                DataTable dataTable = usuarioController.ObtenerUsuariosDataTable();
                // Filtrar usuarios inactivos
                DataView dataView = new DataView(dataTable);
                dataView.RowFilter = "estado = true";
                // Asigna el DataTable al DataGridView
                dataGridView.DataSource = dataTable;

                OcultarColumnas(); // oculta algunas columnas en el datagrid
            }
            catch (Exception ex)
            {
                Alerts.ShowAlertS("Error al cargar los datos de usuarios: " + ex.Message, AlertsType.Error);
            }
        }
        //Muestra la primera pestaña en el TabControl
        private void MostrarTabPage1()
        {
            if (!tabControl1.TabPages.Contains(tabPage1))
            {
                tabControl1.TabPages.Add(tabPage1); // Agregar tabPage1
            }

            if (tabControl1.TabPages.Contains(tabPage2))
            {
                tabControl1.TabPages.Remove(tabPage2); // Quitar tabPage2
            }

            tabControl1.SelectedTab = tabPage1; // Seleccionar tabPage1
        }
        //Muestra la segunda pestaña en el TabControl
        private void MostrarTabPage2()
        {
            if (!tabControl1.TabPages.Contains(tabPage2))
            {
                tabControl1.TabPages.Add(tabPage2); // Agregar tabPage2
            }

            if (tabControl1.TabPages.Contains(tabPage1))
            {
                tabControl1.TabPages.Remove(tabPage1); // Quitar tabPage1
            }

            tabControl1.SelectedTab = tabPage2; // Seleccionar tabPage2
        }
        //Oculta columnas en el DataGridView
        private void OcultarColumnas()
        {  //Estable las columnas a ocultar
            var columnasOcultar = new[] { "IdUsuario", "Contrasenia", "id_usuario" };
            //recorre todas las columnas en el datagridview
            foreach (var columna in columnasOcultar)
            {
                if (dataGridView.Columns[columna] != null)
                {
                    dataGridView.Columns[columna].Visible = false; // Hacer invisible las columnas especificadas
                }
            }
        }
        // Evento de búsqueda que se activa cuando el usuario hace clic en el botón
        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string searchTerm = textBoxBuscar.Text.Trim(); // Obtiene el término de búsqueda escrito por el usuario

            if (string.IsNullOrEmpty(searchTerm)) // Si el término de búsqueda está vacío, muestra una alerta
            {
                Alerts.ShowAlertS("Por favor, ingrese un término de búsqueda.", AlertsType.Info);
                return;
            }

            var usuarios = usuarioController.BuscarUsuarios(searchTerm);  // Busca los usuarios que coinciden con el término en la base de datos
            dataGridView.DataSource = ConvertToDataTable(usuarios); // Convierte los resultados de la búsqueda en un DataTable y los muestra en el DataGridView


        }
        // Convierte una lista de usuarios a un DataTable para poder mostrarla en el DataGridView
        private DataTable ConvertToDataTable(IEnumerable<Usuario> usuarios)
        {
            var dataTable = new DataTable(); // Crea un nuevo DataTable
            dataTable.Columns.Add("IdUsuario", typeof(long)); // Añade las columnas del DataTable, con su tipo de dato correspondiente
            dataTable.Columns.Add("AliasUsuario", typeof(string));
            dataTable.Columns.Add("NombreUsuario", typeof(string));
            dataTable.Columns.Add("Contrasenia", typeof(string));
            dataTable.Columns.Add("IdRol", typeof(long));
            dataTable.Columns.Add("Estado", typeof(bool));

            // Recorre la lista de usuarios y añade cada uno como una fila en el DataTable
            foreach (var usuario in usuarios)
            {
                dataTable.Rows.Add(usuario.IdUsuario, usuario.AliasUsuario, usuario.NombreUsuario, usuario.Contrasenia, usuario.IdRol, usuario.Estado);
            }

            return dataTable; // Devuelve el DataTable con los datos de los usuarios
        }

        // Configura los ComboBoxes para seleccionar el tipo de usuario (Admin, Operador) y el estado (Activo, Inactivo)
        private void ConfigureComboBoxes()
        {
         
            // Configurar ComboBox de tipo de usuario
            var tipoUsuarios = new List<KeyValuePair<string, int>>
           {
            new KeyValuePair<string, int>("Admin", 1),
             new KeyValuePair<string, int>("Operador", 2)
           };
            cmbTipoUsuario.DataSource = tipoUsuarios;  // Establece la lista de tipos de usuarios como fuente de datos del ComboBox
            cmbTipoUsuario.DisplayMember = "Key";
            cmbTipoUsuario.ValueMember = "Value";

            // Configurar ComboBox de estado
            var estados = new List<KeyValuePair<string, bool>>
            {
             new KeyValuePair<string, bool>("Activo", true),
              new KeyValuePair<string, bool>("Inactivo", false)
           };
            cmbEstado.DataSource = estados; // Establece la lista de estados como fuente de datos del ComboBox
            cmbEstado.DisplayMember = "Key";
            cmbEstado.ValueMember = "Value";
        }

        // Evento que se ejecuta cuando se hace clic en el botón "Agregar" para crear un nuevo usuario.
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos de entrada en tabPage2
            txtAliasUsuario.Text = string.Empty;
            txtNombreUsuario.Text = string.Empty;
            txtContrasenia.Text = string.Empty;
            cmbTipoUsuario.SelectedIndex = -1; // Resetea la selección del ComboBox.
            cmbEstado.SelectedIndex = -1;

            // Mostrar tabPage2
            MostrarTabPage2();

        }
        // Evento que se ejecuta cuando se hace clic en el botón 
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {  // Llama a la función que valida los campos de entrada
                if (!ValidarCampos())
                {
                    return;
                }
                // Si el texto del botón es "Actualizar", se llama a la función para actualizar el usuario
                if (btnGuardar.Text == "Actualizar")
                {
                    ActualizarUsuario(); // Se actualiza el usuario en la base de datos
                }
                else
                {
                    CrearUsuario(); // Si el texto no es "Actualizar", se crea un nuevo usuario
                }

                MostrarTabPage1();
            }
            catch (Exception ex)
            { // En caso de cualquier error, se muestra un mensaje de alerta con el mensaje de error
                Alerts.ShowAlertS("Ocurrió un error: " + ex.Message, AlertsType.Error);
            }
        }
        // Función que valida que los campos obligatorios no estén vacíos
        private bool ValidarCampos()
        {  // Verifica si alguno de los campos obligatorios está vacío
            if (string.IsNullOrEmpty(txtAliasUsuario.Text) ||
                string.IsNullOrEmpty(txtNombreUsuario.Text) ||
                string.IsNullOrEmpty(txtContrasenia.Text))
            {
                Alerts.ShowAlertS("Por favor, complete todos los campos.", AlertsType.Info);
                return false;
            }
            // Verifica si no se ha seleccionado un tipo de usuario o un estado
            if (cmbTipoUsuario.SelectedValue == null || cmbEstado.SelectedValue == null)
            {
                Alerts.ShowAlertS("Por favor, seleccione un tipo de usuario y un estado.", AlertsType.Info);
                return false;
            }

            return true;
        }
        // Función que actualiza los datos del usuario seleccionado en la base de datos
        private void ActualizarUsuario()
        { // Crea un objeto Usuario con los datos actuales del formulario
            Usuario usuarioActualizado = new Usuario
            {
                IdUsuario = usuarioIdSeleccionado,
                AliasUsuario = txtAliasUsuario.Text,
                NombreUsuario = txtNombreUsuario.Text,
                Contrasenia = txtContrasenia.Text,
                IdRol = Convert.ToInt64(cmbTipoUsuario.SelectedValue),
                Estado = Convert.ToBoolean(cmbEstado.SelectedValue)
            };
            // Llama al controlador para realizar la actualización del usuario
            bool actualizado = usuarioController.ActualizarUsuario(usuarioActualizado);

            if (actualizado)
            { // Si la actualización fue exitosa, muestra un mensaje de confirmación
                Alerts.ShowAlertS("Usuario guardado exitosamente.", AlertsType.Confirm);
                LoadUsuarios(); // Recarga la lista de usuarios
                btnGuardar.Text = "Guardar";
            }
            else
            {
                Alerts.ShowAlertS("Error al actualizar el usuario.", AlertsType.Error);
            }
        }
        // Función que crea un nuevo usuario en la base de datos
        private void CrearUsuario()
        { // Crea un objeto Usuario con los datos del formulario
            Usuario nuevoUsuario = new Usuario
            {
                AliasUsuario = txtAliasUsuario.Text,
                NombreUsuario = txtNombreUsuario.Text,
                Contrasenia = txtContrasenia.Text,
                IdRol = Convert.ToInt64(cmbTipoUsuario.SelectedValue),
                Estado = Convert.ToBoolean(cmbEstado.SelectedValue)
            };
            // Llama al controlador para crear el nuevo usuario
            long usuarioId = usuarioController.CrearUsuario(nuevoUsuario);

            if (usuarioId > 0)
            {  // Si la creación fue exitosa, muestra un mensaje de confirmación
                Alerts.ShowAlertS("Usuario guardado exitosamente.", AlertsType.Confirm);
                LoadUsuarios();
                MostrarTabPage1();
            }
            else
            {
                Alerts.ShowAlertS("Error al guardar el usuario.", AlertsType.Error);
            }
        }

        // Función que carga la información de un usuario en los controles de la segunda pestaña para edición
        private void CargarInformacionUsuarioEnTabPage2(Usuario usuario)
        { // Rellena los campos con los datos del usuario
            txtAliasUsuario.Text = usuario.AliasUsuario;
            txtNombreUsuario.Text = usuario.NombreUsuario;
            txtContrasenia.Text = usuario.Contrasenia;
            cmbTipoUsuario.SelectedValue = usuario.IdRol;
            cmbEstado.SelectedValue = usuario.Estado;
        }
        // Evento que se ejecuta cuando se hace clic en el botón
        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado un usuario
                if (usuarioIdSeleccionado <= 0)
                {
                    Alerts.ShowAlertS("Por favor, seleccione un usuario para actualizar.", AlertsType.Info);
                    return;
                }

                // Obtener el usuario seleccionado desde el repositorio
                Usuario usuarioSeleccionado = usuarioController.ObtenerUsuarioPorId(usuarioIdSeleccionado);

                if (usuarioSeleccionado == null)
                {
                    Alerts.ShowAlertS("No se encontró el usuario seleccionado.", AlertsType.Info);
                    return;
                }

                // Cambiar a tabPage2
                MostrarTabPage2();

                // Cargar la información del usuario en los controles de tabPage2
                CargarInformacionUsuarioEnTabPage2(usuarioSeleccionado);

                // Habilitar los controles para permitir la edición
                txtAliasUsuario.Enabled = true;
                txtNombreUsuario.Enabled = true;
                txtContrasenia.Enabled = true;
                cmbTipoUsuario.Enabled = true;
                cmbEstado.Enabled = true;

                // Cambiar el texto del botón de guardar para indicar que es una actualización
                btnGuardar.Text = "Actualizar";
            }
            catch (Exception ex)
            {
               Alerts.ShowAlertS("Ocurrió un error: " + ex.Message, AlertsType.Error);
            }
        }

        // Evento que se ejecuta cuando se hace clic en una celda del DataGridView para seleccionar un usuario
        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Verifica que la fila clickeada sea válida
            {
                // Seleccionar la fila completa al hacer clic en cualquier celda
                dataGridView.Rows[e.RowIndex].Selected = true;

                // Obtener la fila seleccionada
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];

                // Usar índices de columna en lugar de nombres
                txtAliasUsuario.Text = row.Cells[1].Value.ToString();  // Columna de AliasUsuario
                txtNombreUsuario.Text = row.Cells[2].Value.ToString(); // Columna de NombreUsuario
                txtContrasenia.Text = row.Cells[3].Value.ToString();   // Columna de Contrasenia
                cmbTipoUsuario.SelectedValue = Convert.ToInt64(row.Cells[4].Value);  // Columna de IdRol
                cmbEstado.SelectedValue = Convert.ToBoolean(row.Cells[5].Value);      // Columna de Estado

                // Guardar el ID del usuario seleccionado en la variable de clase
                usuarioIdSeleccionado = Convert.ToInt64(row.Cells[0].Value); // Columna de IdUsuario
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos de entrada
            txtAliasUsuario.Text = string.Empty;
            txtNombreUsuario.Text = string.Empty;
            txtContrasenia.Text = string.Empty;
            cmbTipoUsuario.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;

            // Restablecer el texto del botón de guardar a "Guardar"
            btnGuardar.Text = "Guardar";

            MostrarTabPage1();
        }
        // Evento que se ejecuta cuando se hace clic en el botón
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado un usuario
                if (usuarioIdSeleccionado <= 0)
                {
                    MessageBox.Show("Por favor, seleccione un usuario para eliminar.");
                    return;
                }

                // Confirmar la eliminación
                var confirmResult = MessageBox.Show("¿Está seguro de que desea eliminar este usuario?",
                                                     "Confirmar Eliminación",
                                                     MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                {
                    // Llamar al método de eliminación lógica del controlador
                    bool eliminado = usuarioController.DesactivarUsuario(usuarioIdSeleccionado);

                    if (eliminado)
                    {
                        MessageBox.Show("Usuario eliminado exitosamente.");
                        LoadUsuarios(); // Recargar la lista de usuarios
                    }
                    else
                    {
                        MessageBox.Show("Error al eliminar el usuario.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }
        // Función que se ejecuta al seleccionar una pestaña en el TabControl
        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
          
            if (e.TabPage != tabControl1.SelectedTab)
            {
                e.Cancel = true;
            }
        }
        // Función que recarga los datos de usuarios cuando se hace clic en el botón 
        private void btnReiniciar_Click(object sender, EventArgs e)
        {
            try
            {
                // Recargar todos los datos de usuarios
                LoadUsuarios();
            }
            catch (Exception ex)
            {
                Alerts.ShowAlertS("Ocurrió un error al reiniciar los datos: " + ex.Message, AlertsType.Error);
            }
        }
        // Evento que se ejecuta cuando se cambia el texto de la contraseña
        private void txtContrasenia_TextChanged(object sender, EventArgs e)
        {
            txtContrasenia.UseSystemPasswordChar = true;
        }



    }
}
