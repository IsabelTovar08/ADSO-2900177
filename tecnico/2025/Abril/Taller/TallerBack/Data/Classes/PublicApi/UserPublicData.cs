using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.Classes.Base;
using Entity.Context;
using Entity.Models.PublicApi;
using Microsoft.Extensions.Logging;

namespace Data.Classes.PublicApi
{
    public class UserPublicData : CrudBase<UserPublic>
    {
        public UserPublicData(ApplicationDbContext context, ILogger<UserPublic> logger) : base(context, logger)
        {
        }
    }
}
