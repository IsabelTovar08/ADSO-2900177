using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Interfaces;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Clases
{
    /// <summary>
    /// Clase base genérica para operaciones CRUD utilizando Entity Framework Core.
    /// </summary>
    /// <typeparam name="T">Entidad a la que se aplicarán las operaciones CRUD.</typeparam>
    public class CrudBase<T> : ICrud<T>, ISoftDelete<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly ILogger<T> _logger;

        /// <summary>
        /// Constructor de la clase CrudBase.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        /// <param name="logger">Logger para el registro de errores y eventos.</param>
        public CrudBase(ApplicationDbContext context, ILogger<T> logger)
        {
            _context = context;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todas las entidades del tipo especificado.
        /// </summary>
        /// <returns>Una colección de todas las entidades encontradas.</returns>
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _context.Set<T>().ToListAsync();

            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todas las entidades de tipo {typeof(T).Name}");
                throw;
            }
        }

        /// <summary>
        /// Obtiene una entidad por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        /// <returns>La entidad encontrada o null si no existe.</returns>
        public virtual async Task<T?> GetByIdAsync(int id)
        {
            try
            {
                return await _context.Set<T>().FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener entidad de tipo {typeof(T).Name} con ID {id}");
                throw;
            }
        }

        /// <summary>
        /// Crea una nueva entidad en la base de datos.
        /// </summary>
        /// <param name="entity">Entidad a crear.</param>
        /// <returns>La entidad creada.</returns>
        public virtual async Task<T> CreateAsync(T entity)
        {
            try
            {
                await _context.Set<T>().AddAsync(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear entidad de tipo {typeof(T).Name}");
                throw;
            }
        }

        /// <summary>
        /// Actualiza una entidad existente.
        /// </summary>
        /// <param name="entity">Entidad con los nuevos valores.</param>
        /// <returns>True si la actualización fue exitosa; false si no se encontró la entidad.</returns>
        public virtual async Task<bool> UpdateAsync(T entity)
        {
            try
            {
                var id = entity.GetType().GetProperty("Id")?.GetValue(entity);
                var existing = await _context.Set<T>().FindAsync(id);

                if (existing == null)
                    return false;

                // Verifica que no esté eliminada lógicamente
                var isDeletedProp = typeof(T).GetProperty("IsDeleted");
                if (isDeletedProp != null && isDeletedProp.PropertyType == typeof(bool))
                {
                    var isDeletedValue = (bool)isDeletedProp.GetValue(existing)!;
                    if (isDeletedValue)
                        return false;
                }

                _context.Entry(existing).CurrentValues.SetValues(entity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar entidad de tipo {typeof(T).Name}");
                throw;
            }
        }

        /// <summary>
        /// Elimina una entidad por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la entidad a eliminar.</param>
        /// <returns>True si la eliminación fue exitosa; false si no se encontró la entidad.</returns>
        public virtual async Task<bool> DeleteAsync(int id)
        {
            try
            {
                var t = await _context.Set<T>().FindAsync(id);
                if (t == null) return false;

                _context.Set<T>().Remove(t);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar entidad de tipo {typeof(T).Name} con ID {id}");
                throw;
            }
        }

        /// <summary>
        /// Realiza una eliminación lógica de la entidad por su identificador.
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        /// <returns>True si la eliminación lógica fue exitosa; false si no se encontró o no se pudo eliminar.</returns>
        public virtual async Task<bool> SoftDeleteAsync(int id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                if (entity == null)
                    return false;

                var prop = typeof(T).GetProperty("IsDeleted");
                if (prop == null || !prop.CanWrite || prop.PropertyType != typeof(bool))
                    throw new InvalidOperationException($"La entidad {typeof(T).Name} no tiene una propiedad IsDeleted válida.");

                prop.SetValue(entity, true);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al realizar eliminación lógica de entidad de tipo {typeof(T).Name} con ID {id}");
                throw;
            }
        }
    }
}
