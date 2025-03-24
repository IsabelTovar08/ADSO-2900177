using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    public class RolData
    {
        private readonly ApplicationDbContext _context;

        private readonly ILogger _logger;

        public RolData(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            string query = "SELECT * FROM Role";
            return (IEnumerable<Role>)await _context.QueryAsync<IEnumerable<Role>>(query);
            //return await _context.Set<Role>().ToListAsync();
        }
        public async Task<Role?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Role>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el rol con ID: {id}");
                throw;
            }
        }

        public async Task<Role> CreateAsync(Role role)
        {
            try
            {
                await _context.Set<Role>().AddAsync(role);
                await _context.SaveChangesAsync();
                return role;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el rol: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(Role role)
        {
            try
            {
                _context.Set<Role>().Update(role);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el rol: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var role = await _context.Set<Role>().FindAsync(id);
                if (role == null) return false;

                _context.Set<Role>().Remove(role);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el rol: {ex.Message}");
                return false;
            }
        }
    }

}
