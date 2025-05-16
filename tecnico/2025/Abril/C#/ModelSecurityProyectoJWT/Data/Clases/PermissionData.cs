using Data.Clases;
using Entity;
using Entity.Context;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
namespace Data.repositories.Global
{
    /// <summary>
    /// Clase para acceso a datos de la entidad Permission usando EF Core.
    /// Hereda de CrudBase y proporciona operaciones CRUD estándar.
    /// </summary>
    public class PermissionData : CrudBase<Permission>
    {
        /// <summary>
        /// Constructor de PermissionData.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        /// <param name="logger">Logger para la entidad Permission.</param>
        public PermissionData(ApplicationDbContext context, ILogger<Permission> logger) : base(context, logger)
        {

        }
    }
}