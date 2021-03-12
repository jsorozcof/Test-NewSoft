
using ConfeccionesCondor.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfeccionesCondor.Core_StoredProcs
{
    public class EmpleadoRepository
    {
        private readonly string _connectionString;

        public EmpleadoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DevConnection");
        }

        public async Task<List<EmpleadoModel>> GetAll()
        {
            using (SqlConnection sql = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("ObtenerEmpleados", sql))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    var response = new List<EmpleadoModel>();
                    await sql.OpenAsync();

                    using (var reader = await cmd.ExecuteReaderAsync())
                    {
                        while (await reader.ReadAsync())
                        {
                            response.Add(MapToValue(reader));
                        }
                    }

                    return response;
                }
            }
        }

        private EmpleadoModel MapToValue(SqlDataReader reader)
        {
            return new EmpleadoModel()
            {
                EmpleadoId = (int)reader["EmpleadoId"],
                TipoDocumentoId = (int)reader["TipoDocumentoId"],
                //TipoDocumento = reader["TipoDocumento"].ToString(),
                NumeroDocumento = reader["NumeroDocumento"].ToString(),
                FechaNacimiento = Convert.ToDateTime(reader["FechaNacimiento"]),
                //NombreCompleto = reader["NombreCompleto"].ToString(),
                AreaId = (int)reader["AreaId"],
                //NombreArea = reader["NombreArea"].ToString(),
            };
        }
    }
}
