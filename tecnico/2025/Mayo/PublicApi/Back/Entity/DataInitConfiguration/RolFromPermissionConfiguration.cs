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
    public class RolFromPermissionConfiguration : IEntityTypeConfiguration<RolFormPermission>
    {
        public void Configure(EntityTypeBuilder<RolFormPermission> builder)
        {
            builder.HasData(
                new RolFormPermission { Id =1, RolId= 1,FormId =1, PermissionId = 1},
                new RolFormPermission { Id = 2, RolId = 2, FormId = 2, PermissionId = 2 }

                );
        }
    }
}
