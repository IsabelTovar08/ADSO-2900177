using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    /// <summary>
    /// Clase para la gestión de la entidad RoleFormPermission en la base de datos.
    /// </summary>
    public class RoleFormPermissionData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RoleFormPermissionData> _logger;

        public RoleFormPermissionData(ApplicationDbContext context, ILogger<RoleFormPermissionData> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todas las relaciones RoleFormPermission con LINQ.
        /// </summary>
        public async Task<IEnumerable<RoleFormPermission>> GetAllAsync()
        {
            try
            {
                return await _context.Set<RoleFormPermission>()
                    .Include(rfp => rfp.Role)
                    .Include(rfp => rfp.Form)
                    .Include(rfp => rfp.Permission)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener RoleFormPermissions: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las relaciones RoleFormPermission con SQL.
        /// </summary>
        public async Task<IEnumerable<RoleFormPermission>> GetAllAsyncSQL()
        {
            try
            {
                const string query = @"SELECT rfp.*, r.Name AS RoleName, f.Name AS FormName, p.Name AS PermissionName FROM RoleFormPermission rfp 
                                    INNER JOIN Role r ON rfp.RoleId = r.Id 
                                    INNER JOIN Form f ON rfp.FormId = f.Id 
                                    INNER JOIN Permission p ON rfp.PermissionId = p.Id;";
                return await _context.QueryAsync<RoleFormPermission>(query);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al obtener los RoleFormPermissions.");
                throw;
            }
        }

        /// <summary>
        /// Obtiene una relación RoleFormPermission por ID con LINQ.
        /// </summary>
        public async Task<RoleFormPermission> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<RoleFormPermission>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener RoleFormPermission por ID: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene una relación RoleFormPermission por ID con SQL.
        /// </summary>
        public async Task<RoleFormPermission> GetByIdAsyncSQL(int id)
        {
            try
            {
                const string query = @"SELECT rfp.*, r.Name AS RoleName, f.Name AS FormName, p.Name AS PermissionName 
                                    FROM RoleFormPermission rfp 
                                    INNER JOIN Role r ON rfp.RoleId = r.Id 
                                    INNER JOIN Form f ON rfp.FormId = f.Id 
                                    INNER JOIN Permission p ON rfp.PermissionId = p.Id 
                                    WHERE rfp.Id = @Id;";
                var parameters = new { Id = id };
                return await _context.QueryFirstOrDefaultAsync<RoleFormPermission>(query, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener RoleFormPermission por ID: {ex.Message}");
                throw;
            }
        }



        /// <summary>
        /// Crea una relación RoleFormPermission con LINQ.
        /// </summary>
        public async Task<RoleFormPermission> CreateAsync(RoleFormPermission roleFormPermission)
        {
            try
            {
                roleFormPermission.Status = true;
                await _context.Set<RoleFormPermission>().AddAsync(roleFormPermission);
                await _context.SaveChangesAsync();
                return roleFormPermission;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear RoleFormPermission: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Crea una relación RoleFormPermission con SQL.
        /// </summary>
        public async Task<RoleFormPermission> CreateAsyncSQL(RoleFormPermission roleFormPermission)
        {
            try
            {
                const string query = "INSERT INTO RoleFormPermission (RoleId, FormId, PermissionId) OUTPUT INSERTED.Id VALUES (@RoleId, @FormId, @PermissionId);";
                var parameters = new { roleFormPermission.RoleId, roleFormPermission.FormId, roleFormPermission.PermissionId };
                roleFormPermission.Id = await _context.ExecuteScalarAsync<int>(query, parameters);
                return roleFormPermission;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear RoleFormPermission: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Actualiza una relación RoleFormPermission con LINQ.
        /// </summary>
        public async Task<bool> UpdateAsync(RoleFormPermission roleFormPermission)
        {
            try
            {
                var existingRoleFormPermission = await _context.Set<RoleFormPermission>().FindAsync(roleFormPermission.Id);
                if (existingRoleFormPermission != null)
                {
                    _context.Entry(existingRoleFormPermission).State = EntityState.Detached; // Evita conflicto de seguimiento
                    roleFormPermission.Status = existingRoleFormPermission.Status; // Mantiene el Status original
                }

                _context.Set<RoleFormPermission>().Update(roleFormPermission);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el usuario rol form permission {roleFormPermission.Id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Desactiva un RolFormPErmission (eliminación lógica) con LINQ.
        /// </summary>
        public async Task<bool> SoftDeleteAsync(int id)
        {
            try
            {
                var roleFormPErmission = await _context.Set<RoleFormPermission>().FindAsync(id);
                if (roleFormPErmission == null) return false;
                roleFormPErmission.Status = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al desactivar el role form permission {id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Desactiva un RolFormPErmission (eliminación lógica) con SQL.
        /// </summary>
        public async Task<bool> SoftDeleteAsyncSQL(int id)
        {
            try
            {
                const string query = "UPDATE RoleFormPermissioSet SET Status = 0 WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al desactivar el rol form permisio {id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina permanentemente una relación RoleFormPermission con LINQ.
        /// </summary>
        public async Task<bool> HardDeleteAsync(int id)
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
                _logger.LogError($"Error al eliminar RoleFormPermission: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina permanentemente una relación RoleFormPermission con SQL.
        /// </summary>
        public async Task<bool> HardDeleteAsyncSQL(int id)
        {
            try
            {
                const string query = "DELETE FROM RoleFormPermission WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar RoleFormPermission: {ex.Message}");
                return false;
            }
        }
    }
}
