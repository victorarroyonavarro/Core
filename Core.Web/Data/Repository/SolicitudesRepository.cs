using Dapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Core.Web.Data.Repository
{
    public class SolicitudesRepository : ISolicitudRepository
    {
        private readonly IConfiguration _conf;

        private readonly ILogger<SolicitudesRepository> _logger;
        public SolicitudesRepository(IConfiguration conf, ILogger<SolicitudesRepository> logger)
        {
            _conf = conf;

            _logger = logger;
        }


        public void Insertardireccion(string direccion, string latitud, string longitud)
        {
            using (var con = new SqlConnection(_conf.GetConnectionString("DocumentManagementConnection")))
            {
                string sql = @"
            INSERT INTO [usr_devlife].[Sucursal]
                       ([Direccion]
                       ,[Longitud]
                       ,[Latitud]
                       ,[Fecha_Ingreso]
                       ,[Fecha_Actualizacion]
                       ,[Estado])
                 VALUES
                       ('" + direccion + @"'
                       ,'" + longitud + @"'
                       ,'" + latitud+@"'
                       ,getdate()
                       ,getdate()
                       ,1)";


                con.Execute(sql.ToString(), null, null, 240);
            }
        }

        public IEnumerable<dynamic> listar_sucursal()
        {

            var respuestasucrusales = new List<dynamic>();
            using (var con = new SqlConnection(_conf.GetConnectionString("DocumentManagementConnection")))
            {
                string sql = @"SELECT [id_Sucursal]
                      ,[Direccion]
                      ,[Longitud]
                      ,[Latitud]
                      ,[Fecha_Ingreso]
                      ,[Fecha_Actualizacion]
                      ,[Estado]
                  FROM [usr_devlife].[Sucursal]";
                respuestasucrusales = con.Query<dynamic>(sql).AsList();

            }

            return (respuestasucrusales);
        }



    }
}