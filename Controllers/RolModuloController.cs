using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using WebApplicationNet.BL.Models;


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

        public JsonResult Get(int id)
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
                    myCommand.Parameters.AddWithValue("@id", id);
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);
                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult(table);
        }


        [HttpPost]  
        public JsonResult Create()
        {
           
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("Sistema");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand("GETROLMODULO", myCon))
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
        
    }
}
