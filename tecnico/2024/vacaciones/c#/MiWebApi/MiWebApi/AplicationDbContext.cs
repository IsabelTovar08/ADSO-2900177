using Microsoft.EntityFrameworkCore;
using MiWebApi.Entidades;

namespace MiWebApi
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Laptop> Laptop { get; set; }
    }
}
