using Business.Classes.PublicApi;
using Business.Strategy.Request;
using Entity.Models.PublicApi;
using Microsoft.AspNetCore.Mvc;
using Utilities.Exeptions;

namespace Web.Controllers.PublicApi
{

    [Route("api/[controller]")]
    [ApiController]
    public class AlbumsPublicController : ControllerBase
    {
        private readonly AlbumsPublicBusiness _AlbumsPublicBusiness;
        private readonly ILogger<AlbumsPublicBusiness> _Logger;

        public AlbumsPublicController(AlbumsPublicBusiness albumBusiness, ILogger<AlbumsPublicBusiness> logger)
        {
            _AlbumsPublicBusiness = albumBusiness;
            _Logger = logger;
        }

        //Obtener todos los usuarios 
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<AlbumsPublic>), 200)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var albums = await _AlbumsPublicBusiness.GetAllAsync();
                return Ok(albums);
            }
            catch (Exception ex)
            {
                _Logger.LogError(ex, "Error al obtener todos los Usuarios");
                return StatusCode(500, new { message = ex.Message });
            }
        }

        //Obtener cualquier usuario por ID
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(IEnumerable<AlbumsPublic>), 200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var album = await _AlbumsPublicBusiness.GetByIdAsync(id);
                return Ok(album);
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
        [ProducesResponseType(typeof(AlbumsPublic), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Create([FromBody] List<AlbumsPublic> albums)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (albums == null || albums.Count == 0)
                return BadRequest("No se recibieron usuarios.");


            try
            {
                var createdAlbumss = new List<AlbumsPublic>();

                foreach (var album in albums)
                {
                    var createdAlbums = await _AlbumsPublicBusiness.CreateAsync(album);
                    createdAlbumss.Add(createdAlbums);
                }

                // Luego devuelve algo con todos los usuarios creados
                return Ok(createdAlbumss);


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
        [ProducesResponseType(typeof(AlbumsPublic), 201)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public async Task<IActionResult> Update([FromBody] AlbumsPublic albumDTO)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var createAlbums = await _AlbumsPublicBusiness.CreateAsync(albumDTO);
                return CreatedAtAction(nameof(GetById), new { id = createAlbums.Id }, createAlbums);
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
        public async Task<IActionResult> DeleteAlbums(DeleteRequest deleteRequest)
        {
            try
            {
                var response = await _AlbumsPublicBusiness.DeleteAsync(deleteRequest.Id);
                return Ok(response); // Código 204: Eliminación exitosa sin contenido
            }
            catch (ValidationException ex)
            {
                _Logger.LogWarning(ex, "Validación fallida al eliminar el album con ID: {AlbumsId}");
                return BadRequest(new { message = ex.Message });
            }
            catch (EntityNotFoundException ex)
            {
                _Logger.LogInformation(ex, "Albums no encontrado con ID: {AlbumsId}");
                return NotFound(new { message = ex.Message });
            }
            catch (ExternalServiceException ex)
            {
                _Logger.LogError(ex, "Error al eliminar el album con ID: {AlbumsId}");
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}
