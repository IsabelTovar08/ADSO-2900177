using AutoMapper;
using Data.Interfases;
using Entity.DTOs;
using Entity.DTOs.Create;
using Entity.Models;
using Microsoft.Extensions.Logging;
using Utilities.Exeptions;

namespace Business.Classes
{
    public class UserBusiness : BusinessBase<User, UserDTO, UserCreateDTO>
    {

        // Constructor para inyectar dependencias
        public UserBusiness(ICrudBase<User> data, ILogger<User> logger, IMapper mapper)
            : base(data, logger, mapper)
        {
        }

        // Validación del DTO
        protected override void Validate(UserCreateDTO userDTO)
        {
            var errors = new List<string>();

            if (userDTO == null)
            {
                throw new ValidationException("El Usuario no puede ser nulo.");
            }

            if (string.IsNullOrWhiteSpace(userDTO.UserName))
                errors.Add("El Nombre del Usuario es obligatorio.");
            if (string.IsNullOrWhiteSpace(userDTO.Email))
                errors.Add("El Email del Usuario es obligatorio.");
            if (string.IsNullOrWhiteSpace(userDTO.Password))
                errors.Add("La contraseña del Usuario es obligatoria.");
            if (string.IsNullOrWhiteSpace(userDTO.Email))
                errors.Add("El Email del Usuario es obligatorio.");

            // Si hay errores, lanzar excepción
            if (errors.Any())
            {
                throw new ValidationException(string.Join(" | ", errors));
            }
        }


    }
}
