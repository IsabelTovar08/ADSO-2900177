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
    /// Clase para la gestión de permisos en la base de datos.
    /// </summary>
    public class PermissionData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<PermissionData> _logger;

        public PermissionData(ApplicationDbContext context, ILogger<PermissionData> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los permisos con LINQ.
        /// </summary>
        public async Task<IEnumerable<Permission>> GetAllAsync()
        {
            try
            {
                return await _context.Set<Permission>()
                    .Where(p => p.Status) // Filtra solo los permisos activos
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener todos los permisos: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los permisos con SQL.
        /// </summary>
        public async Task<IEnumerable<Permission>> GetAllAsyncSQL()
        {
            try
            {
                const string query = "SELECT * FROM Permission WHERE Status = 1;";
                return await _context.QueryAsync<Permission>(query);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los permisos. {ex}");
                throw;
            }
        }


        /// <summary>
        /// Obtiene un permiso por ID con LINQ.
        /// </summary>
        public async Task<Permission?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Permission>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el permiso con ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene un permiso por ID con SQL.
        /// </summary>
        public async Task<Permission?> GetByIdAsyncSQL(int id)
        {
            try
            {
                const string query = "SELECT * FROM Permission WHERE Id = @Id;";
                var parameters = new { Id = id };
                return await _context.QueryFirstOrDefaultAsync<Permission>(query, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el permiso con ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Crea un permiso con LINQ.
        /// </summary>
        public async Task<Permission> CreateAsync(Permission permission)
        {
            try
            {
                permission.Status = true; // Asegurar que el status sea true por defecto
                await _context.Set<Permission>().AddAsync(permission);
                await _context.SaveChangesAsync();
                return permission;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el permiso: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Crea un permiso con SQL.
        /// </summary>
        public async Task<Permission> CreateAsyncSQL(Permission permission)
        {
            try
            {
                permission.Status = true; // Asegurar que el status sea true por defecto
                const string query = "INSERT INTO Permission (Name, Description, Status) OUTPUT INSERTED.Id VALUES (@Name, @Description, @Status);";
                var parameters = new { permission.Name, permission.Description, permission.Status };
                permission.Id = await _context.ExecuteScalarAsync<int>(query, parameters);
                return permission;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el permiso: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Actualiza un permiso con LINQ.
        /// </summary>
        public async Task<bool> UpdateAsync(Permission permission)
        {
            try
            {
                var existingPermission = await _context.Set<Permission>().FindAsync(permission.Id);
                if (existingPermission == null)
                {
                    _logger.LogWarning($"No se encontró el permiso con ID {permission.Id} para actualizar.");
                    return false;
                }

                _context.Entry(existingPermission).State = EntityState.Detached; // Evita conflictos de seguimiento
                permission.Status = existingPermission.Status; // Mantiene el estado actual

                _context.Set<Permission>().Update(permission);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el permiso {permission.Id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Actualiza un permiso con SQL.
        /// </summary>
        public async Task<bool> UpdateAsyncSQL(Permission permission)
        {
            try
            {
                const string query = "UPDATE Permission SET Name = @Name, Description = @Description WHERE Id = @Id;";
                var parameters = new { permission.Id, permission.Name, permission.Description };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el permiso {permission.Id}: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Desactiva un permiso (eliminación lógica) con LINQ.
        /// </summary>
        public async Task<bool> SoftDeleteAsync(int id)
        {
            try
            {
                var permission = await _context.Set<Permission>().FindAsync(id);
                if (permission == null) return false;
                permission.Status = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al desactivar el permiso {id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Desactiva un permiso (eliminación lógica) con SQL.
        /// </summary>
        public async Task<bool> SoftDeleteAsyncSQL(int id)
        {
            try
            {
                const string query = "UPDATE Permission SET State = 0 WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al desactivar el permiso {id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina permanentemente un permiso con LINQ.
        /// </summary>
        public async Task<bool> HardDeleteAsync(int id)
        {
            try
            {
                var permission = await _context.Set<Permission>().FindAsync(id);
                if (permission == null) return false;
                _context.Set<Permission>().Remove(permission);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el permiso: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina permanentemente un permiso con SQL.
        /// </summary>
        public async Task<bool> HardDeleteAsyncSQL(int id)
        {
            try
            {
                const string query = "DELETE FROM Permission WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el permiso: {ex.Message}");
                return false;
            }
        }
    }
}
