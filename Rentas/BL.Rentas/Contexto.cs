using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BL.Rentas
{
    public class Contexto: DbContext
    {
        public Contexto(): base("Rentas")
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            Database.SetInitializer(new DatosdeInicio());
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}