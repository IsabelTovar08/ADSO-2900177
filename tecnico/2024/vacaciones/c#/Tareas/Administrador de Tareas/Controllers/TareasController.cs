using Administrador_de_Tareas.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Administrador_de_Tareas.Controllers
{
    [Route("api/Tareas")]
    public class TareasController : ControllerBase
    {
        private readonly ApicationDbContext context;

        public TareasController(ApicationDbContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public async Task<List<Tarea>> Get()
        {
            return await context.Tareas.ToListAsync();
        }
        [HttpGet("{id:int}", Name="ObtenerTareaPorId")]
        public async Task<ActionResult<Tarea>> Get(int id)
        {
            var tarea = await context.Tareas.FirstOrDefaultAsync(x => x.Id == id);
            if (tarea is null)
            {
                return NotFound();
            }
            return tarea;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Tarea tarea)
        {
            if (tarea == null)
            {
                return BadRequest("La tarea no puede ser nula.");
            }

            context.Tareas.Add(tarea);
            await context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = tarea.Id }, tarea);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Tarea tarea)
        {
            var existeLaptop = await context.Tareas.AnyAsync(x => x.Id == id);
            if (!existeLaptop) 
            { 
                return NotFound();
            }
            tarea.Id = id;
            context.Update(tarea);
            await context.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasBorradas = await context.Tareas.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (filasBorradas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
