using Data.interfaces;
using Data.interfaces.crud;
using Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Data.repositories.Global
{
    /// <summary>
    /// Clase genérica para operaciones CRUD usando LINQ con soporte para borrado lógico mediante la propiedad Status.
    /// </summary>
    /// <typeparam name="T">Entidad que implementa IActivable.</typeparam>
    public class GenericData<T> : CrudBase<T>, ISoftDelete where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly ILogger<T> _logger;

        /// <summary>
        /// Constructor de la clase GenericData.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        /// <param name="logger">Logger para el registro de errores y eventos.</param>
        public GenericData(ApplicationDbContext context, ILogger<T> logger)
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

        public virtual async Task<IEnumerable<T>> GetAllActiveAsync()
        {
            try
            {
                var property = typeof(T).GetProperty("Status");
                if (property == null || property.PropertyType != typeof(bool))
                    throw new InvalidOperationException("La entidad no tiene la propiedad 'Status' de tipo booleano.");

                return await _context.Set<T>()
                    .Where(e => EF.Property<bool>(e, "Status") == true)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener entidades activas de tipo {typeof(T).Name}");
                throw;
            }
        }

        public virtual async Task<T?> GetByIdActiveAsync(int id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                if (entity == null) return null;

                var statusProp = typeof(T).GetProperty("Status");
                if (statusProp == null || statusProp.PropertyType != typeof(bool))
                    throw new InvalidOperationException("La entidad no tiene la propiedad 'Status' de tipo booleano.");

                bool isActive = (bool)statusProp.GetValue(entity)!;
                return isActive ? entity : null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener entidad activa de tipo {typeof(T).Name} con ID {id}");
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
                var StatusProp = typeof(T).GetProperty("Status");
                if (StatusProp != null && StatusProp.PropertyType == typeof(bool))
                {
                    var StatusValue = (bool)StatusProp.GetValue(existing)!;
                    if (StatusValue)
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
        public virtual async Task<bool> DeletePersistent(int id)
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
        /// Alterna el estado de eliminación lógica (Status) de una entidad.
        /// Si está activa, la desactiva; si está desactivada, la reactiva.
        /// </summary>
        /// <param name="id">Identificador de la entidad.</param>
        /// <returns>True si se modificó el estado correctamente; false si no se encontró.</returns>
        public virtual async Task<bool> ToggleActiveStateAsync(int id)
        {
            try
            {
                var entity = await _context.Set<T>().FindAsync(id);
                if (entity == null)
                    return false;

                var prop = typeof(T).GetProperty("Status");
                if (prop == null || !prop.CanWrite || prop.PropertyType != typeof(bool))
                    throw new InvalidOperationException($"La entidad {typeof(T).Name} no tiene una propiedad Status válida.");

                var currentValue = (bool)prop.GetValue(entity)!;
                prop.SetValue(entity, !currentValue); // Invertimos el estado

                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al alternar estado Status de entidad de tipo {typeof(T).Name} con ID {id}");
                throw;
            }
        }

    }
}
