using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Clases;
using Entity;
using Entity.Context;
using Entity.DTOs;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.repositories.Global
{
    /// <summary>
    /// Clase para acceso a datos de la entidad FormModule usando EF Core.
    /// Hereda de CrudBase y proporciona operaciones CRUD estándar.
    /// </summary>
    public class FormModuleData : CrudBase<FormModule>
    {
        private ApplicationDbContext context;
        private ILogger<FormModuleData> _logger;

        /// <summary>
        /// Constructor de FormModuleData.
        /// </summary>
        /// <param name="context">Contexto de base de datos.</param>
        /// <param name="logger">Logger para la entidad FormModule.</param>
        public FormModuleData(ApplicationDbContext context, ILogger<FormModule> logger) : base(context, logger)
        {
            this.context = context;
        }

        public override async Task<IEnumerable<FormModule>> GetAllAsync()
        {
            try
            {
                return await context.ModuleForm
                    .Include(mf => mf.Module)
                    .Include(mf => mf.Form)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving FormModules");
                throw;
            }
        }

        public override async Task<FormModule> GetByIdAsync(int id)
        {
            try
            {
                return await context.ModuleForm
                    .Include(mf => mf.Module)
                    .Include(mf => mf.Form)
                    .FirstOrDefaultAsync(fm => fm.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving FormModules");
                throw;
            }
        }

        

    }
}

