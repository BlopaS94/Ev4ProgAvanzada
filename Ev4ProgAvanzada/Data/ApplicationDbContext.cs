using Microsoft.EntityFrameworkCore;
using Ev4ProgAvanzada.Models;

namespace Ev4ProgAvanzada.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Agente> Agentes { get; set; }
        public DbSet<Proyecto> Proyectos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
