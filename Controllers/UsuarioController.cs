using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApplicationNet.BL.Models;



namespace WebApplicationNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        //Para leer las conexion string de appsettings.json utilizamos
        //la inyeccion de dependencias

        private readonly IConfiguration _configuration;
        public UsuarioController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        //async await
        public JsonResult Get()
        {
                   
            
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Sistema");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using(SqlCommand myCommand=new SqlCommand("GETUSUARIO", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }

        [HttpPost]

        public JsonResult Post(BL.Models.Usuario us)
        {
            
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Sistema");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("POSTUSUARIO", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@nombre", us.nombre);
                    myCommand.Parameters.AddWithValue("@apellido", us.apellido);
                    myCommand.Parameters.AddWithValue("@correo", us.correo);
                    myCommand.Parameters.AddWithValue("@telefono", us.telefono);
                    myCommand.Parameters.AddWithValue("@cargo", us.cargo);
                    myCommand.Parameters.AddWithValue("@idRol", us.idRol);                              
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Agregado exitosamente");
        }

        [HttpPut]

        public JsonResult Put(BL.Models.Usuario us)
        {
            
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Sistema");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("PUTUSUARIO", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", us.id);
                    myCommand.Parameters.AddWithValue("@nombre", us.nombre);
                    myCommand.Parameters.AddWithValue("@apellido", us.apellido);
                    myCommand.Parameters.AddWithValue("@correo", us.correo);
                    myCommand.Parameters.AddWithValue("@telefono", us.telefono);
                    myCommand.Parameters.AddWithValue("@cargo", us.cargo);
                    myCommand.Parameters.AddWithValue("@idRol", us.idRol);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Actualizado exitosamente");
        }

        [HttpDelete()]
        public JsonResult Delete(BL.Models.Usuario us)
        {
            
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Sistema");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("DELETEUSUARIO", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", us.id);
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
