
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationNet.BL.Models

{   [Table("Usuario", Schema = "dbo")]
    public class Usuario
    {   
        [Key]
        // [DatabaseGenerated(DatabaseGeneratedOption.None)] -- Id no autoincrementable
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string correo { get; set; }
        public string telefono { get; set; }
        public string cargo { get; set; }   
        public int idRol { get; set; }

        public virtual ICollection<Rol> Rol { get; set; } 

        //public Rol Rol { get; set; }


    }
}
