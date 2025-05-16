using AutoMapper;
using Data;
using Data.Clases;
using Entity.DTOs;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exceptions;

namespace Business
{
    /// <summary>
    /// Lógica de negocio para la entidad Module.
    /// </summary>
    public class ModuleBusiness : BusinessBase<Module, ModuleDTO>
    {
        public ModuleBusiness(ModuleData data, ILogger<Module> logger, IMapper mapper)
             : base(data, logger, mapper)
        {
        }

        /// <summary>
        /// Valida un módulo antes de crearlo o actualizarlo.
        /// </summary>
        protected override void Validate(ModuleDTO dto)
        {
            if (dto == null)
                throw new ValidationException("Module", "El módulo no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(dto.Name))
                throw new ValidationException("Name", "El nombre del módulo es obligatorio.");

            if (string.IsNullOrWhiteSpace(dto.Description))
                throw new ValidationException("Description", "La descripción del módulo es obligatoria.");

            // Agrega más validaciones si necesitas
        }

        
    }
}
