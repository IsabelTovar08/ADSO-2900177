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
    public class AlbumsPublicData : CrudBase<AlbumsPublic>
    {
        public AlbumsPublicData(ApplicationDbContext context, ILogger<AlbumsPublic> logger) : base(context, logger)
        {
        }
    }
}
