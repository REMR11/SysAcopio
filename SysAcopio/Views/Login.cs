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
    public partial class Login: Form
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
            if (txtPass.Text == ""){
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
                    string consulta = "SELECT * FROM Usuario WHERE alias_usuario = @alias_usuario AND contrasenia = @contrasenia";
                    SqlCommand cmd = new SqlCommand(consulta, connection);
                    cmd.Parameters.AddWithValue("@alias_usuario", txtUser.Text);
                    cmd.Parameters.AddWithValue("@contrasenia", txtPass.Text);

                    SqlDataReader lector = cmd.ExecuteReader();

                    if (lector.HasRows)
                    {
                        Form1 form1 = new Form1();
                        this.Hide();
                        form1.Show();
                    }
                    else
                    {
                        MessageBox.Show("Usuario o contraseña incorrectos");
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
