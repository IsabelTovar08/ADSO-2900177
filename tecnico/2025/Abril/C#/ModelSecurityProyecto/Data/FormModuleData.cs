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
    /// Clase para la gestión de la entidad FormModule en la base de datos.
    /// </summary>
    public class FormModuleData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FormModule> _logger;

        public FormModuleData(ApplicationDbContext context, ILogger<FormModule> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todas las relaciones FormModule con LINQ.
        /// </summary>
        public async Task<IEnumerable<FormModule>> GetAllAsync()
        {
            try
            {
                return await _context.Set<FormModule>()
                    .Include(fm => fm.Form)
                    .Include(fm => fm.Module)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener FormModules: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todas las relaciones FormModule con SQL.
        /// </summary>
        public async Task<IEnumerable<FormModule>> GetAllAsyncSQL()
        {
            try
            {
                const string query = @"SELECT fm.*, f.Name AS FormName, m.Name AS ModuleName FROM FormModule fm 
                                    INNER JOIN Form f ON fm.FormId = f.Id 
                                    INNER JOIN Module m ON fm.ModuleId = m.Id;";
                return await _context.QueryAsync<FormModule>(query);
            }
            catch (Exception ex)
            {
                _logger.LogError("Error al obtener los FormModules.");
                throw;
            }
        }

        /// <summary>
        /// Obtiene una relación FormModule por ID con LINQ.
        /// </summary>
        public async Task<FormModule> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<FormModule>()
                    .Include(fm => fm.Form)
                    .Include(fm => fm.Module)
                    .FirstOrDefaultAsync(fm => fm.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener FormModule por ID: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene una relación FormModule por ID con SQL.
        /// </summary>
        public async Task<FormModule> GetByIdAsyncSQL(int id)
        {
            try
            {
                const string query = @"SELECT fm.*, f.Name AS FormName, m.Name AS ModuleName FROM FormModule fm 
                                    INNER JOIN Form f ON fm.FormId = f.Id 
                                    INNER JOIN Module m ON fm.ModuleId = m.Id 
                                    WHERE fm.Id = @Id;";
                var parameters = new { Id = id };
                return await _context.QueryFirstOrDefaultAsync<FormModule>(query, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener FormModule por ID: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Crea una relación FormModule con LINQ.
        /// </summary>
        public async Task<FormModule> CreateAsync(FormModule formModule)
        {
            try
            {
                await _context.Set<FormModule>().AddAsync(formModule);
                await _context.SaveChangesAsync();
                return formModule;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear FormModule: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Crea una relación FormModule con SQL.
        /// </summary>
        public async Task<FormModule> CreateAsyncSQL(FormModule formModule)
        {
            try
            {
                const string query = "INSERT INTO FormModule (FormId, ModuleId) OUTPUT INSERTED.Id VALUES (@FormId, @ModuleId);";
                var parameters = new { formModule.FormId, formModule.ModuleId };
                formModule.Id = await _context.ExecuteScalarAsync<int>(query, parameters);
                return formModule;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear FormModule: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Actualiza una relación FormModule con LINQ.
        /// </summary>
        public async Task<bool> UpdateAsync(FormModule formModule)
        {
            try
            {
                var existingFormModule = await _context.Set<FormModule>().FindAsync(formModule.Id);
                if (existingFormModule != null)
                {
                    _context.Entry(existingFormModule).State = EntityState.Detached; // Evita conflictos de seguimiento
                }

                formModule.Status = existingFormModule?.Status ?? true; // Mantiene el estado actual

                _context.Set<FormModule>().Update(formModule);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el formulario: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Actualiza una relación FormModule con SQL.
        /// </summary>
        public async Task<bool> UpdateAsyncSQL(FormModule formModule)
        {
            try
            {
                const string query = "UPDATE FormModule SET FormId = @FormId, ModuleId = @ModuleId WHERE Id = @Id;";
                var parameters = new { formModule.FormId, formModule.ModuleId, formModule.Id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar FormModule: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina permanentemente una relación FormModule con LINQ.
        /// </summary>
        public async Task<bool> HardDeleteAsync(int id)
        {
            try
            {
                var formModule = await _context.Set<FormModule>().FindAsync(id);
                if (formModule == null) return false;
                _context.Set<FormModule>().Remove(formModule);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar FormModule: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina permanentemente una relación FormModule con SQL.
        /// </summary>
        public async Task<bool> HardDeleteAsyncSQL(int id)
        {
            try
            {
                const string query = "DELETE FROM FormModule WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar FormModule: {ex.Message}");
                return false;
            }
        }
    }
}
