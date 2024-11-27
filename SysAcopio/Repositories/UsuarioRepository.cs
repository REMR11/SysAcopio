using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysAcopio.Models;
using System.Data.SqlClient;
using SysAcopio.Controllers;
using BCrypt.Net;
using System.Runtime.Remoting.Contexts;
using System.Data;
using System.Windows.Forms;


namespace SysAcopio.Repositories
{
    internal class UsuarioRepository
    {
        private readonly SysAcopioDbContext dbContext;
        private readonly RolRepository rolRepository; // Instancia de RolRepository

        public UsuarioRepository()
        {
            dbContext = new SysAcopioDbContext();
            rolRepository = new RolRepository(); // Inicializar RolRepository
        }

        /// <summary>
        /// Método para crear un nuevo usuario 
        /// </summary>
        public long Create(Usuario usuario)
        {
            try
            {
                using (SqlConnection conn = dbContext.ConnectionServer())
                {
                    string query = @"INSERT INTO Usuario (alias_usuario, nombre_usuario, contrasenia, id_rol, estado) 
                             VALUES (@AliasUsuario, @NombreUsuario, @Contrasenia, @IdRol, @Estado);
                             SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@AliasUsuario", usuario.AliasUsuario);
                        cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        cmd.Parameters.AddWithValue("@Contrasenia", BCrypt.Net.BCrypt.HashPassword(usuario.Contrasenia));
                        cmd.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                        cmd.Parameters.AddWithValue("@Estado", usuario.Estado);

                        // Verifica el estado de la conexión antes de abrirla
                        if (conn.State == ConnectionState.Closed)
                        {
                            conn.Open();
                        }

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt64(result);
                        }
                        return -1;
                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception("Error al guardar el usuario: " + ex.Message, ex);
            }
        }

