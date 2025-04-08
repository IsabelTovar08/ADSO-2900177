using Data.Clases;
using Entity.Context;
using Entity.Model;
using Microsoft.Extensions.Logging;

namespace Data
{
    /// <summary>
    /// Clase para acceso a datos de la entidad Form usando EF Core.
    /// Hereda de CrudBase y proporciona operaciones CRUD estándar.
    /// </summary>
    public class FormData2 : CrudBase<Form>
    {
        /// <summary>
        /// Constructor de FormData2.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        /// <param name="logger">Logger para la entidad Form.</param>
        public FormData2(ApplicationDbContext context, ILogger<Form> logger)
            : base(context, logger)
        {
        }

        // Aquí puedes agregar métodos específicos para la entidad Form si los necesitas.
        // Ejemplo:
        // public async Task<IEnumerable<Form>> GetFormsByUserId(int userId)
        // {
        //     return await _context.Forms.Where(f => f.UserId == userId).ToListAsync();
        // }
    }
}
