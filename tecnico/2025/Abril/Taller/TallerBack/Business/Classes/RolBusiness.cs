using AutoMapper;
using Data.Interfases;
using Entity.DTOs;
using Entity.DTOs.Create;
using Entity.Models;
using Microsoft.Extensions.Logging;
using Utilities.Exeptions;

namespace Business.Classes
{
    public class RolBusiness : BusinessBase<Rol, RolDto, RolCreate>
    {
        public RolBusiness(ICrudBase<Rol> data, ILogger<Rol> logger, IMapper mapper) : base(data, logger, mapper)
        {

        }

        protected override void Validate(RolCreate rol)
        {
            if (rol == null)
                throw new ValidationException("El rol no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(rol.Name))
                throw new ValidationException("El nombre del rol es obligatorio.");

        }

    }
}
