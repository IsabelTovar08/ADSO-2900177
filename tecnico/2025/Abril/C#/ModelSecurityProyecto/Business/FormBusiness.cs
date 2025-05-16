using Data;
using Entity.DTOs;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.SqlServer.Server;
using Utilities.Exceptions;

namespace Business
{
    public class FormBusiness2
    {
        private readonly FormData _FormData;
        private readonly ILogger<FormBusiness2> _logger;

        public FormBusiness2(FormData FormData, ILogger<FormBusiness2> logger)
        {
            _FormData = FormData;
            _logger = logger;
        }

        public async Task<IEnumerable<FormDTO>> GetAllFormsAsync()
        {
            try
            {
                var forms = await _FormData.GetAllAsync();
                var formsDTO = MapToDTOList(forms);

                return formsDTO;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener todos los formularios.");
                throw new ExternalServiceException("Base de datos", "Error al recuperar la lista de formularios", ex);
            }
        }

        public async Task<FormDTO> GetFormByIdAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Se intentó obtener un formulario con ID inválido: {id}");
                throw new Utilities.Exceptions.ValidationException("id", "El id del formulario debe ser mayor que cero.");
            }
            try
            {
                var form = await _FormData.GetByIdAsync(id);
                if (form == null)
                {
                    _logger.LogInformation($"No se encontró ningún formulario con: {id}");
                    throw new EntityNotFoundException("Formulario", id);
                }
                return MapToDTO(form);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al obtener el ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al recuperar el formulario con ID: {id} ", ex);

            }
        }

        public async Task<FormDTO> CreateFormAsync(FormDTO formDTO)
        {
            try
            {
                ValidateForm(formDTO);

                var form = MapToEntity(formDTO);

                var formCreado = await _FormData.CreateAsync(form);

                return MapToDTO(formCreado);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear nuevo form: {formDTO?.Name ?? "null"}");
                throw new ExternalServiceException("Base de datos", "Error al crear el formulario", ex);
            }
        }

        /// <summary>
        /// Actualiza un formulario existente.
        /// </summary>
        public async Task<FormDTO> UpdateFormAsync(FormDTO formDTO)
        {
            if (formDTO.Id <= 0)
            {
                _logger.LogWarning($"Intento de actualizar un formulario con ID inválido: {formDTO.Id}");
                throw new ValidationException("Id", "El ID del formulario debe ser mayor que cero.");
            }

            try
            {
                ValidateForm(formDTO);

                var existingForm = await _FormData.GetByIdAsync(formDTO.Id);
                if (existingForm == null)
                {
                    _logger.LogInformation($"No se encontró ningún formulario con ID: {formDTO.Id}");
                    throw new EntityNotFoundException("Formulario", formDTO.Id);
                }

                var formEntity = MapToEntity(formDTO);

                bool updated = await _FormData.UpdateAsync(formEntity);
                if (!updated)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo actualizar el formulario.");
                }

                return MapToDTO(formEntity);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al actualizar el formulario con ID: {formDTO.Id}");
                throw new ExternalServiceException("Base de datos", $"Error al actualizar el formulario con ID: {formDTO.Id}", ex);
            }
        }

        /// <summary>
        /// Realiza una eliminación lógica de un formulario.
        /// </summary>
        public async Task<bool> SoftDeleteFormAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Intento de eliminación lógica con ID inválido: {id}");
                throw new ValidationException("id", "El ID del formulario debe ser mayor que cero.");
            }

            try
            {
                var existingForm = await _FormData.GetByIdAsync(id);
                if (existingForm == null)
                {
                    _logger.LogInformation($"No se encontró ningún formulario con ID: {id}");
                    throw new EntityNotFoundException("Formulario", id);
                }

                bool deleted = await _FormData.SoftDeleteAsync(id);
                if (!deleted)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo realizar la eliminación lógica del formulario.");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar lógicamente el formulario con ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar lógicamente el formulario con ID: {id}", ex);
            }
        }

        /// <summary>
        /// Realiza una eliminación permanente de un formulario.
        /// </summary>
        public async Task<bool> HardDeleteFormAsync(int id)
        {
            if (id <= 0)
            {
                _logger.LogWarning($"Intento de eliminación permanente con ID inválido: {id}");
                throw new ValidationException("id", "El ID del formulario debe ser mayor que cero.");
            }

            try
            {
                var existingForm = await _FormData.GetByIdAsync(id);
                if (existingForm == null)
                {
                    _logger.LogInformation($"No se encontró ningún formulario con ID: {id}");
                    throw new EntityNotFoundException("Formulario", id);
                }

                bool deleted = await _FormData.HardDeleteAsync(id);
                if (!deleted)
                {
                    throw new ExternalServiceException("Base de datos", "No se pudo eliminar permanentemente el formulario.");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al eliminar permanentemente el formulario con ID: {id}");
                throw new ExternalServiceException("Base de datos", $"Error al eliminar permanentemente el formulario con ID: {id}", ex);
            }
        }


        private void ValidateForm(FormDTO formDTO)
        {
            if (formDTO == null)
            {
                throw new Utilities.Exceptions.ValidationException("El objeto form no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(formDTO.Name))
            {
                _logger.LogWarning("Se intentó crear/actualizar un form con nombre vacío.");
                throw new Utilities.Exceptions.ValidationException("Name", "El nombre del formulario es obligatorio");
            }
        }

        private FormDTO MapToDTO(Form form)
        {
            return new FormDTO
            {
                Id = form.Id,
                Name = form.Name,
                Description = form.Description, // Si existe en la entidad
                Url = form.Url

            };
        }

        // Método para mapear de FormDTO a Form
        private Form MapToEntity(FormDTO formDTO)
        {
            return new Form
            {
                Id = formDTO.Id,
                Name = formDTO.Name,
                Description = formDTO.Description, // Si existe en la entidad
                Url = formDTO.Url
            };
        }

        // Método para mapear una lista de Form a una lista de FormDTO
        private IEnumerable<FormDTO> MapToDTOList(IEnumerable<Form> forms)
        {
            var formsDTO = new List<FormDTO>();
            foreach (var form in forms)
            {
                formsDTO.Add(MapToDTO(form));
            }
            return formsDTO;
        }
    }
}
