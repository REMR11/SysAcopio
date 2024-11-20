using SysAcopio.Controllers;
using SysAcopio.Models;
using SysAcopio.Repositories;
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
    public partial class UsuarioView : Form
    {
        private UsuarioRepository usuarioRepository;
        private UsuarioController usuarioController;
        private long usuarioIdSeleccionado; 
        public UsuarioView()
        {
            InitializeComponent();
            usuarioController = new UsuarioController();
            usuarioRepository = new UsuarioRepository();
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            ConfigureComboBoxes();

        }

        private void UsuarioView_Load(object sender, EventArgs e)
        {
            LoadUsuarios();
            MostrarTabPage1();
        }
        private void LoadUsuarios()
        {
            try
            {
                // Obtener los datos de usuarios desde el controlador
                DataTable dataTable = usuarioController.ObtenerUsuariosDataTable();

                // Asigna el DataTable al DataGridView
                dataGridView.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar los datos de usuarios: " + ex.Message);
            }
        }
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

        private void btnBuscar_Click(object sender, EventArgs e)
        {

            string searchTerm = textBoxBuscar.Text.Trim();

            if (string.IsNullOrEmpty(searchTerm))
            {
                MessageBox.Show("Por favor, ingrese un término de búsqueda.");
                return;
            }

            var usuarios = usuarioController.BuscarUsuarios(searchTerm);
            dataGridView.DataSource = ConvertToDataTable(usuarios);


        }
        private DataTable ConvertToDataTable(IEnumerable<Usuario> usuarios)
        {
            var dataTable = new DataTable();
            dataTable.Columns.Add("IdUsuario", typeof(long));
            dataTable.Columns.Add("AliasUsuario", typeof(string));
            dataTable.Columns.Add("NombreUsuario", typeof(string));
            dataTable.Columns.Add("Contrasenia", typeof(string));
            dataTable.Columns.Add("IdRol", typeof(long));
            dataTable.Columns.Add("Estado", typeof(bool));

            foreach (var usuario in usuarios)
            {
                dataTable.Rows.Add(usuario.IdUsuario, usuario.AliasUsuario, usuario.NombreUsuario, usuario.Contrasenia, usuario.IdRol, usuario.Estado);
            }

            return dataTable;
        }


        private void ConfigureComboBoxes()
        {
            // Configurar ComboBox de tipo de usuario
            var tipoUsuarios = new List<KeyValuePair<string, int>>
           {
        new KeyValuePair<string, int>("Admin", 1),
        new KeyValuePair<string, int>("Operador", 2)
           };
            cmbTipoUsuario.DataSource = tipoUsuarios;
            cmbTipoUsuario.DisplayMember = "Key";
            cmbTipoUsuario.ValueMember = "Value";

            // Configurar ComboBox de estado
            var estados = new List<KeyValuePair<string, bool>>
            {
        new KeyValuePair<string, bool>("Activo", true),
        new KeyValuePair<string, bool>("Inactivo", false)
           };
            cmbEstado.DataSource = estados;
            cmbEstado.DisplayMember = "Key";
            cmbEstado.ValueMember = "Value";
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // Limpiar los campos de entrada en tabPage2
            txtAliasUsuario.Text = string.Empty;
            txtNombreUsuario.Text = string.Empty;
            txtContrasenia.Text = string.Empty;
            cmbTipoUsuario.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;

            // Mostrar tabPage2
            MostrarTabPage2();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que los campos no estén vacíos
                if (string.IsNullOrEmpty(txtAliasUsuario.Text) ||
                    string.IsNullOrEmpty(txtNombreUsuario.Text) ||
                    string.IsNullOrEmpty(txtContrasenia.Text))
                {
                    MessageBox.Show("Por favor, complete todos los campos.");
                    return;
                }

                // Validar que los valores de los ComboBox sean válidos
                if (cmbTipoUsuario.SelectedValue == null || cmbEstado.SelectedValue == null)
                {
                    MessageBox.Show("Por favor, seleccione un tipo de usuario y un estado.");
                    return;
                }

                if (btnGuardar.Text == "Actualizar")
                {
                    // Actualizar el usuario existente
                    Usuario usuarioActualizado = new Usuario
                    {
                        IdUsuario = usuarioIdSeleccionado, // Usar la variable de clase
                        AliasUsuario = txtAliasUsuario.Text,
                        NombreUsuario = txtNombreUsuario.Text,
                        Contrasenia = txtContrasenia.Text,
                        IdRol = Convert.ToInt64(cmbTipoUsuario.SelectedValue),
                        Estado = Convert.ToBoolean(cmbEstado.SelectedValue)
                    };

                    // Llamar al método ActualizarUsuario del controlador
                    bool actualizado = usuarioController.ActualizarUsuario(usuarioActualizado);

                    if (actualizado)
                    {
                        MessageBox.Show("Usuario actualizado exitosamente.");
                        LoadUsuarios(); // Recargar la lista de usuarios
                        btnGuardar.Text = "Guardar"; // Resetear el texto del botón
                    }
                    else
                    {
                        MessageBox.Show("Error al actualizar el usuario.");
                    }
                }
                else
                {
                    // Crear un nuevo usuario
                    Usuario nuevoUsuario = new Usuario
                    {
                        AliasUsuario = txtAliasUsuario.Text,
                        NombreUsuario = txtNombreUsuario.Text,
                        Contrasenia = txtContrasenia.Text,
                        IdRol = Convert.ToInt64(cmbTipoUsuario.SelectedValue),
                        Estado = Convert.ToBoolean(cmbEstado.SelectedValue)
                    };

                    // Llamar al método CrearUsuario del controlador
                    long usuarioId = usuarioController.CrearUsuario(nuevoUsuario);

                    if (usuarioId > 0)
                    {
                        MessageBox.Show("Usuario guardado exitosamente.");
                        LoadUsuarios(); // Recargar la lista de usuarios
                    }
                    else
                    {
                        MessageBox.Show("Error al guardar el usuario.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }





        private void CargarInformacionUsuarioEnTabPage2(Usuario usuario)
        {
            txtAliasUsuario.Text = usuario.AliasUsuario;
            txtNombreUsuario.Text = usuario.NombreUsuario;
            txtContrasenia.Text = usuario.Contrasenia;
            cmbTipoUsuario.SelectedValue = usuario.IdRol;
            cmbEstado.SelectedValue = usuario.Estado;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            try
            {
                // Validar que se haya seleccionado un usuario
                if (usuarioIdSeleccionado <= 0)
                {
                    MessageBox.Show("Por favor, seleccione un usuario para actualizar.");
                    return;
                }

                // Obtener el usuario seleccionado desde el repositorio
                Usuario usuarioSeleccionado = usuarioController.ObtenerUsuarioPorId(usuarioIdSeleccionado);

                if (usuarioSeleccionado == null)
                {
                    MessageBox.Show("No se encontró el usuario seleccionado.");
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
                MessageBox.Show("Ocurrió un error: " + ex.Message);
            }
        }


        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                // Seleccionar la fila completa
                dataGridView.Rows[e.RowIndex].Selected = true;

                DataGridViewRow row = dataGridView.Rows[e.RowIndex];

                txtAliasUsuario.Text = row.Cells["alias_usuario"].Value.ToString();
                txtNombreUsuario.Text = row.Cells["nombre_usuario"].Value.ToString();
                txtContrasenia.Text = row.Cells["contrasenia"].Value.ToString();
                cmbTipoUsuario.SelectedValue = Convert.ToInt64(row.Cells["id_rol"].Value);
                cmbEstado.SelectedValue = Convert.ToBoolean(row.Cells["estado"].Value);

                // Guardar el ID del usuario seleccionado en la variable de clase
                usuarioIdSeleccionado = Convert.ToInt64(row.Cells["id_usuario"].Value);
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

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
          
            if (e.TabPage != tabControl1.SelectedTab)
            {
                e.Cancel = true;
            }
        }
    }
}
