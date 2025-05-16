using Business;
using Data;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exceptions;

namespace Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class PermissionController : ControllerBase
    {
        private readonly PermissionBusiness _permissionBusiness;
        private readonly ILogger<PermissionController> _logger;

        public PermissionController(PermissionBusiness permissionBusiness, ILogger<PermissionController> logger)
        {
            _permissionBusiness = permissionBusiness;
            _logger = logger;
        }

        ///<summary>
        /// Obtener todos los permissions del sistema
        ///</summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PermissionDTO>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllPermissions()
        {
            try
            {
                var Permissions = await _permissionBusiness.GetAllPermissionsAsync();
                return Ok(Permissions);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los permissions");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        ///<summary>
        /// Obtener un permissionBusiness especificio por su ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PermissionDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetPermissionById(int id)
        {
            try
            {
                var permission = await _permissionBusiness.GetPermissionByIdAsync(id);
                return Ok(permission);
            }
            catch (ValidationException ex)
            {
                _logger.LogInformation(ex, $"Validación fallida para el permission con ID: {id}");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, $"Modulo no encontrado con ID: {id}");
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, $"Error al obtener permission con ID: {id}");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Crea un nuevo permissionBusiness en el sistema
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(PermissionDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreatePermission([FromBody] PermissionDTO permissionDTO)
        {
            try
            {
                var createdPermission = await _permissionBusiness.CreatePermissionAsync(permissionDTO);
                return CreatedAtAction(nameof(GetPermissionById), new { id = createdPermission.Id }, createdPermission);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validacion fallida al crear el permissionBusiness");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al crear el permissionBusiness");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Actualiza un permissionBusiness existente en el sistema
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(PermissionDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdatePermission([FromBody] PermissionDTO permissionDTO)
        {
            try
            {
                if (permissionDTO == null || permissionDTO.Id <= 0)
                {
                    return BadRequest(new { message = "El ID del permiso debe ser mayor que cero y no nulo" });
                }

                var updateModule = await _permissionBusiness.UpdatePermissionAsync(permissionDTO);
                return Ok(updateModule);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizar el permiso");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, $"permission no encontrado con ID: {permissionDTO.Id}", permissionDTO.Id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, $"Error al actualizar el permission con ID: {permissionDTO.Id}", permissionDTO.Id);
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Elimina un permission de manera lógica en el sistema
        /// </summary>
        [HttpPut("logical/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> SoftDeletePermission(int id)
        {
            try
            {
                var deleted = await _permissionBusiness.SoftDeletePermissionAsync(id);
                if (!deleted)
                    return NotFound(new { message = "Permission no encontrado." });
                return Ok(new { message = "Permission desactivado correctamente," });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError($"Error al desactivar el permission: {id}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un permission de manera permanente en el sistema
        /// </summary>
        [HttpDelete("permanent/{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> HardDeletePermissione(int id)
        {
            try
            {
                var deleted = await _permissionBusiness.HardDeletePermissionAsync(id);
                if (!deleted)
                    return NotFound(new { message = "Permission no encontrado." });
                return NoContent();
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el permission.");
                return StatusCode(500, new { message = ex.Message });

            }
        }
    }
}
