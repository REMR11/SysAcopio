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
                    string query = @"INSERT INTO Solicitud (Ubicacion, Fecha, Estado, IsCancel, NombreSolicitante, Urgencia, Motivo) 
                             VALUES (@Ubicacion, @Fecha, @Estado, @IsCancel, @NombreSolicitante, @Urgencia, @Motivo);
                             SELECT SCOPE_IDENTITY();";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Ubicacion", solicitud.Ubicacion);
                        cmd.Parameters.AddWithValue("@Fecha", solicitud.Fecha);
                        cmd.Parameters.AddWithValue("@Estado", solicitud.Estado);
                        cmd.Parameters.AddWithValue("@IsCancel", solicitud.IsCancel);
                        cmd.Parameters.AddWithValue("@NombreSolicitante", solicitud.NombreSolicitante);
                        cmd.Parameters.AddWithValue("@Urgencia", solicitud.Urgencia);
                        cmd.Parameters.AddWithValue("@Motivo", solicitud.Motivo);

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
                                Estado = reader.GetBoolean(3),
                                IsCancel = reader.GetBoolean(4),
                                NombreSolicitante = reader.GetString(5),
                                Urgencia = reader.GetByte(6),
                                Motivo = reader.GetString(7)
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
                string query = "SELECT * FROM Solicitud WHERE IdSolicitud = @IdSolicitud";
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
                                Estado = reader.GetBoolean(3),
                                IsCancel = reader.GetBoolean(4),
                                NombreSolicitante = reader.GetString(5),
                                Urgencia = reader.GetByte(6),
                                Motivo = reader.GetString(7)
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
                    string query = "UPDATE Solicitud SET Ubicacion = @Ubicacion, Fecha = @Fecha, Estado = @Estado, " +
                                   "IsCancel = @IsCancel, NombreSolicitante = @NombreSolicitante, Urgencia = @Urgencia, " +
                                   "Motivo = @Motivo WHERE IdSolicitud = @IdSolicitud";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdSolicitud", solicitud.IdSolicitud);
                        cmd.Parameters.AddWithValue("@Ubicacion", solicitud.Ubicacion);
                        cmd.Parameters.AddWithValue("@Fecha", solicitud.Fecha);
                        cmd.Parameters.AddWithValue("@Estado", solicitud.Estado);
                        cmd.Parameters.AddWithValue("@IsCancel", solicitud.IsCancel);
                        cmd.Parameters.AddWithValue("@NombreSolicitante", solicitud.NombreSolicitante);
                        cmd.Parameters.AddWithValue("@Urgencia", solicitud.Urgencia);
                        cmd.Parameters.AddWithValue("@Motivo", solicitud.Motivo);

                        return cmd.ExecuteNonQuery() > 0;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

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
                    string query = "DELETE FROM Solicitud WHERE IdSolicitud = @IdSolicitud";
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
