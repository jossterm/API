using System.Data.Entity;
using WebApplicationNet.BL.Models;


namespace WebApplicationNet.BL.Data

{
    public class ProyectoContext : DbContext
    {
        public ProyectoContext()
            : base(@"Server=DESKTOP-N4CS575;Database=Sistema;Integrated Security=True")
        {

        }
        
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Modulo> Modulos { get; set; }
        public DbSet<RolModulo> RolModulos { get; set; }

        public static ProyectoContext Create()
        {
            return new ProyectoContext();
        }
    }
}
