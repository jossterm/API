using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplicationNet.BL.Models
{
    [Table("Rol", Schema = "dbo")]
    public class Rol
    {
    
    [Key]
    public int id { get; set; }
       
    public string nombre { get; set; }

       
    }

}
