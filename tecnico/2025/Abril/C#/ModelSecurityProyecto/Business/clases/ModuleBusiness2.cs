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
    public class ModuleBusiness2 : BusinessBase<Module, ModuleDTO>
    {
        public ModuleBusiness2(ModuleData2 data, ILogger<Module> logger)
             : base(data, logger)
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

        /// <summary>
        /// Mapea un módulo desde la entidad a su DTO.
        /// </summary>
        protected override ModuleDTO MapToDTO(Module entity)
        {
            return new ModuleDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description
                // Agrega otros campos si tu DTO lo requiere
            };
        }

        /// <summary>
        /// Mapea un DTO de módulo a su entidad.
        /// </summary>
        protected override Module MapToEntity(ModuleDTO dto)
        {
            return new Module
            {
                Id = dto.Id,
                Name = dto.Name,
                Description = dto.Description
                // Agrega otros campos si es necesario
            };
        }
    }
}
