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
        private readonly ILogger _logger;

        public UserRoleData(ApplicationDbContext context, ILogger logger)
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
