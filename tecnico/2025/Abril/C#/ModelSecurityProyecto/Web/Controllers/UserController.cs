using Business;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exceptions;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de usuarios en el sistema
    /// </summary>

    [Route("api/Users")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly UserBusiness _UserBusiness;
        private readonly ILogger<UserController> _Logger;

        /// <summary>
        /// Constructor del controlador de usuarios
        /// </summary>
        public UserController(UserBusiness userBusiness, ILogger<UserController> logger)
        {
            _UserBusiness = userBusiness;
            _Logger = logger;
        }

        /// <summary>
        /// Obtiene todos los usuarios del sistema
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDTO>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllUsers()
        {
            try
            {
                var users = await _UserBusiness.GetAllUsersAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "Error al obtener los usuarios.");
                return StatusCode(500, new {message = ex.Message});
            }
        }

        /// <summary>
        /// Obtiene un user específico por su ID
        /// </summary>
        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(UserDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _UserBusiness.GetUserByIdAsync(id);
                return Ok(user);
            }
            catch (ValidationException ex)
            {
                _Logger.LogInformation(ex, $"Validación fallida para el user con id: {id}");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _Logger.LogInformation(ex, $"User con ID: {id} no encontrado.");
                return NotFound(new {message = ex.Message});
            }
            catch (ExternalServiceException ex)
            {
                _Logger.LogError(ex, $"Error al obtener el user con ID: {id}");
                return StatusCode(500, new { message = ex.Message });

            }
        }


        /// <summary>
        /// Crea un nuevo user en el sistema
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(UserDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateUser([FromBody] UserFormDTO userDTO)
        {
            try
            {
                var createdUser = await _UserBusiness.CreateUserAsync(userDTO);
                return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
            }
            catch (ValidationException ex)
            {
                _Logger.LogWarning(ex, "Validación fallida al crear el user.");
                return BadRequest(new {message =ex.Message});
            }
            catch(ExternalServiceException ex)
            {
                _Logger.LogError(ex, "Error al crear el user");
                return StatusCode(500, new {message = ex.Message});
            }
        }

        /// <summary>
        /// Actualiza un nuevo rol en el sistema
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(UserDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UdateRole([FromBody] UserFormDTO userDTO)
        {
            try
            {
                var updatedRole = await _UserBusiness.UpdateUserAsync(userDTO);
                if (updatedRole == null)
                    return NotFound(new { message = "User no encontrado." });
                return Ok(updatedRole);
            }
            catch (ValidationException ex)
            {
                _Logger.LogWarning(ex, "Validación fallida al actualizar el user.");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _Logger.LogError(ex, "Error al actualizar el user.");
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
        public async Task<IActionResult> SoftDeleteRole(int id)
        {
            try
            {
                var deleted = await _UserBusiness.SoftDeleteUserAsync(id);
                if (!deleted)
                    return NotFound(new { message = "User no encontrado." });
                return Ok(new { message = "User desactivado correctamente," });
            }
            catch (ExternalServiceException ex)
            {
                _Logger.LogError($"Error al desactivar el user: {id}");
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
                var deleted = await _UserBusiness.HardDeleteUserAsync(id);
                if (!deleted)
                    return NotFound(new { message = "User no encontrado." });
                return NoContent();
            }
            catch (ExternalServiceException ex)
            {
                _Logger.LogError(ex, "Error al eliminar el user.");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
