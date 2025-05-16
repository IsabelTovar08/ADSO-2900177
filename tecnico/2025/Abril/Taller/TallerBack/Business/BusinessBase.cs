using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Strategy.Implements;
using Business.Strategy;
using Data.Interfases;
using Microsoft.Extensions.Logging;
using Utilities.Exeptions;

namespace Business
{
    public abstract class BusinessBase<T, TDTO, TDTOCreate> where T : class
    {
        protected readonly ICrudBase<T> _data;
        protected readonly ILogger<T> _logger;
        protected readonly IMapper _mapper;
        public BusinessBase(ICrudBase<T> data, ILogger<T> logger, IMapper mapper)
        {
            _data = data;
            _logger = logger;
            _mapper = mapper;
        }

        /// <summary>
        /// Obtiene todos los registros activos.
        /// </summary>
        /// 
        public virtual async Task<IEnumerable<TDTO>> GetAllActiveAsync()
        {
            try
            {
                var list = await _data.GetAllActiveAsync();
                return _mapper.Map<IEnumerable<TDTO>>(list);
            }
            catch (Exception ex) 
            {
                _logger.LogError(ex, $"Error al obtener todos los {typeof(T).Name}");
                throw new ExternalServiceException("Base de datos", $"Error al obtener todos los {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Obtiene todos los registros.
        /// </summary>
        /// 
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
        public virtual async Task<TDTO> GetByIdActiveAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Id", "El Id debe ser mayor que cero.");
            }
            try
            {
                var entity = await _data.GetByIdActiveAsync(id);
                if (entity == null)
                    throw new EntityNotFoundException(typeof(T).Name, id);
                return _mapper.Map<TDTO>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener {typeof(T).Name} con Id: {id}");
                throw new ExternalServiceException("Base de Datos", $"Error al obtener {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Obtiene una entidad por ID.
        /// </summary>
        public virtual async Task<TDTO> GetByIdAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Id", "El Id debe ser mayor que cero.");
            }
            try
            {
                var entity = await _data.GetByIdAsync(id);
                if (entity == null)
                    throw new EntityNotFoundException(typeof(T).Name, id);
                return _mapper.Map<TDTO>(entity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener {typeof(T).Name} con Id: {id}");
                throw new ExternalServiceException("Base de Datos", $"Error al obtener {typeof(T).Name}", ex);
            }
        }

        /// <summary>
        /// Crea una nueva entidad.
        /// </summary>
        public virtual async Task<TDTO> CreateAsync(TDTOCreate entityDTO)
        {
            try
            {
                Validate(entityDTO);
                var entity = _mapper.Map<T>(entityDTO);
                var created = await _data.CreateAsync(entity);

                return _mapper.Map<TDTO>(created);
            }
            catch (ValidationException) 
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear {typeof(T).Name}");
                throw new ExternalServiceException("Base de datos", $"Error al craer {typeof(T).Name}");
            }
        }

        /// <summary>
        /// Actualiza una nueva entidad.
        /// </summary>
        public virtual async Task<bool> UpdateAsync(TDTOCreate entityDTO)
        {
            try
            {
                var entity = _mapper.Map<T>(entityDTO);
                var success = await _data.UpdateAsync(entity);

                if (!success)
                    throw new EntityNotFoundException($"{typeof(T).Name} no encontrado");

                return true;
            }
            catch (ValidationException)
            {
                throw;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar {typeof(T).Name}");
                throw new ExternalServiceException("Base de datos", $"Error al actualizar {typeof(T).Name}");
            }
        }


        /// <summary>
        /// Eliminar permanentemente una entidad.
        /// </summary>
        public virtual async Task<bool> DeleteAsync(int id)
        {
            if(id <= 0)
                throw new ValidationException("id", "El id debe ser mayor que cero.");
            try
            {
                var deleted = await _data.DeleteAsync(id);
                if (deleted == null)
                {
                    throw new ExternalServiceException("Base de datos", $"No se pudo eliminar {typeof(T).Name}");
                }
                return deleted;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar {typeof(T).Name} con Id: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar {typeof(T).Name} con ID: {id}");
            }
        }


        /// <summary>
        /// Gestionar el eliminado lógico en una entidad.
        /// </summary>
        public virtual async Task<bool> ToggleSOftDeleteAsync(int id)
        {
            if (id <= 0)
                throw new ValidationException("id", "El id debe ser mayor que cero.");
            try
            {
                var deleted = await _data.ToggleActiveAsync(id);
                if (deleted == null)
                {
                    throw new ExternalServiceException("Base de datos", $"No se pudo actualizar el estado lógico {typeof(T).Name}");
                }
                return deleted;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el estado lógico {typeof(T).Name} con Id: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al actualizar el estado lógico {typeof(T).Name} con ID: {id}");
            }
        }


        public async Task DeleteAsyncStrategy(int id, DeleteStrategyType strategyType)
        {
            //var strategy = _factory.GetStrategy(strategyType);
            await SelectorFactoryStrategy.Execute(strategyType, _data, id);

        }

        /// <summary>
        /// Método abstracto que debe implementar la validación de cada entidad específica.
        /// </summary>
        protected abstract void Validate(TDTOCreate entity);
    }
}
