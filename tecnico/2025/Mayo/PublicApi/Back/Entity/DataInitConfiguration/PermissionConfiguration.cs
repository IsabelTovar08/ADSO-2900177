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
    public class PermissionConfiguration : IEntityTypeConfiguration<Permission>
    {
        public void Configure(EntityTypeBuilder<Permission> builder)
        {
            builder.HasData(
                new Permission
                {
                    Id = 1,
                    Name = "VerTodo",
                    Description = "Puede ver todos los registros independiente de su estado"
                },
                new Permission 
                {
                Id = 2,
                    Name = "ver",
                    Description = "Puede ver los registros que estén activos "
                }
                );
        }
    }
}
