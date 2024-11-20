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
            // Usamos el método ConnectionServer de SysAcopioDbContext para obtener la conexión
            using (SqlConnection connection = dbContext.ConnectionServer())
            {
                try
                {
                    // Consulta SQL con parámetros para evitar inyección SQL
                    string consulta = @"SELECT u.id_usuario, u.id_rol, u.nombre_usuario, r.nombre_rol
                            FROM Usuario as u 
                            JOIN Rol as r ON u.id_rol = r.id_rol
                            WHERE u.alias_usuario = @alias_usuario AND u.contrasenia = @contrasenia AND u.estado = 1;";
                    SqlCommand cmd = new SqlCommand(consulta, connection);
                    cmd.Parameters.AddWithValue("@alias_usuario", txtUser.Text);
                    cmd.Parameters.AddWithValue("@contrasenia", txtPass.Text);

                    SqlDataReader lector = cmd.ExecuteReader();

                    if (lector.HasRows)
                    { // Si el usuario es válido, leer los datos
                        lector.Read();
                        string nombreUsuario = lector["nombre_usuario"].ToString();
                        string rolUsuario = lector["nombre_rol"].ToString();  // Suponiendo que 'id_rol' es el rol como string
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
                catch (Exception ex)
                {
                    MessageBox.Show("Error en la conexión: " + ex.Message);
                }
            }
        }
        private void msgError(string msg)
        {
            lblError.Text = " " + msg;
            lblError.Visible = true;

        }
    }
}
