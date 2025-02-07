using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaLibros.Entidades;

namespace SistemaLibros.Controllers
{
    [Route("Api/Libros")]
    public class LibroController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public LibroController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Libro>> Get()
        {
            return await context.Libros.ToListAsync();
        }

        [HttpGet("{id:int}", Name = "ObtenerLibroPorId")]
        public async Task<ActionResult<Libro>> Get(int id)
        {
           var libro = await context.Libros.FirstOrDefaultAsync(x => x.Id == id);
            if (libro is null)
            {
                return NotFound();
            }
            return libro;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Libro libro)
        {
            context.Add(libro);
            await context.SaveChangesAsync();
            return CreatedAtRoute("ObtenerLibroPorId", new {id = libro.Id}, libro);

        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Libro libro)
        {
            var existeLibro = await context.Libros.AnyAsync(x => x.Id == id);
            if (!existeLibro)
            {
                return NotFound();
            }
            libro.Id = id;
            context.Update(libro);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasBorradas = await context.Libros.Where(x => x.Id == id).ExecuteDeleteAsync();
            if(filasBorradas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
