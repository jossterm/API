using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApplicationNet.BL.Models;
using WebApplicationNet.Models;

namespace WebApplicationNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolModuloController : Controller
    {
        private readonly IConfiguration _configuration;
        public RolModuloController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet("{id}")]

        public JsonResult GetModulosbyRol(int id)
        {


            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Sistema");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("GETROLMODULO1", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idRol", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }


        [HttpPut()]
        public JsonResult Put(RolModulo rm)
        {

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Sistema");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("PUTROLMODULO", myCon))
                {
                    myCommand.CommandType = CommandType.StoredProcedure;
                    myCommand.Parameters.AddWithValue("@idRol", rm.idRol);
                    myCommand.Parameters.AddWithValue("@idModulo", rm.idModulo);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Actualizado exitosamente");
        }


        [HttpPut("putRolModulo")]
        public JsonResult PutRolModulo(SchemaRolModulo rm)
        {

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Sistema");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                foreach (var Lista in rm.modulos)
                {
                    myCon.Open();
                    using (SqlCommand myCommand = new SqlCommand("PUTROLMODULO", myCon))
                    {
                        myCommand.CommandType = CommandType.StoredProcedure;
                        myCommand.Parameters.AddWithValue("@idRol", rm.idRol);
                        myCommand.Parameters.AddWithValue("@idModulo", Lista.id);
                        myReader = myCommand.ExecuteReader();
                        table.Load(myReader);
                        myReader.Close();
                        myCon.Close();

                        
                        
                    }
                    Console.WriteLine("{0}",Lista); 

                }
            }

            return new JsonResult("Actualizado exitosamente");
        }

    }
}
