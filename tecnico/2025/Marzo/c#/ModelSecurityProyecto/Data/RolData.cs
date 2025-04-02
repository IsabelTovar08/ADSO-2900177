using System;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    /// <summary>
    /// Manejo de datos de roles.
    /// </summary>
    public class RolData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<RolData> _logger;

        public RolData(ApplicationDbContext context, ILogger<RolData> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los roles con LINQ.
        /// </summary>
        public async Task<IEnumerable<Role>> GetAllAsync()
        {
            try
            {
                return await _context.Set<Role>()
                    .Where(r => r.Status) // Filtra solo los roles activos
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener roles: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los roles con SQL.
        /// </summary>
        public async Task<IEnumerable<Role>> GetAllAsyncSQL()
        {
            try
            {
                const string query = "SELECT * FROM Roles WHERE Status = 1;";
                return await _context.QueryAsync<Role>(query);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener roles. {ex}");
                throw;
            }
        }


        /// <summary>
        /// Obtiene un rol por ID con LINQ.
        /// </summary>
        public async Task<Role?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Role>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el rol {id}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene un rol por ID con SQL.
        /// </summary>
        public async Task<Role?> GetByIdAsyncSQL(int id)
        {
            try
            {
                const string query = "SELECT * FROM Role WHERE Id = @Id;";
                var parameters = new { Id = id };
                return await _context.QueryFirstOrDefaultAsync<Role>(query, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el rol {id}");
                throw;
            }
        }

        /// <summary>
        /// Crea un nuevo rol con LINQ.
        /// </summary>
        public async Task<Role> CreateAsync(Role role)
        {
            try
            {
                role.Status = true; // Asegurar que el status sea true por defecto
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

        /// <summary>
        /// Crea un nuevo rol con SQL.
        /// </summary>
        public async Task<Role> CreateAsyncSQL(Role role)
        {
            try
            {
                role.Status = true; // Asegurar que el status sea true por defecto
                const string query = "INSERT INTO Role (Name, Description, Status) OUTPUT INSERTED.Id VALUES (@Name, @Description, @Status);";
                var parameters = new { role.Name, role.Description, role.Status };
                role.Id = await _context.ExecuteScalarAsync<int>(query, parameters);
                return role;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el rol: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Actualiza un rol con LINQ.
        /// </summary>
        public async Task<bool> UpdateAsync(Role role)
        {
            try
            {
                var existingRole = await _context.Set<Role>().FindAsync(role.Id);
                if (existingRole == null)
                {
                    _logger.LogWarning($"No se encontró el rol con ID {role.Id} para actualizar.");
                    return false;
                }

                _context.Entry(existingRole).State = EntityState.Detached; // Evita conflictos de seguimiento
                role.Status = existingRole.Status; // Mantiene el estado actual

                _context.Set<Role>().Update(role);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el rol {role.Id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Actualiza un rol con SQL.
        /// </summary>
        public async Task<bool> UpdateAsyncSQL(Role role)
        {
            try
            {
                const string query = "UPDATE Role SET Name = @Name, Description = @Description WHERE Id = @Id;";
                var parameters = new { role.Id, role.Name, role.Description };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el rol {role.Id}: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Elimina lógicamente un rol con LINQ.
        /// </summary>
        public async Task<bool> SoftDeleteAsync(int id)
        {
            try
            {
                var role = await _context.Set<Role>().FindAsync(id);
                if (role == null) return false;

                role.Status = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el rol {id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina lógicamente un rol con SQL.
        /// </summary>
        public async Task<bool> SoftDeleteAsyncSQL(int id)
        {
            try
            {
                const string query = "UPDATE Role SET Status = 0 WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el rol {id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina permanentemente un rol con LINQ.
        /// </summary>
        public async Task<bool> HardDeleteAsync(int id)
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

        /// <summary>
        /// Elimina permanentemente un rol con SQL.
        /// </summary>
        public async Task<bool> HardDeleteAsyncSQL(int id)
        {
            try
            {
                const string query = "DELETE FROM Role WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el rol: {ex.Message}");
                return false;
            }
        }
    }
}
