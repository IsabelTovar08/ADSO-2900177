using Data;
using Entity.DTOs;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Utilities.Exceptions;

namespace Business
{
    public class FormBusiness
    {
        private readonly FormData _FormData;
        private readonly ILogger _logger;

        public FormBusiness(FormData FormData, ILogger logger)
        {
            _FormData = FormData;
            _logger = logger;
        }

        public async Task<IEnumerable<FormDTO>> GetAllFormsAsync()
        {
            try
            {
                var forms = await _FormData.GetAllAsync();
                var formsDTO = new List<FormDTO>();

                foreach (var form in forms)
                {
                    formsDTO.Add(new FormDTO
                    {
                        Id = form.Id,
                        Name = form.Name,
                        Description = form.Description
                    });
                }

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
                return new FormDTO
                {
                    Id = form.Id,
                    Name = form.Name,
                    Description = form.Description
                };
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

                var form = new Form
                {
                    Name = formDTO.Name,
                    Description = formDTO.Description
                };

                var formCreado = await _FormData.CreateAsync(form);

                return new FormDTO
                {
                    Id = form.Id,
                    Name = form.Name,
                    Description = form.Description
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error al crear nuevo form: {formDTO?.Name ?? "null"}");
                throw new ExternalServiceException("Base de datos", "Error al crear el formulario", ex);
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
                throw new Utilities.Exceptions.ValidationException("Name", "El nombre del formulario es onbigatorio");
            }
        }

        private FormDTO MapToDTO(Form form)
        {
            return new FormDTO
            {
                Id = form.Id,
                Name = form.Name,
                Description = form.Description // Si existe en la entidad
            };
        }

        // Método para mapear de FormDTO a Form
        private Form MapToEntity(FormDTO formDTO)
        {
            return new Form
            {
                Id = formDTO.Id,
                Name = formDTO.Name,
                Description = formDTO.Description // Si existe en la entidad
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
