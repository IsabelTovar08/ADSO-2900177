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
    public class FormModuleBusiness
    {
        private readonly FormModuleData _FormModuleData;
        private readonly ILogger<FormModule> _logger;
        public FormModuleBusiness(FormModuleData formModuleData, ILogger<FormModule> logger)
        {
            _FormModuleData = formModuleData;
            _logger = logger;
        }

        public async Task<IEnumerable<FormModuleDTO>> GetAllFormsModuleAsync()
        {
            try
            {
                var formsmodule = await _FormModuleData.GetAllAsync();
                return MapToDTOList(formsmodule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los formularios del módulo.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de formularios por módulo", ex);
            }
        }

        public async Task<FormModuleDTO> GetFormModuleByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Se intentó obtener un formulario módulo con ID inválido: {id}");
                throw new Utilities.Exceptions.ValidationException("id", "El id del formulario modulo debe ser mayor que cero.");
            }
            try
            {
                var formModule = await _FormModuleData.GetByIdAsync(id);
                if (formModule == null)
                {
                    _logger.LogInformation($"No se encontró ningún formulario módulo con: {id}");
                    throw new EntityNotFoundException("Formulario módulo", id);
                }
                return MapToDTO(formModule);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el formulario módulo con ID: {id} ", ex);

            }
        }

        public async Task<FormModuleDTO> CreateFormAsync(FormModuleCreateDTO formModuleDTO)
        {
            try
            {
                ValidateForm(formModuleDTO);

                var form = MapToEntity(formModuleDTO);

                var formCreado = await _FormModuleData.CreateAsync(form);

                return MapToDTO(formCreado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear nuevo form module ");
                throw new ExternalServiceException("Base de datos", "Error al crear el formulario módulo", ex);
            }
        }


        public async Task<FormModuleDTO> UpdateFormModuleAsync(FormModuleCreateDTO formModuleDTO)
        {
            if (formModuleDTO.Id <= 0)
            {
                _logger.LogWarning($"Intento de actualizar un form module con ID inválido: {formModuleDTO.Id}");
                throw new ValidationException("Id", "El ID del form module debe ser mayor que cero.");
            }

            try
            {
                ValidateForm(formModuleDTO);

                var existingUser = await _FormModuleData.GetByIdAsync(formModuleDTO.Id);
                if (existingUser == null)
                {
                    _logger.LogInformation($"No se encontró ningún form module con ID: {formModuleDTO.Id}");
                    throw new EntityNotFoundException("Rol", formModuleDTO.Id);
                }

                var usereEntity = MapToEntity(formModuleDTO);

                bool updated = await _FormModuleData.UpdateAsync(usereEntity);
                if (!updated)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo actualizar el form module.");
                }

                return MapToDTO(usereEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el user con ID: {formModuleDTO.Id}");
                throw new ExternalServiceException("Base de datos", $"Error al actualizar el uform module con ID: {formModuleDTO.Id}", ex);
            }
        }
        public async Task<bool> SoftDeleteFormModuleAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Id", "El ID del formulario módulo debe ser mayor que cero.");
            }

            var existingFormModule = await _FormModuleData.GetByIdAsync(id);
            if (existingFormModule == null)
            {
                throw new EntityNotFoundException("Formulario módulo", id);
            }

            var deleted = await _FormModuleData.HardDeleteAsync(id);
            if (!deleted)
            {
                throw new ExternalServiceException("Base de datos", "No se pudo eliminar el formulario módulo.");
            }

            return true;
        }

        public async Task<bool> HardDeleteFormModuleAsync(int id)
        {
            if (id <= 0)
            {
                throw new ValidationException("Id", "El ID del formulario módulo debe ser mayor que cero.");
            }

            var existingFormModule = await _FormModuleData.GetByIdAsync(id);
            if (existingFormModule == null)
            {
                throw new EntityNotFoundException("Formulario módulo", id);
            }

            var deleted = await _FormModuleData.HardDeleteAsync(id);
            if (!deleted)
            {
                throw new ExternalServiceException("Base de datos", "No se pudo eliminar permanentemente el formulario módulo.");
            }

            return true;
        }

        private void ValidateForm(FormModuleDTO formModuleDTO)
        {
            if (formModuleDTO == null)
            {
                throw new Utilities.Exceptions.ValidationException("El objeto form module no puede ser nulo.");
            }

            //if (string.IsNullOrWhiteSpace(formModuleDTO.Name))
            //{
            //    _logger.LogWarning("Se intentó crear/actualizar un form con nombre vacío.");
            //    throw new Utilities.Exceptions.ValidationException("Name", "El nombre del formulario es onbigatorio");
            //}
        }

        private void ValidateForm(FormModuleCreateDTO formModuleDTO)
        {
            if (formModuleDTO == null)
            {
                throw new Utilities.Exceptions.ValidationException("El objeto form module no puede ser nulo.");
            }
        }

        private FormModuleDTO MapToDTO(FormModule formModule)
        {
            return new FormModuleDTO
            {
                Id = formModule.Id,
                FormId = formModule.FormId,
                FormName = formModule.Form?.Name ?? "",
                ModuleId = formModule.ModuleId,
                ModuleName = formModule.Module?.Name ?? ""

            };
        }

        // Método para mapear de FormModuleDTO a Form
        private FormModule MapToEntity(FormModuleDTO formModuleDTO)
        {
            return new FormModule
            {
                Id = formModuleDTO.Id,
                FormId = formModuleDTO.FormId,
                ModuleId = formModuleDTO.ModuleId,
                
                
            };
        }


        private FormModule MapToEntity(FormModuleCreateDTO formModuleDTO)
        {
            return new FormModule
            {
                Id = formModuleDTO.Id,
                FormId = formModuleDTO.FormId,
                ModuleId = formModuleDTO.ModuleId,
            };
        }
        // Método para mapear una lista de Form a una lista de FormModuleDTO
        private IEnumerable<FormModuleDTO> MapToDTOList(IEnumerable<FormModule> formsModule)
        {
            var formsModuleDTO = new List<FormModuleDTO>();
            foreach (var formModule in formsModule)
            {
                formsModuleDTO.Add(MapToDTO(formModule));
            }
            return formsModuleDTO;
        }
    }
}
