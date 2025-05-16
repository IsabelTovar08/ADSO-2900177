using Administrador_de_Tareas.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Administrador_de_Tareas.Controllers
{
    public class ApicationDbContext : DbContext
    {
        public ApicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Tarea> Tareas { get; set; }
    }
}
