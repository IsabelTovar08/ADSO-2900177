using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.services.JWT;
using Data.repositories.Global;
using Entity.DTOs;
using Entity.Model;
using Google.Apis.Auth;
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
        public async Task<User> LoginAsync(string email, string password)
        {
            // Validar usuario
            var user = await _userData.ValidateUserAsync(email, password);
            if (user == null)
                throw new ValidationException("Credenciales inválidas");

            // Generar token
            return user;
        }


        /// <summary>
        /// Busca un usuario por email y, si no existe, lo crea con los datos provistos por Google.
        /// </summary>
        /// <param name="email">Correo del usuario obtenido desde Google</param>
        /// <param name="name">Nombre del usuario obtenido desde Google</param>
        /// <returns>Un objeto User existente o recién creado</returns>
        public async Task<User> GetOrCreateGoogleUser(string email, string name)
        {
            var user = await _userData.FindByEmail(email);
            if (user != null) return user;

            // Crear un nuevo usuario si no existe en el sistema
            var newUser = new User
            {
                UserName = email,
                Password = null!, // No se guarda contraseña ya que viene autenticado desde Google
                Status = true,
                Person = null
            };

            await _userData.CreateAsync(newUser);
            return newUser;
        }

        /// <summary>
        /// Verifica la validez de un token JWT generado por Google (ID Token).
        /// </summary>
        /// <param name="tokenId">ID Token recibido desde Google en el frontend</param>
        /// <returns>Payload del token si es válido; null si no lo es</returns>
        public async Task<GoogleJsonWebSignature.Payload?> VerifyGoogleToken(string tokenId)
        {
            try
            {
                var settings = new GoogleJsonWebSignature.ValidationSettings
                {
                    // Lista de IDs de cliente válidos registrados en Google Cloud Console
                    Audience = new List<string> { "140227784056-arlnkaj5j7frl6k3uku5ft0e178dq42m.apps.googleusercontent.com" }
                };

                // Valida el token contra la audiencia esperada
                var payload = await GoogleJsonWebSignature.ValidateAsync(tokenId, settings);
                return payload;
            }
            catch
            {
                // Si el token es inválido o no se pudo validar, retorna null
                return null;
            }

        }

    }
}