using Data.interfaces;
using Entity;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Org.BouncyCastle.Crypto.Generators;

namespace Data.repositories.Global
{
    public class UserData : GenericData<User>
    {
        public UserData(ApplicationDbContext context, ILogger<User> logger) : base(context, logger)
        {

        }

        public async override Task<User> CreateAsync(User user)
        {
            try
            {
                string passwordHasshed = BCrypt.Net.BCrypt.HashPassword(user.Password);
                user.Password = passwordHasshed;
                await _context.Set<User>().AddAsync(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex) {
                _logger.LogError(ex, "Error al crear el usuario ");
                throw;
            }
        }
        public async Task<User?> ValidateUserAsync(string email, string plainPassword)
        {
            var user = await _context.user
                .FirstOrDefaultAsync(u => u.UserName == email && u.Status);

            if (user == null)
                return null;

            bool isValid = BCrypt.Net.BCrypt.Verify(plainPassword, user.Password);
            return isValid ? user : null;
        }

        public async Task<List<string>> GetUserRolesByIdAsync(int userId)
        {
            var user = await _context.Set<User>()
                .Include(u => u.UserRoles)
                    .ThenInclude(ur => ur.Rol)
                .FirstOrDefaultAsync(u => u.Id == userId);

            return user?.UserRoles.Select(ur => ur.Rol.Name).ToList() ?? new List<string>();
        }

    }
}