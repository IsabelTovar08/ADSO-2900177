
using Data.Classes.Base;
using Entity;
using Entity.Context;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Data.Classes.Specifics
{
    public class RolData : CrudBase<Rol>
    {
        public RolData(ApplicationDbContext context, ILogger<Rol> logger) : base(context, logger)
        {

        }

    }
}