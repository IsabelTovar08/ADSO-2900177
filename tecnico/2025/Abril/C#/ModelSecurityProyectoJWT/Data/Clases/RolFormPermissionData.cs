using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Entity;
using System.Linq;
using Entity.DTOs;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore.Storage;
using Data.Clases;
using Entity.Context;

namespace Data.repositories.Global
{
    public class RoleFormPermissionData : CrudBase<RoleFormPermission>
    {
        private ApplicationDbContext context;
        private ILogger<RoleFormPermissionData> _logger;
        public RoleFormPermissionData(ApplicationDbContext context, ILogger<RoleFormPermission> logger) : base(context, logger)
        {
            this.context = context;
        }

        public override async Task<IEnumerable<RoleFormPermission>> GetAllAsync()
        {
            try
            {
                return await context.RolFormPermission
                    .Include(rfp => rfp.Role)
                    .Include(rfp => rfp.Form)
                    .Include(rfp => rfp.Permission)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving RoleFormPermissions");
                throw;
            }
        }

        public override async Task<RoleFormPermission> GetByIdAsync(int id)
        {
            try
            {
                return await context.RolFormPermission
                    .Include(rfp => rfp.Role)
                    .Include(rfp => rfp.Form)
                    .Include(rfp => rfp.Permission)
                    .FirstOrDefaultAsync(rfp => rfp.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving RoleFormPermissions");
                throw;
            }
        }



    }
}

