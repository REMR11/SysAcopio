using SysAcopio.Controllers;
using SysAcopio.Repositories;
using SysAcopio.Utils;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace SysAcopio.Views
{
    public partial class Login : Form
    {   // Instancia del repositorio de usuarios para acceder a los datos de usuario
        private readonly UsuarioRepository usuarioRepository;
        // instancia de la base de datos para gestionar la conexión
        private readonly SysAcopioDbContext dbContext;
        public Login()
        {
            InitializeComponent();
            usuarioRepository = new UsuarioRepository();
            dbContext = new SysAcopioDbContext();
        }

        /// <summary>
        /// Evento que ocurre cuando el control de texto de usuario recibe el foco.
        /// Limpia el texto y cambia el color del texto a negro.
        /// </summary>
        private void txtUser_Enter(object sender, EventArgs e)
        { // Verifica si el texto es "Usuario", y lo borra
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }
        }
        /// <summary>
        /// Evento que ocurre cuando el control de texto de usuario pierde el foco.
        /// Si el control está vacío, establece el texto predeterminado y el color gris.
        /// </summary>
        private void txtUser_Leave(object sender, EventArgs e)
        { // Si el campo está vacío, muestra el texto "Usuario" con un color gris
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.DimGray;
            }
        }
        /// <summary>
        /// Evento que ocurre cuando el control de texto de contraseña recibe el foco.
        /// Limpia el texto y cambia el color del texto a negro. También habilita el modo de contraseña.
        /// </summary>
        private void txtPass_Enter(object sender, EventArgs e)
        {   // Verifica si el texto es "Contraseña", y lo borra
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.Black;
                txtPass.UseSystemPasswordChar = true;  // Activa el modo de contraseña
            }
        }
        /// <summary>
        /// Evento que ocurre cuando el control de texto de contraseña pierde el foco.
        /// Si el control está vacío, establece el texto predeterminado y desactiva el modo de contraseña.
        /// </summary>
        private void txtPass_Leave(object sender, EventArgs e)
        {  // Si el campo está vacío, muestra el texto "Contraseña" y desactiva el modo de contraseña
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;

            }
        }
        /// <summary>
        /// Evento que cierra la aplicación al hacer clic en el botón de cerrar.
        /// </summary>
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        /// <summary>
        /// Evento que maneja el inicio de sesión cuando se hace clic en el botón "Acceder".
        /// Realiza una consulta a la base de datos para verificar las credenciales del usuario.
        /// </summary>
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            try
            {
                var (usuarioEncontrado, contraseniaEncriptada, nombreUsuario, rolUsuario, idRol) = usuarioRepository.ObtenerDatosUsuario(txtUser.Text);

                if (usuarioEncontrado)
                {
                    // Verificar la contraseña ingresada contra el hash
                    if (BCrypt.Net.BCrypt.Verify(txtPass.Text, contraseniaEncriptada))
                    {
                        // Guardar datos del usuario en la sesión
                        Sesion.GuardarDatosUsuario(nombreUsuario, rolUsuario, idRol);

                        // Mostrar el formulario principal
                        Form1 form1 = new Form1();
                        this.Hide();
                        form1.Show();
                    }
                    else
                    {
                        Alerts.ShowAlertS("Contraseña o usuario incorrectos", AlertsType.Error);
                    }
                }
                else
                {
                    Alerts.ShowAlertS("Usuario no encontrado.", AlertsType.Error);
                }
            }
            catch (Exception ex)
            {
                Alerts.ShowAlertS("Error en la conexión: " + ex.Message, AlertsType.Error);
            }
        }

    }
}
