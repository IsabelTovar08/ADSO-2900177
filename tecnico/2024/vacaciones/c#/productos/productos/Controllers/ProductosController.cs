using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Productos.Entidadess;

namespace Productos.Controllers
{
    [Route("api/productos")]
    public class ProductosController : ControllerBase
    {
        private readonly AplicationDbContext context;

        public ProductosController(AplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public async Task<List<Producto>> Get()
        {
            return await context.Producto.ToListAsync();
        }

        [HttpGet("{id:int}", Name="ObtenerProductoPorId")]
        public async Task<ActionResult<Producto>> Get(int id)
        {
            var producto = await context.Producto.FirstOrDefaultAsync(x => x.Id == id);
            if(producto is null)
            {
                return NotFound();
            }
            return producto;
        }

        [HttpPost]
        public async Task<CreatedAtRouteResult> Post([FromBody] Producto producto)
        {
            context.Add(producto);
            await context.SaveChangesAsync();
            return CreatedAtRoute("ObtenerProductoPorId", new {id = producto.Id}, producto);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult> Put(int id, [FromBody] Producto producto)
        {
            var existeProducto = await context.Producto.AnyAsync(x => x.Id == id);
            if (!existeProducto)
            {
                return NotFound();
            }
            producto.Id = id;
            context.Update(producto);
            await context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            var filasBorrdas = await context.Producto.Where(x => x.Id == id).ExecuteDeleteAsync();
            if (filasBorrdas == 0)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
