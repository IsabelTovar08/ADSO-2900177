using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.services.JWT;
using Data.repositories.Global;
using Entity.Model;
using Utilities.Exeptions;

namespace Business.services.Auth
{
    public class AuthBusiness
    {
        private readonly UserData _userData;
        private readonly JwtService _jwtService;
        public AuthBusiness(UserData userData, JwtService jwtService)
        {
            _userData = userData;
            _jwtService = jwtService;
        }
        public async Task<string> LoginAsync(string email, string password)
        {
            // Validar usuario
            var user = await _userData.ValidateUserAsync(email, password);
            if (user == null)
                throw new ValidationException("Credenciales inválidas");

            // Obtener roles
            List<string> roles = await _userData.GetUserRolesByIdAsync(user.Id);

            // Generar token
            return _jwtService.GenerateToken(user.Id.ToString(), user.UserName, roles);
        }
    }

}
