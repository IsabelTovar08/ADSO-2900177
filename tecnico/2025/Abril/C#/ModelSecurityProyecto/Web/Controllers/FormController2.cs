
using Business;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exceptions;

namespace Web.Controllers
{
    /// <summary>
    /// Controlador para la gestión de dormularios en el sistema
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class FormController2 : ControllerBase
    {
        private readonly FormBusiness _FormBusiness;
        private readonly ILogger<FormController2> _logger;

        /// <summary>
        /// Constructor del controlador de formularios
        /// </summary>
        public FormController2(FormBusiness formBusiness2, ILogger<FormController2> logger)
        {
            _FormBusiness = formBusiness2;
            _logger = logger;
        }


        /// <summary>
        /// Obtiene todos los forms del sistema
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FormDTO>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllForms()
        {
            try
            {
                var forms = await _FormBusiness.GetAllAsync();
                return Ok(forms);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los formularios.");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Obtiene un rol específico por su ID
        /// </summary>

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(FormDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetFormById(int id)
        {
            try
            {
                var form = await _FormBusiness.GetByIdAsync(id);
                return Ok(form);
            }
            catch (ValidationException ex)
            {
                _logger.LogInformation(ex, $"Validación fallida para el formulario con ID: {id}");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, $"Formulario no encontrado con ID: {id}");
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, $"Error al obtener rol con ID: {id}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo formulario en el sistema
        /// </summary>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(FormDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateForm([FromBody] FormDTO formDTO)
        {
            try
            {
                var createdForm = await _FormBusiness.CreateAsync(formDTO);
                return CreatedAtAction(nameof(GetFormById), new { id = createdForm.Id }, createdForm);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al crear el formulario.");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al crear el formulario.");
                return StatusCode(500, new { message = ex.Message });
            }

        }

        /// <summary>
        /// Actualiza un nuevo formulario en el sistema
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(FormDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UdateForm([FromBody] FormDTO formDTO)
        {

            try
            {
                if (formDTO == null || formDTO.Id <= 0)
                {
                    return BadRequest(new { message = "El ID del formulario debe ser mayor que cero y no nulo" });
                }

                var updateForm = await _FormBusiness.UpdateAsync(formDTO);
                return Ok(updateForm);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizar el formulario");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "module no encontrado con ID: {RolId}", formDTO.Id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el module con ID: {RolId}", formDTO.Id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        ///// <summary>
        ///// Elimina un formulario de manera lógica en el sistema
        ///// </summary>
        //[HttpPut("logical/{id:int}")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(500)]
        //public async Task<IActionResult> SoftDeleteForm(int id)
        //{
        //    try
        //    {
        //        var deleted = await _FormBusiness.SoftDeleteFormAsync(id);
        //        if (!deleted)
        //            return NotFound(new { message = "Modulo no encontrado." });
        //        return Ok(new { message = "Modulo desactivado correctamente," });
        //    }
        //    catch (ExternalServiceException ex)
        //    {
        //        _logger.LogError($"Error al desactivar el formulario: {id}");
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}

        /// <summary>
        /// Elimina un formulario de manera permanente en el sistema
        /// </summary>
        [HttpDelete("permanent/{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> HardDeleteForm(int id)
        {
            try
            {
                var deleted = await _FormBusiness.DeleteAsync(id);
                if (!deleted)
                    return NotFound(new { message = "Rol no encontrado." });
                return NoContent();
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el formulario.");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
