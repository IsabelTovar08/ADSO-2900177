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
    public class ModuleFormController : ControllerBase
    {
        private readonly ModuleFormBusiness _ModuleFormBusiness;
        private readonly ILogger<ModuleFormController> _logger;

        /// Constructor del controlador de permisos
        public ModuleFormController(ModuleFormBusiness ModuleFormBusiness, ILogger<ModuleFormController> logger)
        {
            _ModuleFormBusiness = ModuleFormBusiness;
            _logger = logger;
        }

        // QUERY ALL
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ModuleFormDto>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllModuleForms()
        {
            try
            {
                var ModuleForms = await _ModuleFormBusiness.GetAllAsync();
                return Ok(ModuleForms);
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
        [ProducesResponseType(typeof(ModuleFormDto), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetModuleFormById(int id)
        {
            try
            {
                var ModuleForm = await _ModuleFormBusiness.GetByIdAsync(id);
                return Ok(ModuleForm);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida para el permiso con ID: {ModuleFormId}", id);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "Permiso no encontrado con ID: {ModuleFormId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al obtener permiso con ID: {ModuleFormId}", id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // INSERT 
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(ModuleFormCreateDto), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateModuleForm([FromBody] ModuleFormCreateDto ModuleFormDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var createdModuleForm = await _ModuleFormBusiness.CreateAsync(ModuleFormDto);
                return CreatedAtAction(nameof(GetModuleFormById), new { id = createdModuleForm.Id }, createdModuleForm);
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
        public async Task<IActionResult> UpdateModuleForm([FromBody] ModuleFormCreateDto ModuleFormDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var update = await _ModuleFormBusiness.UpdateAsync(ModuleFormDto);
                return Ok(update);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizacion el ModuleForm con ID: {ModuleFormId}", ModuleFormDto.Id);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "ModuleForm no encontrado con ID: {ModuleFormId}", ModuleFormDto.Id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el ModuleForm con ID: {ModuleFormId}", ModuleFormDto.Id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpDelete]
        [ProducesResponseType(200)]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> DeleteModuleForm(DeleteRequest deleteRequest)
        {
            try
            {
                await _ModuleFormBusiness.DeleteAsyncStrategy(deleteRequest.Id, deleteRequest.Strategy);
                return Ok(); // Código 204: Eliminación exitosa sin contenido
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al eliminar el moduleForm con ID: {ModuleFormId}");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "ModuleForm no encontrado con ID: {ModuleFormId}");
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el moduleForm con ID: {ModuleFormId}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

    }
}
