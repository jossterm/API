using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationNet.BL.Models
{
    [Table("Modulo", Schema = "dbo")]
    public class Modulo
    {   
        [Key]
        public int id { get; set; }
        public string nombre { get; set; }

        
        
    }
}
