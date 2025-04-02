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
    /// Clase para la gestión de formularios en la base de datos.
    /// </summary>
    public class FormData
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<FormData> _logger;

        public FormData(ApplicationDbContext context, ILogger<FormData> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los formularios con LINQ.
        /// </summary>
        public async Task<IEnumerable<Form>> GetAllAsync()
        {
            try
            {
                return await _context.Set<Form>()
                    .Where(f => f.Status) // Filtra solo los formularios activos
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener todos los formularios: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene todos los formularios con SQL.
        /// </summary>
        public async Task<IEnumerable<Form>> GetAllAsyncSQL()
        {
            try
            {
                const string query = "SELECT * FROM Form WHERE Status = 1;";
                return await _context.QueryAsync<Form>(query);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al obtener los formularios. {ex}");
                throw;
            }
        }


        /// <summary>
        /// Obtiene un formulario por ID con LINQ.
        /// </summary>
        public async Task<Form?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<Form>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el formulario con ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene un formulario por ID con SQL.
        /// </summary>
        public async Task<Form?> GetByIdAsyncSQL(int id)
        {
            try
            {
                const string query = "SELECT * FROM Form WHERE Id = @Id;";
                var parameters = new { Id = id };
                return await _context.QueryFirstOrDefaultAsync<Form>(query, parameters);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el formulario con ID: {id}");
                throw;
            }
        }

        /// <summary>
        /// Crea un formulario con LINQ.
        /// </summary>
        public async Task<Form> CreateAsync(Form form)
        {
            try
            {
                form.Status = true; // Asegurar que el formulario se cree como activo
                await _context.Set<Form>().AddAsync(form);
                await _context.SaveChangesAsync();
                return form;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el formulario: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Crea un formulario con SQL.
        /// </summary>
        public async Task<Form> CreateAsyncSQL(Form form)
        {
            try
            {
                form.Status = true; // Asegurar que el formulario se cree como activo
                const string query = "INSERT INTO Form (Name, Description, Url, Status) OUTPUT INSERTED.Id VALUES (@Name, @Description, @Url, @Status);";
                var parameters = new { form.Name, form.Description, form.Url, form.Status };
                form.Id = await _context.ExecuteScalarAsync<int>(query, parameters);
                return form;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al crear el formulario: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Actualiza un formulario con LINQ.
        /// </summary>
        public async Task<bool> UpdateAsync(Form form)
        {
            try
            {
                var existingForm = await _context.Set<Form>().FindAsync(form.Id);
                if (existingForm != null)
                {
                    _context.Entry(existingForm).State = EntityState.Detached; // Evita conflictos de seguimiento
                }

                form.Status = existingForm?.Status ?? true; // Mantiene el estado actual

                _context.Set<Form>().Update(form);
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
        /// Actualiza un formulario con SQL.
        /// </summary>
        public async Task<bool> UpdateAsyncSQL(Form form)
        {
            try
            {
                const string query = "UPDATE Form SET Name = @Name, Description = @Description, Url = @Url, Status = @Status WHERE Id = @Id;";
                var parameters = new { form.Id, form.Name, form.Description, form.Url, form.Status };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al actualizar el formulario {form.Id}: {ex.Message}");
                throw;
            }
        }


        /// <summary>
        /// Desactiva un formulario (eliminación lógica) con LINQ.
        /// </summary>
        public async Task<bool> SoftDeleteAsync(int id)
        {
            try
            {
                var form = await _context.Set<Form>().FindAsync(id);
                if (form == null) return false;
                form.Status = false;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al desactivar el formulario {id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Desactiva un formulario (eliminación lógica) con SQL.
        /// </summary>
        public async Task<bool> SoftDeleteAsyncSQL(int id)
        {
            try
            {
                const string query = "UPDATE Form SET Status = 0 WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al desactivar el formulario {id}: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina permanentemente un formulario con LINQ.
        /// </summary>
        public async Task<bool> HardDeleteAsync(int id)
        {
            try
            {
                var form = await _context.Set<Form>().FindAsync(id);
                if (form == null) return false;
                _context.Set<Form>().Remove(form);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el formulario: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Elimina permanentemente un formulario con SQL.
        /// </summary>
        public async Task<bool> HardDeleteAsyncSQL(int id)
        {
            try
            {
                const string query = "DELETE FROM Form WHERE Id = @Id;";
                var parameters = new { Id = id };
                int rowsAffected = await _context.ExecuteAsync(query, parameters);
                return rowsAffected > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error al eliminar el formulario: {ex.Message}");
                return false;
            }
        }
    }
}
