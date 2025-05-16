using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Entity.DTOs;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business
{
    public class ModuleBusiness
    {
        private readonly ModuleData _ModuleData;
        private readonly ILogger<ModuleData> _logger;

        public ModuleBusiness(ModuleData ModuleData, ILogger<ModuleData> logger)
        {
            _ModuleData = ModuleData;
            _logger = logger;
        }

        public async Task<IEnumerable<ModuleDTO>> GetAllModulesAsync()
        {
            try
            {
                var modules = await _ModuleData.GetAllAsync();
                var modulesDTO = MapToDTOList(modules);

                return modulesDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los modulos.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de modulos", ex);
            }
        }

        public async Task<ModuleDTO> GetModuleByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Se intentó obtener un modulo con ID inválido: {id}");
                throw new Utilities.Exceptions.ValidationException("id", "El id del modulo debe ser mayor que cero.");
            }
            try
            {
                var module = await _ModuleData.GetByIdAsync(id);
                if (module == null)
                {
                    _logger.LogInformation($"No se encontró ningún modulo con: {id}");
                    throw new EntityNotFoundException("Moduleulario", id);
                }
                return MapToDTO(module);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el modulo con ID: {id} ", ex);

            }
        }

        public async Task<ModuleDTO> CreateModuleAsync(ModuleDTO moduleDTO)
        {
            try
            {
                ValidateModule(moduleDTO);

                var module = MapToEntity(moduleDTO);

                var moduleCreado = await _ModuleData.CreateAsync(module);

                return MapToDTO(moduleCreado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear nuevo module: {moduleDTO?.Name ?? "null"}");
                throw new ExternalServiceException("Base de datos", "Error al crear el modulo", ex);
            }
        }

        /// <summary>
        /// Actualiza un module existente.
        /// </summary>
        public async Task<ModuleDTO> UpdateModuleAsync(ModuleDTO moduleDTO)
        {

            if (moduleDTO.Id <= 0)
            {
                _logger.LogWarning($"Intento de actualizar un module con ID inválido: {moduleDTO.Id}");
                throw new ValidationException("Id", "El ID del module debe ser mayor que cero.");
            }

            try
            {
                ValidateModule(moduleDTO);

                var existingModule = await _ModuleData.GetByIdAsync(moduleDTO.Id);
                if (existingModule == null)
                {
                    _logger.LogInformation($"No se encontró ningún module con ID: {moduleDTO.Id}");
                    throw new EntityNotFoundException("Módulo", moduleDTO.Id);
                }

                var moduleeEntity = MapToEntity(moduleDTO);

                bool updated = await _ModuleData.UpdateAsync(moduleeEntity);
                if (!updated)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo actualizar el module.");
                }

                return MapToDTO(moduleeEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el module con ID: {moduleDTO.Id}");
                throw new ExternalServiceException("Base de datos", $"Error al actualizar el module con ID: {moduleDTO.Id}", ex);
            }
        }

        /// <summary>
        /// Realiza una eliminación lógica de un module.
        /// </summary>
        public async Task<bool> SoftDeleteModuleAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Intento de eliminación lógica con ID inválido: {id}");
                throw new ValidationException("id", "El ID del module debe ser mayor que cero.");
            }

            try
            {
                var existingModule = await _ModuleData.GetByIdAsync(id);
                if (existingModule == null)
                {
                    _logger.LogInformation($"No se encontró ningún module con ID: {id}");
                    throw new EntityNotFoundException("Rol", id);
                }

                bool deleted = await _ModuleData.SoftDeleteAsync(id);
                if (!deleted)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo realizar la eliminación lógica del module.");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar lógicamente el module con ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar lógicamente el module con ID: {id}", ex);
            }
        }

        /// <summary>
        /// Realiza una eliminación permanente de un module.
        /// </summary>
        public async Task<bool> HardDeleteModuleAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Intento de eliminación permanente con ID inválido: {id}");
                throw new ValidationException("id", "El ID del module debe ser mayor que cero.");
            }

            try
            {
                var existingModule = await _ModuleData.GetByIdAsync(id);
                if (existingModule == null)
                {
                    _logger.LogInformation($"No se encontró ningún module con ID: {id}");
                    throw new EntityNotFoundException("Rol", id);
                }

                bool deleted = await _ModuleData.HardDeleteAsync(id);
                if (!deleted)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo eliminar permanentemente el module.");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar permanentemente el module con ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar permanentemente el module con ID: {id}", ex);
            }
        }

        private void ValidateModule(ModuleDTO moduleDTO)
        {
            if (moduleDTO == null)
            {
                throw new Utilities.Exceptions.ValidationException("El objeto module no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(moduleDTO.Name))
            {
                _logger.LogWarning("Se intentó crear/actualizar un module con nombre vacío.");
                throw new Utilities.Exceptions.ValidationException("Name", "El nombre del modulo es onbigatorio");
            }
        }



        private ModuleDTO MapToDTO(Module module)
        {
            return new ModuleDTO
            {
                Id = module.Id,
                Name = module.Name,
                Description = module.Description // Si existe en la entidad
            };
        }

        // Método para mapear de ModuleDTO a Module
        private Module MapToEntity(ModuleDTO moduleDTO)
        {
            return new Module
            {
                Id = moduleDTO.Id,
                Name = moduleDTO.Name,
                Description = moduleDTO.Description // Si existe en la entidad
            };
        }

        // Método para mapear una lista de Module a una lista de ModuleDTO
        private IEnumerable<ModuleDTO> MapToDTOList(IEnumerable<Module> modules)
        {
            var modulesDTO = new List<ModuleDTO>();
            foreach (var module in modules)
            {
                modulesDTO.Add(MapToDTO(module));
            }
            return modulesDTO;
        }
    }
}
