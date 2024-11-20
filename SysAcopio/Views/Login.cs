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

namespace SysAcopio.Views
{
    public partial class Login : Form
    {
        private readonly UsuarioRepository usuarioRepository;
        private readonly SysAcopioDbContext dbContext;
        public Login()
        {
            InitializeComponent();
            usuarioRepository = new UsuarioRepository();
            dbContext = new SysAcopioDbContext();
        }

        private void txtUser_Enter(object sender, EventArgs e)
        {
            if (txtUser.Text == "Usuario")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.Black;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (txtUser.Text == "")
            {
                txtUser.Text = "Usuario";
                txtUser.ForeColor = Color.DimGray;
            }
        }

        private void txtPass_Enter(object sender, EventArgs e)
        {
            if (txtPass.Text == "Contraseña")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.Black;
                txtPass.UseSystemPasswordChar = true;
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (txtPass.Text == "")
            {
                txtPass.Text = "Contraseña";
                txtPass.ForeColor = Color.DimGray;
                txtPass.UseSystemPasswordChar = false;

            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void btnAcceder_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = dbContext.ConnectionServer())
            {
                try
                {
                    // Consulta para obtener  la contraseña basado en el alias del usuario
                    string consulta = "SELECT contrasenia, nombre_usuario, id_rol FROM Usuario WHERE alias_usuario = @alias_usuario";
                    SqlCommand cmd = new SqlCommand(consulta, connection);
                    cmd.Parameters.AddWithValue("@alias_usuario", txtUser.Text);

                    SqlDataReader lector = cmd.ExecuteReader();

                    if (lector.HasRows)
                    {
                        lector.Read();

                        // Obtener el hash almacenado y otros datos del usuario
                        string contraseniaEncriptada = lector["contrasenia"].ToString();
                        string nombreUsuario = lector["nombre_usuario"].ToString();
                        string rolUsuario = lector["id_rol"].ToString();

                        // Verificar la contraseña ingresada contra el hash
                        if (BCrypt.Net.BCrypt.Verify(txtPass.Text, contraseniaEncriptada))
                        {
                            // Guardar datos del usuario en la sesión
                            Sesion.GuardarDatosUsuario(nombreUsuario, rolUsuario);

                            // Mostrar el formulario principal
                            Form1 form1 = new Form1();
                            this.Hide();
                            form1.Show();
                        }
                        else
                        {
                            MessageBox.Show("Usuario o contraseña incorrectos.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Usuario no encontrado.");
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
