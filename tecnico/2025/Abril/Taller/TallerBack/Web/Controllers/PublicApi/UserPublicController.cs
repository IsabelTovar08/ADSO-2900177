using Business.Classes;
using Business.Strategy.Request;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exeptions;
using Business.Classes.PublicApi;
using Entity.Models.PublicApi;
using Entity.Models;

namespace Web.Controllers.PublicApi
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserPublicController : ControllerBase
    {
        private readonly UserPublicBusiness _UserPublicBusiness;
        private readonly ILogger<UserPublicBusiness> _Logger;

        public UserPublicController(UserPublicBusiness userBusiness, ILogger<UserPublicBusiness> logger)
        {
            _UserPublicBusiness = userBusiness;
            _Logger = logger;
        }

        //Obtener todos los usuarios 
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserPublic>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _UserPublicBusiness.GetAllAsync();
                return Ok(users);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "Error al obtener todos los Usuarios");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Obtener cualquier usuario por ID
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<UserPublic>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _UserPublicBusiness.GetByIdAsync(id);
                return Ok(user);
            }
            catch (ValidationException ex)
            {
                _Logger.LogError(ex, $"Validación fallida para el Usuario con Id {id}");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _Logger.LogError(ex, $"Usuario con Id {id} no encontrado.");
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _Logger.LogError(ex, $"Error al obtener el Usuario con Id {id}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Crear usuarios 
        [HttpPost]
        [ProducesResponseType(typeof(UserPublic), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create([FromBody] List<UserPublic> users)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (users == null || users.Count == 0)
                return BadRequest("No se recibieron usuarios.");

           
            try
            {
                var createdUsers = new List<UserPublic>();

                foreach (var user in users)
                {
                    var createdUser = await _UserPublicBusiness.CreateAsync(user);
                    createdUsers.Add(createdUser);
                }

                // Luego devuelve algo con todos los usuarios creados
                return Ok(createdUsers);


            }
            catch (ValidationException ex)
            {
                _Logger.LogError(ex, "Validaión fallida al crear el Usuario.");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _Logger.LogError(ex, "Validaión fallida al crear el Usuario.");
                return StatusCode(500, new { message = ex.Message });
            }
            return Ok("Usuarios guardados con éxito.");

        }

        //Actualizar usuarios 
        [HttpPut("{int}")]
        [ProducesResponseType(typeof(UserPublic), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromBody] UserPublic userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var createUser = await _UserPublicBusiness.CreateAsync(userDTO);
                return CreatedAtAction(nameof(GetById), new { id = createUser.Id }, createUser);
            }
            catch (ValidationException ex)
            {
                _Logger.LogError(ex, "Validaión fallida al crear el Usuario.");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _Logger.LogError(ex, "Validaión fallida al crear el Usuario.");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // DELETE => PERSISTENT
        //[Authorize]
        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteUser(DeleteRequest deleteRequest)
        {
            try
            {
                var response = await _UserPublicBusiness.DeleteAsync(deleteRequest.Id);
                return Ok(response); // Código 204: Eliminación exitosa sin contenido
            }
            catch (ValidationException ex)
            {
                _Logger.LogWarning(ex, "Validación fallida al eliminar el user con ID: {UserId}");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _Logger.LogInformation(ex, "User no encontrado con ID: {UserId}");
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _Logger.LogError(ex, "Error al eliminar el user con ID: {UserId}");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
