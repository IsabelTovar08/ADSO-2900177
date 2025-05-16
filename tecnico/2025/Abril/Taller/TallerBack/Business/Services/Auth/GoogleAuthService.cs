using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Classes.Specifics;
using Entity.DTOs;
using Entity.Models;
using Google.Apis.Auth;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Business.Services.Auth
{
    public class GoogleAuthService
    {
        private readonly UserData _userData;
        private readonly IConfiguration _config;
        private readonly ILogger<AuthService> _logger;

        public GoogleAuthService(UserData userData, IConfiguration config, ILogger<AuthService> logger)
        {
            _userData = userData;
            _config = config;
            _logger = logger;
        }

        /// <summary>
        /// Busca un usuario por email y, si no existe, lo crea con los datos provistos por Google.
        /// </summary>
        /// <param name="email">Correo del usuario obtenido desde Google</param>
        /// <param name="name">Nombre del usuario obtenido desde Google</param>
        /// <returns>Un objeto User existente o recién creado</returns>
        public async Task<User> GetOrCreateGoogleUser(GoogleUserInfo userInfo)
        {
            var user = await _userData.FindByEmail(userInfo.Email);
            if (user != null) return user;

            // Crear un nuevo usuario si no existe en el sistema
            var newUser = new User
            {
                Email = userInfo.Email,
                Password = null!, // No se guarda contraseña ya que viene autenticado desde Google
                IsDeleted = false,
                Person = new Person
                {
                    FirstName = userInfo.FirstName,
                    MiddleName = null,
                    LastName = userInfo.LastName,
                    SecondLastName = null,
                    Identification = null
                }
            };

            await _userData.CreateAsync(newUser);
            return newUser;
        }

        /// <summary>
        /// Verifica la validez de un token JWT generado por Google (ID Token).
        /// </summary>
        /// <param name="tokenId">ID Token recibido desde Google en el frontend</param>
        /// <returns>Payload del token si es válido; null si no lo es</returns>
                // Verificar el id_token de Google
        public async Task<GoogleJsonWebSignature.Payload?> VerifyGoogleToken(string tokenId)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings
                {
                    Audience = new List<string> { _config["Authentication:Google:ClientId"] }
                };

                return await GoogleJsonWebSignature.ValidateAsync(tokenId, settings);
            }
            catch
            {
                return null;
            }
        }
    }
}
