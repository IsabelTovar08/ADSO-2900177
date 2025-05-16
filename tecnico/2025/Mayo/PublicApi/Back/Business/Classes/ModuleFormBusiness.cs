using AutoMapper;
using Data.Classes.Specifics;
using Data.Interfases;
using Entity.DTOs;
using Entity.DTOs.Create;
using Entity.Models;
using Microsoft.Extensions.Logging;
using Utilities.Exeptions;

namespace Business.Classes
{
    public class ModuleFormBusiness : BusinessBase<ModuleForm, ModuleFormDto, ModuleFormCreateDto>
    {
        public ModuleFormBusiness
            (ICrudBase<ModuleForm> data, ILogger<ModuleForm> logger, IMapper mapper) : base(data, logger, mapper)
        {

        }


        protected override void Validate(ModuleFormCreateDto moduleFormDto)
        {
            if (moduleFormDto == null)
                throw new ValidationException("El múdulo del formulario no puede ser nulo.");
            if (moduleFormDto.ModuleId == null)
                throw new ValidationException("El Módulo es obligatorio.");
            if (moduleFormDto.FormId == null)
                throw new ValidationException("El Formulario es obligatorio.");

        }

    }
}
