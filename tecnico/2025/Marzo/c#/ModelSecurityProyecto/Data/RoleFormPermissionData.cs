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
    public class RoleFormPermissionData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public RoleFormPermissionData(ApplicationDbContext context, ILogger logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<IEnumerable<RoleFormPermission>> GetAllAsync()
        {
            return await _context.Set<RoleFormPermission>().ToListAsync();
        }

        public async Task<RoleFormPermission?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<RoleFormPermission>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el los permisos que tiene el rol en cada formulario con ID: {id}");
                throw;
            }
        }

        public async Task<RoleFormPermission> CreateAsync(RoleFormPermission roleFormPermission)
        {
            try
            {
                await _context.Set<RoleFormPermission>().AddAsync(roleFormPermission);
                await _context.SaveChangesAsync();
                return roleFormPermission;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el los permisos que tiene el rol en cada formulario: {ex.Message}");
                throw;
            }
        }

        public async Task<bool> UpdateAsync(RoleFormPermission roleFormPermission)
        {
            try
            {
                _context.Set<RoleFormPermission>().Update(roleFormPermission);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el los permisos que tiene el rol en cada formulario: {ex.Message}");
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var roleFormPermission = await _context.Set<RoleFormPermission>().FindAsync(id);
                if (roleFormPermission == null) return false;

                _context.Set<RoleFormPermission>().Remove(roleFormPermission);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el los permisos que tiene el rol en cada formulario: {ex.Message}");
                return false;
            }
        }
    }
}
