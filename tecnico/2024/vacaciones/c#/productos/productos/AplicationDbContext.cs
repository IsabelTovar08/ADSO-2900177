using Microsoft.EntityFrameworkCore;
using Productos.Entidadess;

namespace Productos
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Producto> Producto { get; set; }
    }
}
