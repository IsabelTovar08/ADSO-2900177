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
    /// Clase para la gestión de la entidad UserRole en la base de datos.
    /// </summary>
    public class UserRoleData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserRoleData> _logger;

        public UserRoleData(ApplicationDbContext context, ILogger<UserRoleData> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todas las relaciones UserRole con LINQ.
        /// </summary>
        public async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            try
            {
                return await _context.Set<UserRole>()
                    .Include(ur => ur.User)
                    .Include(ur => ur.Role)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener UserRoles: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las relaciones UserRole con SQL.
        /// </summary>
        public async Task<IEnumerable<UserRole>> GetAllAsyncSQL()
        {
            try
            {
                const string query = @"SELECT ur.*, u.Name AS UserName, r.Name AS RoleName FROM UserRole ur 
                                    INNER JOIN User u ON ur.UserId = u.Id 
                                    INNER JOIN Role r ON ur.RoleId = r.Id;";
                return await _context.QueryAsync<UserRole>(query);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los UserRoles. {ex}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene una relación UserRole por ID con LINQ.
        /// </summary>
        public async Task<UserRole?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<UserRole>()
                    .Include(ur => ur.User)
                    .Include(ur => ur.Role)
                    .FirstOrDefaultAsync(ur => ur.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener UserRole por ID: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Obtiene una relación UserRole por ID con SQL.
        /// </summary>
        public async Task<UserRole> GetByIdAsyncSQL(int id)
        {
            try
            {
                const string query = @"SELECT ur.*, u.Username AS UserName, r.Name AS RoleName
                                    FROM UserRole ur
                                    INNER JOIN User u ON ur.UserId = u.Id
                                    INNER JOIN Role r ON ur.RoleId = r.Id
                                    WHERE ur.Id = @Id;";
                var parameters = new { Id = id };
                return await _context.QueryFirstOrDefaultAsync<UserRole>(query, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener UserRole por ID: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Crea una relación UserRole con LINQ.
        /// </summary>
        public async Task<UserRole> CreateAsync(UserRole userRole)
        {
            try
            {
                var userExists = await _context.User.AnyAsync(u => u.Id == userRole.UserId);
                if (!userExists)
                {
                    throw new Exception("El usuario no existe.");
                }

                await _context.Set<UserRole>().AddAsync(userRole);
                await _context.SaveChangesAsync();
                return userRole;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear UserRole: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Crea una relación UserRole con SQL.
        /// </summary>
        public async Task<UserRole> CreateAsyncSQL(UserRole userRole)
        {
            try
            {
                const string query = "INSERT INTO UserRole (UserId, RoleId) OUTPUT INSERTED.Id VALUES (@UserId, @RoleId);";
                var parameters = new { userRole.UserId, userRole.RoleId };
                userRole.Id = await _context.ExecuteScalarAsync<int>(query, parameters);
                return userRole;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear UserRole: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Actualiza un usuario con LINQ.
        /// </summary>
        public async Task<bool> UpdateAsync(UserRole userRole)
        {
            try
            {
                var existingUserRole = await _context.Set<UserRole>().FindAsync(userRole.Id);
                if (existingUserRole != null)
                {
                    _context.Entry(existingUserRole).State = EntityState.Detached; // Evita conflicto de seguimiento
                    userRole.Status = existingUserRole.Status; // Mantiene el Status original
                }

                _context.Set<UserRole>().Update(userRole);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el usuario rol {userRole.Id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Actualiza un usuario con SQL.
        /// </summary>
        public async Task<bool> UpdateAsyncSQL(UserRole userRole)
        {
            try
            {
                var existingUserRole = await _context.Set<UserRole>().FindAsync(userRole.Id);
                if (existingUserRole == null)
                {
                    _logger.LogWarning($"No se encontró el rol de usuario con ID {userRole.Id}");
                    return false;
                }

                // Mantener el estado original
                userRole.Status = existingUserRole.Status;

                const string query = @"
        UPDATE UserRole 
        SET UserId = @UserId, RoleId = @RoleId, Status = @Status
        WHERE Id = @Id;";

                var parameters = new { userRole.Id, userRole.UserId, userRole.RoleId, userRole.Status };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);

                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el rol de usuario {userRole.Id}: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Actualiza un usuario con SQL.
        /// </summary>
        public async Task<bool> UpdateAsyncSQL(User user)
        {
            try
            {
                var existingUser = await _context.Set<User>().FindAsync(user.Id);
                if (existingUser != null)
                {
                    user.Status = existingUser.Status; // Mantiene el Status original
                }

                const string query = @"
            UPDATE User 
            SET Username = @Username, Password = @Password, ActivationCode = @ActivationCode
            WHERE Id = @Id;";

                var parameters = new { user.Id, user.Username, user.Password, user.ActivationCode };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el usuario {user.Id}: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Desactiva un usuario (eliminación lógica) con LINQ.
        /// </summary>
        public async Task<bool> SoftDeleteAsync(int id)
        {
            try
            {
                var userRole = await _context.Set<UserRole>().FindAsync(id);
                if (userRole == null) return false;
                userRole.Status = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al desactivar el usuario rol {id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Desactiva un usuario (eliminación lógica) con SQL.
        /// </summary>
        public async Task<bool> SoftDeleteAsyncSQL(int id)
        {
            try
            {
                const string query = "UPDATE UserRoles SET Status = 0 WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al desactivar el usuario rol {id}: {ex.Message}");
                return false;
            }
        }


        /// <summary>
        /// Elimina permanentemente una relación UserRole con LINQ.
        /// </summary>
        public async Task<bool> HardDeleteAsync(int id)
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
                _logger.LogError($"Error al eliminar UserRole: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina permanentemente una relación UserRole con SQL.
        /// </summary>
        public async Task<bool> HardDeleteAsyncSQL(int id)
        {
            try
            {
                const string query = "DELETE FROM UserRole WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar UserRole: {ex.Message}");
                return false;
            }
        }
    }
}
