using Business.Classes;
using Business.Strategy.Request;
using Entity.DTOs;
using Entity.DTOs.Create;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exeptions;


namespace Web.Controllers.ModelSecurity
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PersonController : ControllerBase
    {
        private readonly PersonBusiness _PersonBusiness;
        private readonly ILogger<PersonController> _logger;

        /// Constructor del contPersonador de permisos
        public PersonController(PersonBusiness PersonBusiness, ILogger<PersonController> logger)
        {
            _PersonBusiness = PersonBusiness;
            _logger = logger;
        }

        // QUERY ALL
        //[Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PersonDto>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllPersons()
        {
            try
            {
                var Persons = await _PersonBusiness.GetAllAsync();
                return Ok(Persons);
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al obtener permisos");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // QUERY BY ID
        [Authorize(Roles = "Admin")]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(PersonDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetPersonById(int id)
        {
            try
            {
                var Person = await _PersonBusiness.GetByIdAsync(id);
                return Ok(Person);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida para el permiso con ID: {PersonId}", id);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "Permiso no encontrado con ID: {PersonId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al obtener permiso con ID: {PersonId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // INSERT 
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ProducesResponseType(typeof(PersonDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreatePerson([FromBody] PersonCreate PersonDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var createdPerson = await _PersonBusiness.CreateAsync(PersonDto);
                return CreatedAtAction(nameof(GetPersonById), new { id = createdPerson.Id }, createdPerson);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al crear la persona");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al crear la persona");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // UPDATE
        [Authorize(Roles = "Admin")]
        [HttpPut("update")]
        [ProducesResponseType(typeof(object), 200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdatePerson([FromBody] PersonCreate PersonDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var update = await _PersonBusiness.UpdateAsync(PersonDto);
                return Ok(update);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizacion el Person con ID: {PersonId}", PersonDto.Id);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "Person no encontrado con ID: {PersonId}", PersonDto.Id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el Person con ID: {PersonId}", PersonDto.Id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeletePerson(DeleteRequest deleteRequest)
        {
            try
            {
               await _PersonBusiness.DeleteAsyncStrategy(deleteRequest.Id, deleteRequest.Strategy);
                return Ok(); // Código 204: Eliminación exitosa sin contenido
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al eliminar el person con ID: {PersonId}");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "Person no encontrado con ID: {PersonId}");
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el person con ID: {PersonId}");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
