using Data.Classes.Base;
using Entity.Context;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Classes.Specifics
{
    public class UserRolData : CrudBase<UserRol>
    {
        private ApplicationDbContext context;
        private ILogger<UserRolData> _logger;
        public UserRolData(ApplicationDbContext context, ILogger<UserRol> logger) : base(context, logger)
        {
            this.context = context;
        }

        public override async Task<IEnumerable<UserRol>> GetAllAsync()
        {
            try
            {
                return await context.Set<UserRol>()
                    .Include(ur => ur.User)
                    .Include(ur => ur.Rol)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error retrieving UserRols");
                throw;
            }
        }

        public override async Task<UserRol> GetByIdAsync(int id)
        {
            try
            {
                return await context.Set<UserRol>()
                    .Include(ur => ur.User)
                    .Include(ur => ur.Rol)
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
                return await context.Set<UserRol>()
                    .Include(ur => ur.Rol)
                    .Where(ur => ur.User.Id == userId)
                    .Select(ur => ur.Rol.Name)
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

