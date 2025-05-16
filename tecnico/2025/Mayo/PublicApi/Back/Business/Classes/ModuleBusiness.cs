using AutoMapper;
using Data.Interfases;
using Entity.DTOs;
using Entity.DTOs.Create;
using Entity.Models;
using Microsoft.Extensions.Logging;
using Utilities.Exeptions;

namespace Business.Classes
{
    public class ModuleBusiness : BusinessBase<Module, ModuleDto, ModuleCreate>
    {
        public ModuleBusiness
            (ICrudBase<Module> data, ILogger<Module> logger, IMapper mapper) : base(data, logger, mapper)
        {

        }

        protected override void Validate(ModuleCreate moduleDto)
        {
            if (moduleDto == null)
                throw new ValidationException("El módulo no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(moduleDto.Name))
                throw new ValidationException("El Nombre del módulo es obligatorio.");
        }


    }
}
