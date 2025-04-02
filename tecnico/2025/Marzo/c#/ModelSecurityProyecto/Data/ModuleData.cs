using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dapper;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data
{
    /// <summary>
    /// Clase para la gestión de módulos en la base de datos.
    /// </summary>
    public class ModuleData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ModuleData> _logger;

        public ModuleData(ApplicationDbContext context, ILogger<ModuleData> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los módulos con LINQ.
        /// </summary>
        public async Task<IEnumerable<Module>> GetAllAsync()
        {
            try
            {
                return await _context.Set<Module>()
                    .Where(m => m.Status) // Filtra solo los módulos con Status en true
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener todos los módulos activos: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Obtiene todos los módulos con SQL.
        /// </summary>
        public async Task<IEnumerable<Module>> GetAllAsyncSQL()
        {
            try
            {
                const string query = "SELECT * FROM Module WHERE Status = 1;";
                return await _context.QueryAsync<Module>(query);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los módulos. {ex}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene un módulo por ID con LINQ.
        /// </summary>
        public async Task<Module?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Module>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el módulo con ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene un módulo por ID con SQL.
        /// </summary>
        public async Task<Module?> GetByIdAsyncSQL(int id)
        {
            try
            {
                const string query = "SELECT * FROM Module WHERE Id = @Id;";
                var parameters = new { Id = id };
                return await _context.QueryFirstOrDefaultAsync<Module>(query, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el módulo con ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Crea un módulo con LINQ.
        /// </summary>
        public async Task<Module> CreateAsync(Module module)
        {
            try
            {
                module.Status = true;
                await _context.Set<Module>().AddAsync(module);
                await _context.SaveChangesAsync();
                return module;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el módulo: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Crea un módulo con SQL.
        /// </summary>
        public async Task<Module> CreateAsyncSQL(Module module)
        {
            try
            {
                module.Status = true; // Asegurar que siempre sea true al crear
                const string query = @"
                    INSERT INTO Module (Name, Description, Status) 
                    OUTPUT INSERTED.Id 
                    VALUES (@Name, @Description, @Status);";

                var connection = _context.Database.GetDbConnection();
                module.Id = await connection.ExecuteScalarAsync<int>(query, module);
                return module;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el módulo: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Actualiza un módulo con LINQ.
        /// </summary>
        public async Task<bool> UpdateAsync(Module module)
        {
            try
            {
                var existingModule = await _context.Set<Module>().FindAsync(module.Id);
                if (existingModule != null)
                {
                    _context.Entry(existingModule).State = EntityState.Detached; // 🔥 Evita el conflicto
                }

                module.Status = existingModule.Status;

                _context.Set<Module>().Update(module);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"No se pudo actualizar el módulo con ID: {module.Id}");
                throw;
            }
        }


        /// <summary>
        /// Actualiza un módulo con SQL.
        /// </summary>
        public async Task<bool> UpdateAsyncSQL(Module module)
        {
            try
            {
                const string query = @"
                    UPDATE Module 
                    SET Name = @Name, Description = @Description, Status = @Status 
                    WHERE Id = @Id;";

                var connection = _context.Database.GetDbConnection();
                int rowsAffected = await connection.ExecuteAsync(query, module);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el módulo {module.Id}: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Desactiva un módulo (eliminación lógica) con LINQ.
        /// </summary>
        public async Task<bool> SoftDeleteAsync(int id)
        {
            try
            {
                var module = await _context.Set<Module>().FindAsync(id);
                if (module == null) return false;
                module.Status = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al desactivar el módulo {id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Desactiva un módulo (eliminación lógica) con SQL.
        /// </summary>
        public async Task<bool> SoftDeleteAsyncSQL(int id)
        {
            try
            {
                const string query = "UPDATE Module SET Status = 0 WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al desactivar el módulo {id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina permanentemente un módulo con LINQ.
        /// </summary>
        public async Task<bool> HardDeleteAsync(int id)
        {
            try
            {
                var module = await _context.Set<Module>().FindAsync(id);
                if (module == null) return false;
                _context.Set<Module>().Remove(module);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el módulo: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina permanentemente un módulo con SQL.
        /// </summary>
        public async Task<bool> HardDeleteAsyncSQL(int id)
        {
            try
            {
                const string query = "DELETE FROM Module WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el módulo: {ex.Message}");
                return false;
            }
        }
    }
}
