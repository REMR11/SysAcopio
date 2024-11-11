using SysAcopio.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SysAcopio.Controllers
{
    public class SolicitudRepository
    {
        private readonly SysAcopioDbContext dbContext;

        public SolicitudRepository()
        {
            dbContext = new SysAcopioDbContext();
        }


        /// <summary>
        /// Metodo para crear nueva Solicitud
        /// </summary>
        /// <param name="solicitud"></param>
        public long Create(Solicitud solicitud)
        {
            try
            {
                using (SqlConnection conn = dbContext.ConnectionServer())
                {
                    string query = @"INSERT INTO SOLICITUD(ubicacion, fecha, estado, nombre_solicitante, urgencia, motivo, is_cancel) 
                            VALUES (@Ubicacion, @Fecha, @Estado, @NombreSolicitante, @Urgencia, @Motivo, @IsCancel);
                            SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ubicacion", solicitud.Ubicacion);
                        cmd.Parameters.AddWithValue("@Fecha", solicitud.Fecha);
                        cmd.Parameters.AddWithValue("@Estado", solicitud.Estado);
                        cmd.Parameters.AddWithValue("@NombreSolicitante", solicitud.NombreSolicitante);
                        cmd.Parameters.AddWithValue("@Urgencia", solicitud.Urgencia);
                        cmd.Parameters.AddWithValue("@Motivo", solicitud.Motivo);
                        cmd.Parameters.AddWithValue("@IsCancel", solicitud.IsCancel);

                        // ExecuteScalar devuelve el ID generado
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            return Convert.ToInt64(result);
                        }
                        return -1; // Indica que no se pudo crear la solicitud
                    }
                }
            }
            catch (Exception)
            {
                return -1; // Indica que ocurrió un error
            }
        }

        /// <summary>
        /// Metodo para obtener todos los registros de la entidad
        /// </summary>
        /// <returns>Listado de registros de la entidad Solicitudes</returns>
        public IEnumerable<Solicitud> GetAll()
        {
            var solicitudes = new List<Solicitud>();
            using (SqlConnection conn = dbContext.ConnectionServer())
            {
                string query = "SELECT * FROM Solicitud";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            solicitudes.Add(new Solicitud
                            {
                                IdSolicitud = reader.GetInt64(0),
                                Ubicacion = reader.GetString(1),
                                Fecha = reader.GetDateTime(2),
                                Estado = reader.IsDBNull(3) ? false : reader.GetBoolean(3), // Manejo de nulos
                                NombreSolicitante = reader.GetString(4),
                                Urgencia = reader.GetByte(5),
                                Motivo = reader.GetString(6),
                                IsCancel = reader.IsDBNull(7) ? false : reader.GetBoolean(7), // Manejo de nulos
                            });
                        }
                    }
                }
            }
            return solicitudes;
        }

        /// <summary>
        /// Metodo para obtener una solicitud por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Solicitud que coincida con el ID proporcionado</returns>
        public Solicitud GetById(long id)
        {
            using (SqlConnection conn = dbContext.ConnectionServer())
            {
                string query = "SELECT * FROM Solicitud WHERE id_solicitud = @IdSolicitud";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@IdSolicitud", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Solicitud
                            {
                                IdSolicitud = reader.GetInt64(0),
                                Ubicacion = reader.GetString(1),
                                Fecha = reader.GetDateTime(2),
                                Estado = reader.IsDBNull(3) ? false : reader.GetBoolean(3), // Manejo de nulos
                                NombreSolicitante = reader.GetString(4),
                                Urgencia = reader.GetByte(5),
                                Motivo = reader.GetString(6),
                                IsCancel = reader.IsDBNull(7) ? false : reader.GetBoolean(7), // Manejo de nulos
                            };
                        }
                    }
                }
            }
            return null;
        }

        /// <summary>
        /// Metodo para actualizar un registro en la base de datos
        /// </summary>
        /// <param name="solicitud"></param>
        public bool Update(Solicitud solicitud)
        {
            try
            {
                using (SqlConnection conn = dbContext.ConnectionServer())
                {
                    string query = @"UPDATE Solicitud SET 
                                        Ubicacion = @Ubicacion, 
                                        Fecha = @Fecha, 
                                        Estado = @Estado,
                                        nombre_solicitante = @NombreSolicitante, 
                                        Urgencia = @Urgencia, 
                                        Motivo = @Motivo 
                                        is_cancel = @IsCancel, 
                                    WHERE 
                                        IdSolicitud = @IdSolicitud";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdSolicitud", solicitud.IdSolicitud);
                        cmd.Parameters.AddWithValue("@Ubicacion", solicitud.Ubicacion);
                        cmd.Parameters.AddWithValue("@Fecha", solicitud.Fecha);
                        cmd.Parameters.AddWithValue("@Estado", solicitud.Estado);
                        cmd.Parameters.AddWithValue("@NombreSolicitante", solicitud.NombreSolicitante);
                        cmd.Parameters.AddWithValue("@Urgencia", solicitud.Urgencia);
                        cmd.Parameters.AddWithValue("@Motivo", solicitud.Motivo);
                        cmd.Parameters.AddWithValue("@IsCancel", solicitud.IsCancel);

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
        /// Metodo para eliminar logicamente un registro
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Booleano que verifica el exito del metodo</returns>
        public bool DeleteLogic(long id)
        {
            try
            {
                Solicitud solicitud = GetById(id);
                if (solicitud == null) return false;

                solicitud.Estado = false;
                return Update(solicitud);
            }
            catch (Exception)
            {
                return false;
            }
        }


        /// <summary>
        /// Metodo para eliminar definitivamente un usuario mediante un ID
        /// </summary>
        /// <param name="id"></param>
        public bool Delete(long id)
        {
            try
            {
                using (SqlConnection conn = dbContext.ConnectionServer())
                {
                    string query = "DELETE FROM Solicitud WHERE id_solicitud = @IdSolicitud";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdSolicitud", id);
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