        /// <summary>
        /// Método para obtener todos los usuarios activos, incluyendo su rol.
        /// </summary>
        public IEnumerable<Usuario> GetAll()
        {
            var usuarios = new List<Usuario>();
            using (SqlConnection conn = dbContext.ConnectionServer())
            {
                string query = "SELECT id_Usuario, alias_usuario, nombre_usuario, contrasenia, id_rol, estado FROM Usuario WHERE estado = 1";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var usuario = new Usuario
                            {
                                IdUsuario = reader.GetInt64(0),
                                AliasUsuario = reader.GetString(1),
                                NombreUsuario = reader.GetString(2),
                                Contrasenia = reader.GetString(3),
                                IdRol = reader.GetInt64(4),
                                Estado = reader.GetBoolean(5)
                            };

                            // Obtener detalles del rol asociado
                            usuario.Rol = rolRepository.GetById(usuario.IdRol);
                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            return usuarios;
        }

        /// <summary>
        /// Método para obtener un usuario por su ID, incluyendo su rol.
        /// </summary>
        public Usuario GetById(long id)
        {
            using (SqlConnection conn = dbContext.ConnectionServer())
            {
                string query = "SELECT id_Usuario, alias_usuario, nombre_usuario, contrasenia, id_rol, estado FROM Usuario WHERE id_Usuario = @IdUsuario";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdUsuario", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            var usuario = new Usuario
                            {
                                IdUsuario = reader.GetInt64(0),
                                AliasUsuario = reader.GetString(1),
                                NombreUsuario = reader.GetString(2),
                                Contrasenia = reader.GetString(3),
                                IdRol = reader.GetInt64(4),
                                Estado = reader.GetBoolean(5)
                            };

                            // Obtener detalles del rol asociado
                            usuario.Rol = rolRepository.GetById(usuario.IdRol);
                            return usuario;
                        }
                    }
                }
            }
            return null;
        }


        //Método para actualizar la contraseña
        public void UpdatePassword(long id, string password)
        {
            try
            {
                using (SqlConnection conn = dbContext.ConnectionServer())
                {
                    string query = @"UPDATE Usuario SET 
                                        contrasenia = @Contrasenia
                                     WHERE id_Usuario = @IdUsuario";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", id);
                        cmd.Parameters.AddWithValue("@Contrasenia", BCrypt.Net.BCrypt.HashPassword(password)); // Encriptación de contraseña

                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Método para actualizar un usuario.
        /// </summary>
        public bool Update(Usuario usuario)
        {
            try
            {
                using (SqlConnection conn = dbContext.ConnectionServer())
                {
                    if (!string.IsNullOrEmpty(usuario.Contrasenia))
                    {
                        //MessageBox.Show($"Va a actualizarla {usuario.IdUsuario} {usuario.Contrasenia}");
                        //Actualizamos la contraseña
                        UpdatePassword(usuario.IdUsuario, usuario.Contrasenia);
                    }

                    string query = @"UPDATE Usuario SET 
                                        alias_usuario = @AliasUsuario, 
                                        nombre_usuario = @NombreUsuario, 
                                        id_rol = @IdRol, 
                                        estado = @Estado 
                                     WHERE id_Usuario = @IdUsuario";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                        cmd.Parameters.AddWithValue("@AliasUsuario", usuario.AliasUsuario);
                        cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        cmd.Parameters.AddWithValue("@IdRol", usuario.IdRol);
                        cmd.Parameters.AddWithValue("@Estado", usuario.Estado);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Método para desactivar un usuario de manera lógica.
        /// </summary>
        public bool DeleteLogic(long id)
        {
            try
            {
                Usuario usuario = GetById(id); // Obtiene el usuario por su ID
                if (usuario == null) return false;

                usuario.Estado = false;  // Desactiva el usuario
                return Update(usuario);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Método para buscar usuarios basados en un término de búsqueda.
        /// </summary>

        public IEnumerable<Usuario> Search(string searchTerm)
        {
            var usuarios = new List<Usuario>(); // Definir la lista de usuarios

            using (SqlConnection conn = dbContext.ConnectionServer())
            {
                string query = "SELECT id_Usuario, alias_usuario, nombre_usuario, contrasenia, id_rol, estado FROM Usuario " +
                               "WHERE alias_usuario LIKE @SearchTerm " +
                               "OR nombre_usuario LIKE @SearchTerm " +
                               "OR id_Usuario LIKE @SearchTerm " +
                               "OR estado LIKE @SearchTerm " +
                               "OR id_rol LIKE @SearchTerm";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@SearchTerm", "%" + searchTerm + "%");
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var usuario = new Usuario
                            {
                                IdUsuario = reader.GetInt64(0),
                                AliasUsuario = reader.GetString(1),
                                NombreUsuario = reader.GetString(2),
                                Contrasenia = reader.GetString(3),
                                IdRol = reader.GetInt64(4),
                                Estado = reader.GetBoolean(5)
                            };

                            // Obtener detalles del rol asociado
                            usuario.Rol = rolRepository.GetById(usuario.IdRol);
                            usuarios.Add(usuario);
                        }
                    }
                }
            }
            return usuarios;
        }

        /// <summary>
        /// Método para obtener los usuarios en un DataTable.
        /// </summary>

        public DataTable ObtenerUsuariosDataTable()
        {
            string query = "SELECT u.id_Usuario, u.alias_usuario, u.nombre_usuario, u.contrasenia, u.id_rol, u.estado, r.nombre_rol FROM Usuario AS u JOIN Rol as r ON r.id_rol = u.id_rol";

            using (SqlConnection connection = dbContext.ConnectionServer())
            {
                try
                {
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();
                    dataAdapter.Fill(dataTable);
                    return dataTable;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al cargar los datos de usuarios: " + ex.Message);
                }
            }
        }
        /// <summary>
        /// Método para obtener los datos de un usuario por su alias.
        /// </summary>
        /// <param name="aliasUsuario">El alias del usuario.</param>
        /// <returns>Una tupla que indica si el usuario fue encontrado y sus datos (contraseña encriptada, nombre de usuario, rol de usuario, ID de rol).</returns>
        public (bool, string, string, string, long) ObtenerDatosUsuario(string aliasUsuario)
        {
            using (SqlConnection connection = dbContext.ConnectionServer())
            {
                // Consulta SQL para obtener los datos del usuario y su rol
                string consulta = @"SELECT u.id_usuario, u.id_rol, u.nombre_usuario, r.nombre_rol, u.contrasenia
                            FROM Usuario as u 
                            JOIN Rol as r ON u.id_rol = r.id_rol
                            WHERE u.alias_usuario = @alias_usuario AND u.estado = 1;";
                SqlCommand cmd = new SqlCommand(consulta, connection);
                cmd.Parameters.AddWithValue("@alias_usuario", aliasUsuario);

                // Ejecutar la consulta y leer los resultados
                using (SqlDataReader lector = cmd.ExecuteReader())
                {
                    if (lector.HasRows)
                    {
                        lector.Read();
                        // Obtener los datos del usuario
                        string contraseniaEncriptada = lector["contrasenia"].ToString();
                        string nombreUsuario = lector["nombre_usuario"].ToString();
                        string rolUsuario = lector["nombre_rol"].ToString();
                        long idRol = Convert.ToInt64(lector["id_rol"]);

                        // Devolver los datos del usuario 
                        return (true, contraseniaEncriptada, nombreUsuario, rolUsuario, idRol);
                    }
                }
            }
            // Devolver valores por defecto si el usuario no fue encontrado
            return (false, null, null, null, 0);
        }

    }



}
