using Data.Clases;
using Entity;
using Entity.Context;
using Entity.Model;
using Microsoft.Extensions.Logging;

namespace Data.repositories.Global
{
    /// <summary>
    /// Clase para acceso a datos de la entidad Person usando EF Core.
    /// Hereda de CrudBase y proporciona operaciones CRUD estándar.
    /// </summary>
    public class PersonData : CrudBase<Person>
    {
        /// <summary>
        /// Constructor de PersonData.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        /// <param name="logger">Logger para la entidad Person.</param>
        public PersonData(ApplicationDbContext context, ILogger<Person> logger) : base(context, logger)
        {

        }
    }
}
