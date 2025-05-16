using Data.Interfaces;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Utilities.Exceptions;

namespace Business
{
    /// <summary>
    /// Clase base genérica para lógica de negocio con soporte para mapeo y validación.
    /// </summary>
    public abstract class BusinessBase<T, TDTO> where T : class
    {
        protected readonly ICrud<T> _data;
        protected readonly ILogger<T> _logger;

        protected BusinessBase(ICrud<T> data, ILogger<T> logger)
        {
            _data = data;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los registros.
        /// </summary>
        public virtual async Task<IEnumerable<TDTO>> GetAllAsync()
        {
            try
            {
                var list = await _data.GetAllAsync();
                return MapToDTOList(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los {typeof(T).Name}");
                throw new ExternalServiceException("Base de datos", $"Error al obtener todos los {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Obtiene un registro por ID.
        /// </summary>
        public virtual async Task<TDTO> GetByIdAsync(int id)
        {
            if (id <= 0)
                throw new ValidationException("id", "El ID debe ser mayor que cero");

            try
            {
                var entity = await _data.GetByIdAsync(id);
                if (entity == null)
                    throw new EntityNotFoundException(typeof(T).Name, id);

                return MapToDTO(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener {typeof(T).Name} con ID {id}");
                throw new ExternalServiceException("Base de datos", $"Error al obtener {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Crea un nuevo registro.
        /// </summary>
        public virtual async Task<TDTO> CreateAsync(TDTO dto)
        {
            try
            {
                Validate(dto);
                var entity = MapToEntity(dto);
                var created = await _data.CreateAsync(entity);
                return MapToDTO(created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear {typeof(T).Name}");
                throw new ExternalServiceException("Base de datos", $"Error al crear {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Actualiza un registro existente.
        /// </summary>
        public virtual async Task<TDTO> UpdateAsync(TDTO dto)
        {
            if (dto == null)
                throw new ValidationException("Entidad", $"{typeof(T).Name} no puede ser nulo");

            try
            {
                Validate(dto);

                var idProp = typeof(TDTO).GetProperty("Id")?.GetValue(dto);
                if (idProp == null || (int)idProp <= 0)
                    throw new ValidationException("Id", "El ID debe ser mayor que cero");

                var entity = MapToEntity(dto);
                var updated = await _data.UpdateAsync(entity);

                if (!updated)
                    throw new ExternalServiceException("Base de datos", $"No se pudo actualizar {typeof(T).Name}");

                return dto;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar {typeof(T).Name}");
                throw new ExternalServiceException("Base de datos", $"Error al actualizar {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Elimina un registro por ID.
        /// </summary>
        public virtual async Task<bool> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ValidationException("id", "El ID debe ser mayor que cero");

            try
            {
                var deleted = await _data.DeleteAsync(id);
                if (!deleted)
                    throw new ExternalServiceException("Base de datos", $"No se pudo eliminar {typeof(T).Name}");

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar {typeof(T).Name} con ID {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar {typeof(T).Name} con ID {id}", ex);
            }
        }

        // 🔐 Métodos que deben ser implementados por cada clase hija:

        /// <summary>
        /// Valida el DTO antes de guardar o actualizar.
        /// </summary>
        protected abstract void Validate(TDTO dto);

        /// <summary>
        /// Convierte de entidad a DTO.
        /// </summary>
        protected abstract TDTO MapToDTO(T entity);

        /// <summary>
        /// Convierte de DTO a entidad.
        /// </summary>
        protected abstract T MapToEntity(TDTO dto);

        /// <summary>
        /// Convierte una lista de entidades a una lista de DTOs.
        /// </summary>
        protected virtual IEnumerable<TDTO> MapToDTOList(IEnumerable<T> entities)
        {
            return entities.Select(MapToDTO).ToList();
        }
    }
}
