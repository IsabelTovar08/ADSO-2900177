using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Data.Interfases;
using Entity.Models.PublicApi;
using Microsoft.Extensions.Logging;

namespace Business.Classes.PublicApi
{
    public class AlbumsPublicBusiness : BusinessBase<AlbumsPublic, AlbumsPublic, AlbumsPublic>
    {
        public AlbumsPublicBusiness(ICrudBase<AlbumsPublic> data, ILogger<AlbumsPublic> logger, IMapper mapper) : base(data, logger, mapper)
        {
        }

        protected override void Validate(AlbumsPublic entity)
        {
        }
    }
}
