using AutoMapper;
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
        public FormBusiness(FormData data, ILogger<Form> logger, IMapper mapper)
             : base(data, logger, mapper)
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
    }
}
