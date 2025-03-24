using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    public class RoleUserData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public RoleUserData(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            return await _context.Set<UserRole>().ToListAsync();
        }

        public async Task<UserRole?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<UserRole>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el Usuario Rol con ID: {id}");
                throw;
            }
        }

        public async Task<UserRole> CreateAsync(UserRole userRole)
        {
            try
            {
                await _context.Set<UserRole>().AddAsync(userRole);
                await _context.SaveChangesAsync();
                return userRole;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el Usuario Rol: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(UserRole userRole)
        {
            try
            {
                _context.Set<UserRole>().Update(userRole);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el Usuario Rol: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var userRole = await _context.Set<UserRole>().FindAsync(id);
                if (userRole == null) return false;

                _context.Set<UserRole>().Remove(userRole);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el Usuario Rol: {ex.Message}");
                return false;
            }
        }
    }
}
