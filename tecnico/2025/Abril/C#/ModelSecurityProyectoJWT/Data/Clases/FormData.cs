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
    public class FormData : CrudBase<Form>
    {
        /// <summary>
        /// Constructor de FormData.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        /// <param name="logger">Logger para la entidad Form.</param>
        public FormData(ApplicationDbContext context, ILogger<Form> logger) : base(context, logger)
        {
        }

    }
}
