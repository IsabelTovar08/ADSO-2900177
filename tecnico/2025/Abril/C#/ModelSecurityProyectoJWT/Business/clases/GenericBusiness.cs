using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Clases;
using Entity.DTOs;
using Microsoft.Extensions.Logging;
using AutoMapper;
using Utilities.Exceptions;

namespace Business.clases
{
    /// <summary>
    /// Lógica de negocio genérica con soporte para operaciones CRUD, incluyendo borrado lógico y reactivación.
    /// </summary>
    /// <typeparam name="T">Entidad de base de datos.</typeparam>
    /// <typeparam name="TDTO">DTO asociado a la entidad.</typeparam>
    public abstract class GenericBusiness<T, TDTO> where T : class
    {
        protected readonly CrudBase<T> _data;
        protected readonly ILogger<T> _logger;
        protected readonly IMapper _mapper;

        public GenericBusiness(CrudBase<T> data, ILogger<T> logger, IMapper mapper)
        {
            _data = data;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los registros activos.
        /// </summary>
        public virtual async Task<IEnumerable<TDTO>> GetAllAsync()
        {
            try
            {
                var list = await _data.GetAllAsync();
                return _mapper.Map<IEnumerable<TDTO>>(list);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener todos los {typeof(T).Name}");
                throw new ExternalServiceException("Base de datos", $"Error al obtener todos los {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Obtiene una entidad por ID solo si está activa.
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

                return _mapper.Map<TDTO>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener {typeof(T).Name} con ID {id}");
                throw new ExternalServiceException("Base de datos", $"Error al obtener {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Crea una nueva entidad.
        /// </summary>
        public virtual async Task<TDTO> CreateAsync(TDTO entityTDTO)
        {
            try
            {
                Validate(entityTDTO);
                var entity = _mapper.Map<T>(entityTDTO);
                var created = await _data.CreateAsync(entity);
                return _mapper.Map<TDTO>(created);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear {typeof(T).Name}");
                throw new ExternalServiceException("Base de datos", $"Error al crear {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Actualiza una entidad existente.
        /// </summary>
        public virtual async Task<object> UpdateAsync(TDTO dto)
        {
            if (dto == null)
                throw new ValidationException("Entidad", $"{typeof(T).Name} no puede ser nulo");

            try
            {
                Validate(dto);

                var idProp = typeof(TDTO).GetProperty("Id")?.GetValue(dto);
                if (idProp == null || (int)idProp <= 0)
                    throw new ValidationException("Id", "El ID debe ser mayor que cero");

                var entity = _mapper.Map<T>(dto);
                var updated = await _data.UpdateAsync(entity);

                if (!updated)
                    throw new ExternalServiceException("Base de datos", $"No se pudo actualizar {typeof(T).Name}");

                return new { rowAfects = updated };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar {typeof(T).Name}");
                throw new ExternalServiceException("Base de datos", $"Error al actualizar {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Elimina una entidad de forma permanente.
        /// </summary>
        public virtual async Task<object> DeleteAsync(int id)
        {
            if (id <= 0)
                throw new ValidationException("id", "El ID debe ser mayor que cero");

            try
            {
                var deleted = await _data.DeleteAsync(id);
                if (deleted == null)
                    throw new ExternalServiceException("Base de datos", $"No se pudo eliminar {typeof(T).Name}");

                return deleted;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar {typeof(T).Name} con ID {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar {typeof(T).Name} con ID {id}", ex);
            }
        }

        /// Alterna el estado lógico de una entidad (activa/desactiva).
        /// Si está activa, la desactiva; si está desactivada, la reactiva.
        /// </summary>
        public virtual async Task<bool> ToggleActiveStateAsync(int id)
        {
            if (id <= 0)
                throw new ValidationException("id", "El ID debe ser mayor que cero");

            try
            {
                var result = await _data.ToggleActiveStateAsync(id);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el estado lógico de {typeof(T).Name} con ID {id}");
                throw new ExternalServiceException("Base de datos", "Error al actualizar el estado lógico", ex);
            }
        }


        /// <summary>
        /// Método abstracto que debe implementar la validación de cada entidad específica.
        /// </summary>
        protected abstract void Validate(TDTO entity);
    }
}
