using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiWebApi.Entidades;

namespace MiWebApi.Controllers
{
    [Route("api/laptops")]
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
            return await context.Laptop.ToListAsync();
        }

        [HttpGet("{id:int}", Name = "ObtenerLaptopPorId")]
        public async Task<ActionResult<Laptop>> Get(int id)
        {
            var laptop = await context.Laptop.FirstOrDefaultAsync(x => x.Id == id);
            if (laptop is null)
            {
                return NotFound();
            }
            return laptop;
        }

        [HttpPost]
        public async Task<CreatedAtRouteResult> Post([FromBody] Laptop laptop)
        {
            context.Add(laptop);
            await context.SaveChangesAsync();
            return CreatedAtRoute("ObtenerLaptopPorId", new { id = laptop.Id }, laptop);
        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] Laptop laptop)
        {
            var exixteLaptop = await context.Laptop.AnyAsync(x => x.Id == id);
            if (!exixteLaptop)
            {
                return NotFound();
            }
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
