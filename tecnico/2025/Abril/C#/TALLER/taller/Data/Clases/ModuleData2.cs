using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.Extensions.Logging;

namespace Data.Clases
{
    public class ModuleData2 : ICrud<Module>
    {
        protected readonly ApplicationDbContext _context;

        private readonly ILogger<ModuleData2> _logger;

        // Constructor
        public ModuleData2(ApplicationDbContext context, ILogger<ModuleData2> logger)
        {
            _context = context;
            _logger = logger;
        }

        // Método para obtener todas las entidades de tipo Module
        public async Task<IEnumerable<Module>> GetAllAsync()
        {
            try
            {
                string query = "SELECT * FROM Models WHERE Status = 1";  // Ajusta la consulta aquí según sea necesario
                return await _context.QueryAsync<Module>(query);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todas las entidades de tipo Module");
                throw;
            }
        }

        // Método para obtener una entidad por su identificador
        public async Task<Module?> GetByIdAsync(int id)
        {
            try
            {
                string query = "SELECT * FROM Models WHERE Id = @Id AND Status = 1";
                return await _context.QueryFirstOrDefaultAsync<Module>(query, new { Id = id });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener entidad de tipo Module con ID {id}");
                throw;
            }
        }

        // Método para crear una nueva entidad de tipo Module
        public async Task<Module> CreateAsync(Module entity)
        {
            try
            {
                string query = "INSERT INTO Models (Name, Description, Status) VALUES (@Name, @Description, 1)";
                await _context.ExecuteAsync(query, entity);
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al crear entidad de tipo Module");
                throw;
            }
        }

        // Método para actualizar una entidad existente de tipo Module
        public async Task<bool> UpdateAsync(Module entity)
        {
            try
            {
                string query = "UPDATE Models SET Name = @Name, Description = @Description, Status = 1 WHERE Id = @Id AND Status = 1";
                var affectedRows = await _context.ExecuteAsync(query, entity);
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al actualizar entidad de tipo Module");
                throw;
            }
        }

        // Método para eliminar una entidad de tipo Module
        public async Task<bool> DeleteAsync(int id)
        {
            try
            {
                string query = "DELETE FROM Models WHERE Id = @Id";
                var affectedRows = await _context.ExecuteAsync(query, new { Id = id });
                return affectedRows > 0;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar entidad de tipo Module con ID {id}");
                throw;
            }
        }
    }
}
