using AutoMapper;
using Data.Interfases;
using Entity.DTOs;
using Entity.DTOs.Create;
using Entity.Models;
using Microsoft.Extensions.Logging;
using Utilities.Exeptions;

namespace Business.Classes
{
    public class PermissionBusiness : BusinessBase<Permission, PermissionDto, PermissionCreate>
    {
        public PermissionBusiness(ICrudBase<Permission> data, ILogger<Permission> logger, IMapper mapper) : base(data, logger, mapper)
        {

        }

        protected override void Validate(PermissionCreate form)
        {
            if (form == null)
                throw new ValidationException("El permiso no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(form.Name))
                throw new ValidationException("El Nombre del permiso es obligatorio.");

        }
    }
}
