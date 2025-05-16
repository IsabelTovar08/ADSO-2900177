using Business.Classes;
using Entity.DTOs;
using Entity.DTOs.Create;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exeptions;

namespace Web.Controllers
{
    [Route("/api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UserController : ControllerBase
    {
        private readonly UserBusiness _UserBusiness;
        private readonly ILogger<UserBusiness> _Logger;

        public UserController(UserBusiness userBusiness, ILogger<UserBusiness> logger)
        {
            _UserBusiness = userBusiness;
            _Logger = logger;
        }

        //Obtener todos los usuarios 
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<UserDTO>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var users = await _UserBusiness.GetAllAsync();
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
        [ProducesResponseType(typeof(IEnumerable<UserDTO>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var user = await _UserBusiness.GetByIdAsync(id);
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
        [ProducesResponseType(typeof(UserDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create([FromBody] UserCreateDTO userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var createUser = await _UserBusiness.CreateAsync(userDTO);
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

        //Actualizar usuarios 
        [HttpPut("{int}")]
        [ProducesResponseType(typeof(UserDTO), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromBody] UserCreateDTO userDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var createUser = await _UserBusiness.CreateAsync(userDTO);
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
    }
}

