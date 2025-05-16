using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SecretController : ControllerBase
    {
        [Authorize]
        [HttpGet("data")]
        public IActionResult GetSecretData()
        {
            return Ok("Este es un dato protegido con JWT ✅");
        }
    }
}
