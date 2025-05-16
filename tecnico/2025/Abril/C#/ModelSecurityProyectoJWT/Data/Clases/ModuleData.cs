using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Data.Interfaces;
using Entity.Context;
using Entity.Model;
using Microsoft.Extensions.Logging;

namespace Data.Clases
{
    /// <summary>
    /// Clase para acceso a datos de la entidad Permission usando EF Core.
    /// Hereda de CrudBase y proporciona operaciones CRUD estándar.
    /// </summary>
    public class ModuleData : CrudBase<Module>
    {
        /// <summary>
        /// Constructor de ModuleData.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        /// <param name="logger">Logger para la entidad Permission.</param>
        public ModuleData(ApplicationDbContext context, ILogger<Module> logger) : base(context, logger)
        {
        }
    }
}
