using SysAcopio.Controllers;
using SysAcopio.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SysAcopio.Repositories
{
    internal class RolRepository
    {
        private readonly SysAcopioDbContext dbContext;

        public RolRepository()
        {
            dbContext = new SysAcopioDbContext();
        }

        /// <summary>
        /// Método para crear un nuevo rol.
        /// </summary>
        /// <param name="rol"></param>
        public long Create(Rol rol)
        {
            try
            {
                using (SqlConnection conn = dbContext.ConnectionServer())
                {
                    string query = @"INSERT INTO Rol (nombre_rol) VALUES (@NombreRol);
                                     SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@NombreRol", rol.NombreRol);

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
        /// Método para obtener todos los roles.
        /// </summary>
        public IEnumerable<Rol> GetAll()
        {
            var roles = new List<Rol>();
            using (SqlConnection conn = dbContext.ConnectionServer())
            {
                string query = "SELECT * FROM Rol";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            roles.Add(new Rol
                            {
                                IdRol = reader.GetInt64(0),
                                NombreRol = reader.GetString(1)
                            });
                        }
                    }
                }
            }
            return roles;
        }

        /// <summary>
        /// Método para obtener un rol por su ID.
        /// </summary>
        public Rol GetById(long id)
        {
            using (SqlConnection conn = dbContext.ConnectionServer())
            {
                string query = "SELECT * FROM Rol WHERE id_rol = @IdRol";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdRol", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Rol
                            {
                                IdRol = reader.GetInt64(0),
                                NombreRol = reader.GetString(1)
                            };
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Método para actualizar un rol.
        /// </summary>
        public bool Update(Rol rol)
        {
            try
            {
                using (SqlConnection conn = dbContext.ConnectionServer())
                {
                    string query = @"UPDATE Rol SET nombre_rol = @NombreRol WHERE id_rol = @IdRol";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdRol", rol.IdRol);
                        cmd.Parameters.AddWithValue("@NombreRol", rol.NombreRol);

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
        /// Método para eliminar un rol.
        /// </summary>
        public bool Delete(long id)
        {
            try
            {
                using (SqlConnection conn = dbContext.ConnectionServer())
                {
                    string query = "DELETE FROM Rol WHERE id_rol = @IdRol";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdRol", id);
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
