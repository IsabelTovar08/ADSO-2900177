using System.Text;
using Business.services;
using Business.services.JWT;
using Entity.Model;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;
        private readonly UserBusiness _userBusiness;
        private readonly UserRolBusiness _userRolBusiness;

        public AuthController(JwtService jwtService, UserBusiness userBusiness, UserRolBusiness userRolBusiness)
        {
            _jwtService = jwtService;
            _userBusiness = userBusiness;
            _userRolBusiness = userRolBusiness;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _userBusiness.ValidateUserAsync(request.UserName, request.Password);
            if (user == null)
            {
                return Unauthorized("Credenciales inválidas.");
            }

            var roles = await _userRolBusiness.GetRolesByUserId(user.Id);
            var token = _jwtService.GenerateToken(user.Id.ToString(), user.UserName, roles);

            return Ok(new { token });
        }

   
        public class LoginRequest
        {
            public string UserName { get; set; } = "";
            public string Password { get; set; } = "";
        }
    }
}
