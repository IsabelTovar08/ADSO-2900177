using Business;
using Entity.DTOs;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exceptions;

namespace Web.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ModuleController2 : ControllerBase
    {
        private readonly ModuleBusiness2 _ModuleBusiness2;
        private readonly ILogger<ModuleController2> _logger;


        /// <summary>
        /// Constructor del contmoduleador de modules
        /// </summary>
        /// 
        public ModuleController2(ModuleBusiness2 moduleBusiness2, ILogger<ModuleController2> logger)
        {
            _ModuleBusiness2 = moduleBusiness2;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene todos los modules del sistema
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<ModuleDTO>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllModules()
        {
            try
            {
                var modules = await _ModuleBusiness2.GetAllAsync();
                return Ok(modules);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los modules.");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Obtiene un module específico por su ID
        /// </summary>

        [HttpGet("{id:int}")]
        [ProducesResponseType(typeof(ModuleDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetModuleById(int id)
        {
            try
            {
                var modulee = await _ModuleBusiness2.GetByIdAsync(id);
                return Ok(modulee);
            }
            catch (ValidationException ex)
            {
                _logger.LogInformation(ex, $"Validación fallida para el module con ID: {id}");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, $"Modulo no encontrado con ID: {id}");
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, $"Error al obtener module con ID: {id}");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        /// <summary>
        /// Crea un nuevo modulo en el sistema
        /// </summary>
        /// 
        [HttpPost]
        [ProducesResponseType(typeof(ModuleDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateModule([FromBody] ModuleDTO moduleDTO)
        {
            try
            {
                var createdModule = await _ModuleBusiness2.CreateAsync(moduleDTO);
                return CreatedAtAction(nameof(GetModuleById), new { id = createdModule.Id }, createdModule);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al crear el modulo.");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al crear el modulo.");
                return StatusCode(500, new { message = ex.Message });
            }

        }

        /// <summary>
        /// Actualiza un nuevo modulo en el sistema
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(ModuleDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UdateModule([FromBody] ModuleDTO moduleDTO)
        {

            try
            {
                if (moduleDTO == null || moduleDTO.Id <= 0)
                {
                    return BadRequest(new { message = "El ID del modulo debe ser mayor que cero y no nulo" });
                }

                var updateModule = await _ModuleBusiness2.UpdateAsync(moduleDTO);
                return Ok(updateModule);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizar el modulo");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogInformation(ex, "module no encontrado con ID: {RolId}", moduleDTO.Id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el module con ID: {RolId}", moduleDTO.Id);
                return StatusCode(500, new { message = ex.Message });
            }
        }

        ///// <summary>
        ///// Elimina un modulo de manera lógica en el sistema
        ///// </summary>
        //[HttpPut("logical/{id:int}")]
        //[ProducesResponseType(200)]
        //[ProducesResponseType(404)]
        //[ProducesResponseType(500)]
        //public async Task<IActionResult> SoftDeleteModule(int id)
        //{
        //    try
        //    {
        //        var deleted = await _ModuleBusiness2.SoftDeleteModuleAsync(id);
        //        if (!deleted)
        //            return NotFound(new { message = "Modulo no encontrado." });
        //        return Ok(new { message = "Modulo desactivado correctamente," });
        //    }
        //    catch (ExternalServiceException ex)
        //    {
        //        _logger.LogError($"Error al desactivar el modulo: {id}");
        //        return StatusCode(500, new { message = ex.Message });
        //    }
        //}

        /// <summary>
        /// Elimina un modulo de manera permanente en el sistema
        /// </summary>
        [HttpDelete("permanent/{id:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> HardDeleteModule(int id)
        {
            try
            {
                var deleted = await _ModuleBusiness2.DeleteAsync(id);
                if (!deleted)
                    return NotFound(new { message = "Rol no encontrado." });
                return NoContent();
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el modulo.");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
