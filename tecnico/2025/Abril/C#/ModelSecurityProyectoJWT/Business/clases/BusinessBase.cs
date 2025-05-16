using AutoMapper;
using Data.Clases;
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
        protected readonly CrudBase<T> _data;
        protected readonly ILogger<T> _logger;
        protected readonly IMapper _mapper;

        protected BusinessBase(CrudBase<T> data, ILogger<T> logger, IMapper mapper)
        {
            _data = data;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los registros.
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

                return _mapper.Map<TDTO>(entity);
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
                var entity = _mapper.Map<T>(dto);
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

                var entity = _mapper.Map<T>(dto);
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

        /// <summary>
        /// Método abstracto que debe implementar la validación de cada entidad específica.
        /// </summary>
        protected abstract void Validate(TDTO entity);

    }
}
