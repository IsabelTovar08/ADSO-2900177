using Data.Clases;
using Entity;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.repositories.Global
{ /// <summary>
  /// Clase para acceso a datos de la entidad Role usando EF Core.
  /// Hereda de CrudBase y proporciona operaciones CRUD estándar.
  /// </summary>
    public class RoleData : CrudBase<Role>
    {
        /// <summary>
        /// Constructor de RoleData.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        /// <param name="logger">Logger para la entidad Role.</param>
        public RoleData(ApplicationDbContext context, ILogger<Role> logger) : base(context, logger)
        {
        }
    }
}