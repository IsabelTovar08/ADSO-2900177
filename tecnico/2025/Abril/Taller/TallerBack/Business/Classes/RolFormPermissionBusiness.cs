using AutoMapper;
using Data.Interfases;
using Entity.DTOs;
using Entity.DTOs.Create;
using Entity.Models;
using Microsoft.Extensions.Logging;
using Utilities.Exeptions;

namespace Business.Classes
{
    public class RolFormPermissionBusiness : BusinessBase<RolFormPermission, RolFormPermissionDto, RolFormPermissionCreateDto>
    {
        public RolFormPermissionBusiness
            (ICrudBase<RolFormPermission> data, ILogger<RolFormPermission> logger, IMapper mapper) : base(data, logger, mapper)
        {

        }

        protected override void Validate(RolFormPermissionCreateDto rolFormPermissionDto)
        {
            if (rolFormPermissionDto == null)
                throw new ValidationException("El permiso por formulario para el rol no puede ser nulo.");

            if (rolFormPermissionDto.RolId == null)
                throw new ValidationException("El Rol es obligatorio.");
            if (rolFormPermissionDto.FormId == null)
                throw new ValidationException("El Formulario es obligatorio.");
            if (rolFormPermissionDto.PermissionId == null)
                throw new ValidationException("El Permiso es obligatorio.");
        }
    }
}
