
using Business;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exceptions;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de roles en el sistema
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class RoleController : ControllerBase
    {
        private readonly RolBusiness _RolBusiness;
        private readonly ILogger<RoleController> _logger;

        /// <summary>
        /// Constructor del controlador de roles
        /// </summary>
        public RoleController(RolBusiness rolBusiness, ILogger<RoleController> logger)
        {
            _RolBusiness = rolBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los roles del sistema
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RoleDTO>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllRoles()
        {
            try
            {
                var roles = await _RolBusiness.GetAllRolesAsync();
                return Ok(roles);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los roles.");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un rol específico por su ID
        /// </summary>

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(RoleDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetRoleById(int id)
        {
            try
            {
                var role = await _RolBusiness.GetRoleByIdAsync(id);
                return Ok(role);
            }
            catch (ValidationException ex)
            {
                _logger.LogInformation(ex, $"Validación fallida para el rol con ID: {id}");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, $"Rol no encontrado con ID: {id}");
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, $"Error al obtener rol con ID: {id}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo rol en el sistema
        /// </summary>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(RoleDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateRole([FromBody] RoleDTO roleDTO)
        {
            try
            {
                var createdRole = await _RolBusiness.CreateRoleAsync(roleDTO);
                return CreatedAtAction(nameof(GetRoleById), new { id = createdRole.Id }, createdRole);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al crear el rol.");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al crear el rol.");
                return StatusCode(500, new { message = ex.Message });
            }

        }

        /// <summary>
        /// Actualiza un nuevo rol en el sistema
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(RoleDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UdateRole([FromBody] RoleDTO roleDTO)
        {
            try
            {
                var updatedRole = await _RolBusiness.UpdateRoleAsync(roleDTO);
                if (updatedRole == null)
                    return NotFound(new { message = "Rol no encontrado." });
                return Ok(updatedRole);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizar el rol.");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el rol.");
                return StatusCode(500, new {message = ex.Message});
            }
        }

        /// <summary>
        /// Elimina un rol de manera lógica en el sistema
        /// </summary>
        [HttpPut("logical/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> SoftDeleteRole(int id)
        {
            try
            {
                var deleted = await _RolBusiness.SoftDeleteRoleAsync(id);
                if (!deleted)
                    return NotFound(new { message = "Rol no encontrado." });
                return Ok(new { message = "Rol desactivado correctamente," });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError($"Error al desactivar el rol: {id}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un rol de manera permanente en el sistema
        /// </summary>
        [HttpDelete("permanent/{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> HardDeleteRole(int id)
        {
            try
            {
                var deleted = await _RolBusiness.HardDeleteRoleAsync(id);
                if (!deleted)
                    return NotFound(new { message = "Rol no encontrado." });
                return NoContent();
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el rol.");
                return StatusCode(500, new { message = ex.Message});
            }
        }
    }
}
