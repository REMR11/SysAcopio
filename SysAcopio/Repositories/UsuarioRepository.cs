﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SysAcopio.Models;
using System.Data.SqlClient;
using SysAcopio.Controllers;
using BCrypt.Net;
using System.Runtime.Remoting.Contexts;


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

                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt64(result);
                        }
                        return -1;
                    }
                }
            }
            catch (Exception)
            {
                return -1;
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
                string query = "SELECT * FROM Usuario WHERE estado = 1";
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
                string query = "SELECT * FROM Usuario WHERE id_Usuario = @IdUsuario";
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

        /// <summary>
        /// Método para actualizar un usuario.
        /// </summary>
        public bool Update(Usuario usuario)
        {
            try
            {
                using (SqlConnection conn = dbContext.ConnectionServer())
                {
                    string query = @"UPDATE Usuario SET 
                                        alias_usuario = @AliasUsuario, 
                                        nombre_usuario = @NombreUsuario, 
                                        contrasenia = @Contrasenia, 
                                        id_rol = @IdRol, 
                                        estado = @Estado 
                                     WHERE id_Usuario = @IdUsuario";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", usuario.IdUsuario);
                        cmd.Parameters.AddWithValue("@AliasUsuario", usuario.AliasUsuario);
                        cmd.Parameters.AddWithValue("@NombreUsuario", usuario.NombreUsuario);
                        cmd.Parameters.AddWithValue("@Contrasenia", BCrypt.Net.BCrypt.HashPassword(usuario.Contrasenia)); // Encriptación de contraseña
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
                Usuario usuario = GetById(id);
                if (usuario == null) return false;

                usuario.Estado = false;
                return Update(usuario);
            }
            catch (Exception)
            {
                return false;
            }
        }

        /// <summary>
        /// Método para eliminar un usuario de la base de datos.
        /// </summary>
        public bool Delete(long id)
        {
            try
            {
                using (SqlConnection conn = dbContext.ConnectionServer())
                {
                    string query = "DELETE FROM Usuario WHERE id_Usuario = @IdUsuario";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdUsuario", id);
                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

      

    }

    
    
}