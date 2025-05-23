﻿using Business;
using Data;
using Entity.DTOs;
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

    public class FormModuleController : ControllerBase
    {


        private readonly FormModuleBusiness _formModuleBusiness;
        private readonly ILogger<FormModuleController> _logger;

        public FormModuleController(FormModuleBusiness formModuleBusiness, ILogger<FormModuleController> logger)
        {
            _formModuleBusiness = formModuleBusiness;
            _logger = logger;
        }

        /// <summary>
        /// Obtener todos los formModules del sistema
        /// </summary>
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<FormModuleDTO>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAllFormModules()
        {
            try
            {
                var FormModules = await _formModuleBusiness.GetAllFormsModuleAsync();
                return Ok(FormModules);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener los formModules");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        ///<summary>
        /// Obtener un form especificio por su ID
        /// </summary>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(FormModuleDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetFormModuleById(int id)
        {
            try
            {
                var Form = await _formModuleBusiness.GetFormModuleByIdAsync(id);
                return Ok(Form);
            }
            catch (ValidationException ex)
            {
                _logger.LogInformation(ex, "Validacion fallida para formModule con ID: {FormModuleId}", id);
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {

                _logger.LogInformation(ex, "FormModule no encontrado con ID: {FormModuleId}", id);
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al obtener el formModule con ID: {FormMOduleId}", id);
                throw;
            }
        }


        /// <summary>
        /// Crea un nuevo formModule en el sistema
        /// </summary>
        [HttpPost]
        [ProducesResponseType(typeof(FormModuleDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> CreateFormModule([FromBody] FormModuleCreateDTO formModuleDTO)
        {
            try
            {
                var createdFormModule = await _formModuleBusiness.CreateFormAsync(formModuleDTO);
                return CreatedAtAction(nameof(GetFormModuleById), new { id = createdFormModule.Id }, createdFormModule);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validacion fallida al crear el formModule");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al crear el formModule");
                return StatusCode(500, new { message = ex.Message });
            }
        }


        /// <summary>
        /// Actualiza un formModule existente en el sistema
        /// </summary>
        [HttpPut]
        [ProducesResponseType(typeof(FormModuleDTO), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> UpdateFormModule([FromBody] FormModuleCreateDTO formModuleDTO)
        {
            try
            {
                var updatedFormPermission = await _formModuleBusiness.UpdateFormModuleAsync(formModuleDTO);
                if (updatedFormPermission == null)
                    return NotFound(new { message = "Form permission no encontrado." });
                return Ok(updatedFormPermission);
            }
            catch (ValidationException ex)
            {
                _logger.LogWarning(ex, "Validación fallida al actualizar el Form permission");
                return BadRequest(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al actualizar el Form permission.");
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
        public async Task<IActionResult> SoftDeleteFormModule(int id)
        {
            try
            {
                var deleted = await _formModuleBusiness.SoftDeleteFormModuleAsync(id);
                if (!deleted)
                    return NotFound(new { message = "Form module no encontrado." });
                return Ok(new { message = "Form module desactivado correctamente," });
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError($"Error al desactivar el foem module: {id}");
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
                var deleted = await _formModuleBusiness.HardDeleteFormModuleAsync(id);
                if (!deleted)
                    return NotFound(new { message = "Form module no encontrado." });
                return NoContent();
            }
            catch (ExternalServiceException ex)
            {
                _logger.LogError(ex, "Error al eliminar el form module.");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
