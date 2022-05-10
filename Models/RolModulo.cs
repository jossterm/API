using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationNet.BL.Models
{
    [Table("RolModulo", Schema = "dbo")]
    public class RolModulo
    {   
        [ForeignKey("Rol")]
        public int idRol { get; set; }

        [ForeignKey("Modulo")]
        public int idModulo { get; set; }


    }
}
