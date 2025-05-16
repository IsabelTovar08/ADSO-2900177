using Business;
using Data;
using Entity.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Utilities.Exceptions;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class RolFormPermissionController : ControllerBase
    {
        private readonly RoleFormPermissionBusiness _rolFormPermissionBusiness;
        private readonly ILogger<RolFormPermissionController> _logger;

        public RolFormPermissionController(RoleFormPermissionBusiness rolFormPermissionBusiness, ILogger<RolFormPermissionController> logger)
        {
            _rolFormPermissionBusiness = rolFormPermissionBusiness;
            _logger = logger;
        }

        ///<summary>
        /// Obtener todos los rolFormPermissions del sistema
        ///<summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<RoleFormPermissionDTO>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllRolFormPermissions()
        {
            try
            {
                var RolFormPermissions = await _rolFormPermissionBusiness.GetAllRoleFormPermissionsAsync();
                return Ok(RolFormPermissions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los rolFormPermissions");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        ///<summary>
        /// Obtener un rolFormPermissionBusiness especificio por su ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RoleFormPermissionDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetRolFormPermissionById(int id)
        {
            try
            {
                var RolFormPermission = await _rolFormPermissionBusiness.GetRoleFormPermissionByIdAsync(id);
                return Ok(RolFormPermission);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validacion fallida para rolFormPermissionBusiness con ID: {RolFormPermissionId}", id);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {

                _logger.LogInformation(ex, "RolFormPermission no encontrado con ID: {RolFormPermissionId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al obtener el rolFormPermissionBusiness con ID: {RolFormPermissionId}", id);
                throw;
            }
        }


        /// <summary>
        /// Crea un nuevo rolFormPermissionBusiness en el sistema
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(RoleFormPermissionDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateRolFormPermission([FromBody] RoleFormPermissionCreateDTO rolFormPermissionDTO)
        {
            try
            {
                var createdRolFormPermission = await _rolFormPermissionBusiness.CreateRoleFormPermissionAsync(rolFormPermissionDTO);
                return CreatedAtAction(nameof(GetRolFormPermissionById), new { id = createdRolFormPermission.Id }, createdRolFormPermission);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validacion fallida al crear el rolFormPermissionBusiness");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al crear el rolFormPermissionBusiness");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Actualiza un rolFormPermissionBusiness existente en el sistema
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(RoleFormPermissionDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UdateRoleUser([FromBody] RoleFormPermissionCreateDTO roleFormPermissionCreateDTO)
        {
            try
            {
                var updatedRole = await _rolFormPermissionBusiness.UpdateRoleFOrmPermissionAsync(roleFormPermissionCreateDTO);
                if (updatedRole == null)
                    return NotFound(new { message = "Rol Form Permission no encontrado." });
                return Ok(updatedRole);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizar el Rol Form Permission");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el Rol Form Permission.");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Elimina un rol de manera lógica en el sistema
        /// </summary>
        [HttpPut("logical/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> SoftDeleteRoleFormPermission(int id)
        {
            try
            {
                var deleted = await _rolFormPermissionBusiness.SoftDeleteUserAsync(id);
                if (!deleted)
                    return NotFound(new { message = "Role Form Permission no encontrado." });
                return Ok(new { message = "Role Form Permission desactivado correctamente," });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError($"Error al desactivar el user rol: {id}");
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
        public async Task<IActionResult> HardDeleteRoleUser(int id)
        {
            try
            {
                var deleted = await _rolFormPermissionBusiness.HardDeleteUserAsync(id);
                if (!deleted)
                    return NotFound(new { message = "Role Form Permission no encontrado." });
                return NoContent();
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el Role Form Permission.");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
