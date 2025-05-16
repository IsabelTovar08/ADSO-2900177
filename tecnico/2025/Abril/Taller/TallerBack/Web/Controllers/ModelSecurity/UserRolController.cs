using Business.Classes;
using Business.Strategy.Request;
using Entity.DTOs;
using Entity.DTOs.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exeptions;

namespace Web.Controllers.ModelSecurity
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserRolController : ControllerBase
    {
        private readonly UserRolBusiness _UserRolBusiness;
        private readonly ILogger<UserRolController> _logger;

        /// Constructor del controlador de permisos
        public UserRolController(UserRolBusiness UserRolBusiness, ILogger<UserRolController> logger)
        {
            _UserRolBusiness = UserRolBusiness;
            _logger = logger;
        }

        // QUERY ALL
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserRolDto>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllUserRols()
        {
            try
            {
                var UserRols = await _UserRolBusiness.GetAllAsync();
                return Ok(UserRols);
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al obtener permisos");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // QUERY BY ID
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserRolDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetUserRolById(int id)
        {
            try
            {
                var UserRol = await _UserRolBusiness.GetByIdAsync(id);
                return Ok(UserRol);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida para el permiso con ID: {UserRolId}", id);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "Permiso no encontrado con ID: {UserRolId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al obtener permiso con ID: {UserRolId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // INSERT 
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(UserRolDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateUserRol([FromBody] UserRolCreateDto UserRolDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var createdUserRol = await _UserRolBusiness.CreateAsync(UserRolDto);
                return CreatedAtAction(nameof(GetUserRolById), new { id = createdUserRol.Id }, createdUserRol);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al crear permiso");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al crear permiso");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // UPDATE
        [Authorize]
        [HttpPut("update")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateUserRol([FromBody] UserRolCreateDto UserRolDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var update = await _UserRolBusiness.UpdateAsync(UserRolDto);
                return Ok(update);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizacion el userrol con ID: {UserRolId}", UserRolDto.Id);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "UserRol no encontrado con ID: {UserRolId}", UserRolDto.Id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el userrol con ID: {UserRolId}", UserRolDto.Id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteUserRol(DeleteRequest deleteRequest)
        {
            try
            {
                await _UserRolBusiness.DeleteAsyncStrategy(deleteRequest.Id, deleteRequest.Strategy);
                return Ok(); // Código 204: Eliminación exitosa sin contenido
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al eliminar el userRol con ID: {UserRolId}");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "UserRol no encontrado con ID: {UserRolId}");
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el userRol con ID: {UserRolId}");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
