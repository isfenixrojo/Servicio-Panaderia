using API.Panaderia.Dominio.Modelos;
using Microsoft.EntityFrameworkCore;

namespace API.Panaderia.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Pan> Panes { get; set; }
    }
}
