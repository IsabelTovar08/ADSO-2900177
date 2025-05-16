using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiWebApi.Entidades;

namespace MiWebApi.Controllers
{
    [Route("api/laptops")]
    [ApiController]
    public class LaptopController : ControllerBase
    {
        private readonly AplicationDbContext context;

        public LaptopController(AplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Laptop>> Get()
        {
            //await Task.Delay(2000); 
            return await context.Laptop.ToListAsync();
        }

        [HttpGet("{nombre}/existe")]
        public async Task<ActionResult<bool>> ExisteNombre(string nombre, int id)
        {
            //await Task.Delay(3000);
            if (id == 0) 
            {
                return await context.Laptop.AnyAsync(x => x.Nombre == nombre);
            }
            else
            {
                return await context.Laptop.AnyAsync(x => x.Nombre == nombre && x.Id != id);
            }
        }

        [HttpGet("{id:int}", Name = "ObtenerLaptopPorId")]
        public async Task<ActionResult<Laptop>> Get(int id)
        {
            //await Task.Delay(2000);
            var laptop = await context.Laptop.FirstOrDefaultAsync(x => x.Id == id);
            if (laptop is null)
            {
                return NotFound();
            }
            return laptop;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Laptop laptop)
        {

            var yaExisteNombre = await context.Laptop.AnyAsync(x => x.Nombre == laptop.Nombre);

            if (yaExisteNombre)
            {
                var mensajeError = $"Ya existe una laptop con el nombre {laptop.Nombre}";
                ModelState.AddModelError(nameof(laptop.Nombre), mensajeError);
                return ValidationProblem(ModelState);
            }

            context.Add(laptop);
            await context.SaveChangesAsync();
            return CreatedAtRoute("ObtenerLaptopPorId", new { id = laptop.Id }, laptop);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Laptop laptop)
        {
            var existeLaptop = await context.Laptop.AnyAsync(x => x.Id == id);
            if (!existeLaptop)
            {
                return NotFound();
            }

            var existeNombre = await context.Laptop.AnyAsync(x => x.Nombre == laptop.Nombre && x.Id != id);
            if (existeNombre)
            {
                var mensajeError = $"Ya existe una laptop con el nombre {laptop.Nombre}";
                ModelState.AddModelError(nameof(laptop.Nombre), mensajeError);
                return ValidationProblem(ModelState);
            }

            laptop.Id = id;
            context.Update(laptop);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasBorradas = await context.Laptop.Where(x => x.Id == id).ExecuteDeleteAsync();
            if(filasBorradas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
