using AutoMapper;
using Data.factories;
using Data.repositories.Global;
using Entity.DTOs;
using Entity.Model;
using Microsoft.Extensions.Logging;
using Utilities.Exeptions;

namespace Business.services
{
    public class UserBusiness : GenericBusiness<User, UserDto>
    {
        private readonly UserData _userData;
        public UserBusiness(IDataFactoryGlobal factory, ILogger<User> logger, IMapper mapper) : base(factory.CreateUserData(), logger, mapper)
        {
            _userData = (UserData?)factory.CreateUserData();
        }

        protected override void Validate(UserDto user)
        {
            if (user == null)
                throw new ValidationException("El formulario no puede ser nulo.");

            if (string.IsNullOrWhiteSpace(user.UserName))
                throw new ValidationException("El título del formulario es obligatorio.");

            // Agrega más validaciones si necesitas
        }

        public async Task<User?> ValidateUserAsync(string email, string password)
        {
            return await _userData.ValidateUserAsync(email, password);
        }

        public async Task<User?> FindByEmailAsync(string email)
        {
            return await _userData.FindByEmail(email);

        }

    }
}
