using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Entity.Context;
using Entity.DTOs;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    /// <summary>
    /// Clase para la gestión de usuarios en la base de datos.
    /// </summary>
    public class UserData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<UserData> _logger;

        public UserData(ApplicationDbContext context, ILogger<UserData> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los usuarios con LINQ.
        /// </summary>
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            try
            {
                return await _context.Set<User>()
                    .Include(u => u.Person) // Incluye la relación con la persona
                    .Where(u => u.Status) // Filtra solo los usuarios con estado true
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener todos los usuarios: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los usuarios activos con SQL, incluyendo los datos de la persona asociada.
        /// </summary>
        public async Task<IEnumerable<User>> GetAllAsyncSQL()
        {
            try
            {
                const string query = @"
            SELECT u.*, p.FirstName, p.LastName, p.MiddleName, p.SecondLastName
            FROM [User] u
            INNER JOIN Person p ON u.PersonId = p.Id
            WHERE u.Status = 1;"; // Solo usuarios activos

                var connection = _context.Database.GetDbConnection();

                var users = await connection.QueryAsync<User, Person, User>(
                    query,
                    (user, person) =>
                    {
                        user.Person = person; // Asigna toda la entidad Person al User
                        return user;
                    },
                    splitOn: "FirstName"
                );

                return users;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los usuarios activos: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Obtiene un usuario por ID con LINQ.
        /// </summary>
        public async Task<User?> GetByIdAsync(int id)
        {
            try 
            { 
                return await _context.Set<User>().FindAsync(id); 
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el usuario con ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene un usuario por ID con SQL.
        /// </summary>
        public async Task<User?> GetByIdAsyncSQL(int id)
        {
            try
            {
                const string query = "SELECT * FROM User WHERE Id = @Id;";
                var parameters = new { Id = id };
                return await _context.QueryFirstOrDefaultAsync<User>(query, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el usuario con ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Crea un usuario con LINQ.
        /// </summary>
        public async Task<User> CreateAsync(User user)
        {
            try
            {
                var personExists = await _context.Person.AnyAsync(p => p.Id == user.PersonId);
                if (!personExists)
                {
                    throw new Exception("La persona asociada al usuario no existe.");
                }

                user.Status = true; 
                await _context.Set<User>().AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el usuario: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Crea un usuario con SQL.
        /// </summary>
        public async Task<User> CreateAsyncSQL(User user)
        {
            try
            {
                user.Status = true;

                const string query = @"
            INSERT INTO [User] (Username, Password, Status, ActivationCode, PersonId) 
            OUTPUT INSERTED.Id 
            VALUES (@Username, @Password, @Status, @ActivationCode, @PersonId);";

                var connection = _context.Database.GetDbConnection();
                user.Id = await connection.ExecuteScalarAsync<int>(query, user);

                return user;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el usuario: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Actualiza un usuario con LINQ.
        /// </summary>
        public async Task<bool> UpdateAsync(User user)
        {
            try
            {
                var existingUser = await _context.Set<User>().FindAsync(user.Id);
                if (existingUser != null)
                {
                    _context.Entry(existingUser).State = EntityState.Detached; // Evita conflicto de seguimiento
                    user.Status = existingUser.Status; // Mantiene el Status original
                }

                _context.Set<User>().Update(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el usuario {user.Id}: {ex.Message}");
                return false;
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
                var user = await _context.Set<User>().FindAsync(id);
                if (user == null) return false;
                user.Status = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al desactivar el usuario {id}: {ex.Message}");
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
                const string query = "UPDATE User SET Status = 0 WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al desactivar el usuario {id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina permanentemente un usuario con LINQ.
        /// </summary>
        public async Task<bool> HardDeleteAsync(int id)
        {
            try
            {
                var user = await _context.Set<User>().FindAsync(id);
                if (user == null) return false;
                _context.Set<User>().Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el usuario: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina permanentemente un usuario con SQL.
        /// </summary>
        public async Task<bool> HardDeleteAsyncSQL(int id)
        {
            try
            {
                const string query = "DELETE FROM User WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al eliminar el usuario: {ex.Message}");
                return false;
            }
        }
    }
}
