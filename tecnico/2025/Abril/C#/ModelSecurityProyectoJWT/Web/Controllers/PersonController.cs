using Business;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exceptions;

namespace Web.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PersonController : ControllerBase
    {
        private readonly PersonBusiness _PersonBusiness;
        private readonly ILogger<PersonController> _logger;


        /// <summary>
        /// Constructor del contpersonador de personas
        /// </summary>
        /// 
        public PersonController(PersonBusiness personBusiness, ILogger<PersonController> logger)
        {
            _PersonBusiness = personBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los personas del sistema
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<PersonDTO>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllPeople()
        {
            try
            {
                var personas = await _PersonBusiness.GetAllPeopleAsync();
                return Ok(personas);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los personas.");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Obtiene un person específico por su ID
        /// </summary>

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(PersonDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetPersonById(int id)
        {
            try
            {
                var person = await _PersonBusiness.GetPersonByIdAsync(id);
                return Ok(person);
            }
            catch (ValidationException ex)
            {
                _logger.LogInformation(ex, $"Validación fallida para el person con ID: {id}");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, $"Person no encontrado con ID: {id}");
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, $"Error al obtener person con ID: {id}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo person en el sistema
        /// </summary>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(PersonDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreatePerson([FromBody] PersonDTO personDTO)
        {
            try
            {
                var createdPerson = await _PersonBusiness.CreatePersonAsync(personDTO);
                return CreatedAtAction(nameof(GetPersonById), new { id = createdPerson.Id }, createdPerson);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al crear el person.");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al crear el person.");
                return StatusCode(500, new { message = ex.Message });
            }

        }

        /// <summary>
        /// Actualiza un nuevo person en el sistema
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(PersonDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UdatePerson([FromBody] PersonDTO personDTO)
        {

            try
            {
                if (personDTO == null || personDTO.Id <= 0)
                {
                    return BadRequest(new { message = "El ID del person debe ser mayor que cero y no nulo" });
                }

                var updatePerson = await _PersonBusiness.UpdatePersonAsync(personDTO);
                return Ok(updatePerson);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizar el person");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, $"person no encontrado con ID: {personDTO.Id}", personDTO.Id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, $"Error al actualizar el person con ID: {personDTO.Id}", personDTO.Id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un person de manera lógica en el sistema
        /// </summary>
        [HttpPut("logical/{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> SoftDeletePerson(int id)
        {
            try
            {
                var deleted = await _PersonBusiness.SoftDeletePersonAsync(id);
                if (!deleted)
                    return NotFound(new { message = "Person no encontrado." });
                return Ok(new { message = "Person desactivado correctamente," });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError($"Error al desactivar el person: {id}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Elimina un person de manera permanente en el sistema
        /// </summary>
        [HttpDelete("permanent/{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> HardDeletePerson(int id)
        {
            try
            {
                var deleted = await _PersonBusiness.HardDeletePersonAsync(id);
                if (!deleted)
                    return NotFound(new { message = "Rol no encontrado." });
                return NoContent();
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el person.");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
