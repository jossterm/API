using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using WebApplicationNet.BL.Models;


namespace WebApplicationNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolController : ControllerBase
    {
        //Para leer las conexion string de appsettings.json utilizamos
        //la inyeccion de dependencias

        private readonly IConfiguration _configuration;
        public RolController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public List<SchemaRol> Get()
        {

            List<SchemaRol> Roles = new List<SchemaRol>();
            string sqlDataSource = _configuration.GetConnectionString("Sistema");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("GETROL", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myReader = myCommand.ExecuteReader();
                    
                    while (myReader.Read())
                    {
                        SchemaRol rol = new SchemaRol();
                        rol.idRol = (int)myReader["id"];
                        rol.nombre = (string)myReader["nombre"];
                        
                        Roles.Add(rol);
                    }

                    myReader.Close();
                    myCon.Close();    
                }
            }
            Console.WriteLine(Roles);
            return Roles;
            
           
        }

        [HttpPost]

        public JsonResult Post(Rol r)
        {
            
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Sistema");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("POSTROL", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@nombre", r.nombre);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Agregado exitosamente");
        }

        [HttpPut]

        public JsonResult Put(Rol r)
        {
            
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Sistema");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("PUTROL", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", r.id);
                    myCommand.Parameters.AddWithValue("@nombre", r.nombre);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Actualizado exitosamente");
        }

        [HttpDelete()]
        public JsonResult Delete(Rol r)
        {
            
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Sistema");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("DELETEROL", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", r.id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Eliminado exitosamente");
        }

    }
}
