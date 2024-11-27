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
using SysAcopio.Controllers;
using SysAcopio.Models;
using SysAcopio.Repositories;
using SysAcopio.Utils;

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
            using (SqlConnection connection = dbContext.ConnectionServer())
            {
                try
                {
                    // Consulta SQL con parámetros para evitar inyección SQL
                    string consulta = @"SELECT u.id_usuario, u.id_rol, u.nombre_usuario, r.nombre_rol, u.contrasenia
                            FROM Usuario as u 
                            JOIN Rol as r ON u.id_rol = r.id_rol
                            WHERE u.alias_usuario = @alias_usuario AND u.estado = 1;";
                    SqlCommand cmd = new SqlCommand(consulta, connection);
                    cmd.Parameters.AddWithValue("@alias_usuario", txtUser.Text);

                    SqlDataReader lector = cmd.ExecuteReader();

                    if (lector.HasRows)
                    {
                        lector.Read();

                        // Obtener el hash almacenado y otros datos del usuario
                        string contraseniaEncriptada = lector["contrasenia"].ToString();
                        string nombreUsuario = lector["nombre_usuario"].ToString();
                        string rolUsuario = lector["nombre_rol"].ToString();

                        // Verificar la contraseña ingresada contra el hash
                        if (BCrypt.Net.BCrypt.Verify(txtPass.Text, contraseniaEncriptada))
                        {
                            // Guardar datos del usuario en la sesión
                            long idRol = Convert.ToInt64(lector["id_rol"]);
                            // Guardar los datos del usuario en la clase estática Sesion
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
                    MessageBox.Show("Error en la conexión: " + ex.Message);
                }
            }
        }


    }
}
