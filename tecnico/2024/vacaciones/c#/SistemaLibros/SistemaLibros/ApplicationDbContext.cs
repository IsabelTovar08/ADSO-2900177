using Microsoft.EntityFrameworkCore;
using SistemaLibros.Entidades;

namespace SistemaLibros
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Libro> Libros { get; set; }
    }
}
