using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.context.DataInitConfiguration
{
    public class RolUserConfiguration : IEntityTypeConfiguration<RolUser>
    {
        public void Configure(EntityTypeBuilder<RolUser> builder)
        {
            builder.HasData(
                
                  new RolUser { Id = 1, RolId =1,UserId = 1},
                  new RolUser { Id = 2, RolId = 2, UserId = 2 }

                );
        }
    }
}
