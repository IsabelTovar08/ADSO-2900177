using Data;
using Entity.DTOs;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;
using static Dapper.SqlMapper;

namespace Business
{
    /// <summary>
    /// Lógica de negocio para la entidad Form.
    /// </summary>
    public class FormBusiness : BusinessBase<Form, FormDTO>
    {
        public FormBusiness(FormData2 data, ILogger<Form> logger)
             : base(data, logger)
        {
        }

        /// <summary>
        /// Valida un formulario antes de crearlo o actualizarlo.
        /// </summary>
        protected override void Validate(FormDTO dto)
        {
            if (dto == null)
                throw new ValidationException("Form", "El formulario no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ValidationException("Name", "El título del formulario es obligatorio.");

            // Agrega más validaciones si necesitas
        }

        /// <summary>
        /// Mapea un formulario desde la entidad a su DTO.
        /// </summary>
        protected override FormDTO MapToDTO(Form entity)
        {
            return new FormDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Url = entity.Url
        
                // Agrega otros campos si tu DTO lo requiere
            };
        }

        /// <summary>
        /// Mapea un DTO de formulario a su entidad.
        /// </summary>
        protected override Form MapToEntity(FormDTO dto)
        {
            return new Form
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description,
                Url = dto.Url

                // Agrega otros campos si es necesario
            };
        }
    }
}
