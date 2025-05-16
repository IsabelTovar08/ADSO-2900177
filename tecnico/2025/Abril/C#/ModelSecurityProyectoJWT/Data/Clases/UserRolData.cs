using System;
using System.Collections;
using System.Collections.Generic;
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
    public class UserRolData : CrudBase<UserRole>
    {
        private ApplicationDbContext context;
        private ILogger<UserRolData> _logger;
        public UserRolData(ApplicationDbContext context, ILogger<UserRole> logger) : base(context, logger)
        {
            this.context = context;
        }

        public override async Task<IEnumerable<UserRole>> GetAllAsync()
        {
            try
            {
                return await context.userRol
                    .Include(ur => ur.User)
                    .Include(ur => ur.Role)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving UserRols");
                throw;
            }
        }

        public override async Task<UserRole> GetByIdAsync(int id)
        {
            try
            {
                return await context.userRol
                    .Include(ur => ur.User)
                    .Include(ur => ur.Role)
                    .FirstOrDefaultAsync(ur => ur.Id == id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving UserRols");
                throw;
            }
        }

        public async Task<List<string>> GetRolesByUserIdAsync(int userId)
        {
            try
            {
                return await context.userRol
                    .Include(ur => ur.Role)
                    .Where(ur => ur.User.Id == userId)
                    .Select(ur => ur.Role.Name)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error retrieving roles for user with ID {userId}");
                throw;
            }
        }


    }
}

