using System.Text;
using Business.services;
using Business.services.Auth;
using Business.services.JWT;
using Entity.DTOs;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly AuthBusiness _authService;
        private readonly UserRolBusiness _userRolBusiness;

        public AuthController(JwtService jwtService, AuthBusiness userBusiness, UserRolBusiness userRolBusiness)
        {
            _jwtService = jwtService;
            _authService = userBusiness;
            _userRolBusiness = userRolBusiness;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _authService.ValidateUserAsync(request.UserName, request.Password);
            if (user == null)
            {
                return Unauthorized("Credenciales inválidas.");
            }

            var roles = await _userRolBusiness.GetRolesByUserId(user.Id);
            var token = _jwtService.GenerateToken(user.Id.ToString(), user.UserName, roles);

            return Ok(new { token });
        }

        /// <summary>
        /// Endpoint para iniciar sesión usando Google OAuth2.
        /// Recibe un token de Google (JWT) y devuelve un JWT personalizado del sistema.
        /// </summary>
        /// <param name="tokenDto">DTO que contiene el tokenId recibido desde el cliente tras login con Google</param>
        /// <returns>Un JWT del sistema si el token de Google es válido; de lo contrario, Unauthorized</returns>
        [HttpPost("google")]
        public async Task<IActionResult> GoogleLogin([FromBody] string tokenDto)
        {
            // 1. Validar el token recibido de Google
            var payload = await _authService.VerifyGoogleToken(tokenDto.TokenId);

            // 2. Si el token no es válido, rechazar el acceso
            if (payload == null)
                return Unauthorized("Token inválido de Google");

            // 3. Buscar o crear un usuario en la base de datos con el email recibido en el token de Google
            var user = await _authService.GetOrCreateGoogleUser(payload.Email, payload.Name);

            // 4. Obtener los roles asociados a ese usuario
            var roles = await _rolUserResvice.GetRolesByUserId(user.Id);

            // 5. Generar un JWT del sistema con los datos del usuario y sus roles
            var token = _jwtService.GenerateToken(user.Id.ToString(), user.Email, roles);

            // 6. Retornar el token generado para que el frontend lo use en sesiones autenticadas
            return Ok(new { token });
        }

    }
}
