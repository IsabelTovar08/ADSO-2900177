using Business;
using Entity.DTOs;
using Entity.Model;
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

    public class RolUserController : ControllerBase
    {
        private readonly UserRoleBusiness _rolUserBusiness;
        private readonly ILogger<RolUserController> _logger;

        public RolUserController(UserRoleBusiness rolUserBusiness, ILogger<RolUserController> logger)
        {
            _rolUserBusiness = rolUserBusiness;
            _logger = logger;
        }

        ///<summary>
        /// Obtener todos los rolUsers del sistema
        ///</summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserRoleDTO>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllRolUsers()
        {
            try
            {
                var RolUsers = await _rolUserBusiness.GetAllUsersRolesAsync();
                return Ok(RolUsers);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los rolUsers");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        ///<summary>
        /// Obtener un rolUserBusiness especificio por su ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserRoleDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetRolUserById(int id)
        {
            try
            {
                var RolUser = await _rolUserBusiness.GetUserRoleByIdAsync(id);
                return Ok(RolUser);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validacion fallida para rolUserBusiness con ID: {RolUserId}", id);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {

                _logger.LogInformation(ex, "RolUser no encontrado con ID: {RolUserId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al obtener el rolUserBusiness con ID: {RolUserId}", id);
                throw;
            }
        }


        /// <summary>
        /// Crea un nuevo rolUserBusiness en el sistema
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(UserRoleDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateRolUser([FromBody] UserRoleCreateDTO rolUserDTO)
        {
            try
            {
                var createdRolUser = await _rolUserBusiness.CreateUserRoleAsync(rolUserDTO);
                return CreatedAtAction(nameof(GetRolUserById), new { id = createdRolUser.Id }, createdRolUser);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validacion fallida al crear el rolUserBusiness");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al crear el rolUserBusiness");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Actualiza un rolUserBusiness existente en el sistema
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(UserDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UdateRoleUser([FromBody] UserRoleCreateDTO userDTO)
        {
            try
            {
                var updatedRole = await _rolUserBusiness.UpdateUserAsync(userDTO);
                if (updatedRole == null)
                    return NotFound(new { message = "User rol no encontrado." });
                return Ok(updatedRole);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizar el user.rol");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el user rol.");
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
        public async Task<IActionResult> SoftDeleteUserRole(int id)
        {
            try
            {
                var deleted = await _rolUserBusiness.SoftDeleteUserAsync(id);
                if (!deleted)
                    return NotFound(new { message = "User rol no encontrado." });
                return Ok(new { message = "User rol desactivado correctamente," });
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
                var deleted = await _rolUserBusiness.HardDeleteUserAsync(id);
                if (!deleted)
                    return NotFound(new { message = "User role no encontrado." });
                return NoContent();
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el user role.");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
