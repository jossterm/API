using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApplicationNet.BL.Models;




namespace WebApplicationNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuloController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public ModuloController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]

        public JsonResult Get()
        {

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Sistema");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("GETMODULO", myCon))
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

        public JsonResult Post(BL.Models.Modulo mod)
        {

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Sistema");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("POSTMODULO", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@nombre", mod.nombre);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Agregado exitosamente");
        }

        [HttpPut]
        public JsonResult Put(BL.Models.Modulo mod)
        {

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Sistema");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("PUTMODULO", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", mod.id);
                    myCommand.Parameters.AddWithValue("@nombre", mod.nombre);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Actualizado exitosamente");
        }

        [HttpDelete()]
        public JsonResult Delete(BL.Models.Modulo mod)
        {

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Sistema");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("DELETEMODULO", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@id", mod.id);
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
