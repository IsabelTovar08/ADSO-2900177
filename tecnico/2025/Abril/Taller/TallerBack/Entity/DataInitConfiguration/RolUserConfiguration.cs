using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.context.DataInitConfiguration
{
    public class UserRolConfiguration : IEntityTypeConfiguration<UserRol>
    {
        public void Configure(EntityTypeBuilder<UserRol> builder)
        {
            builder.HasData(

                  new UserRol { Id = 1, RolId = 1, UserId = 1 },
                  new UserRol { Id = 2, RolId = 2, UserId = 2 }

                );

            builder.ToTable("UserRoles", schema: "ModelSecurity");
            builder.HasOne(e => e.User)
               .WithMany(c => c.UserRoles)
               .HasForeignKey(e => e.UserId);

            builder.HasOne(e => e.Rol)
               .WithMany(c => c.UserRoles)
               .HasForeignKey(e => e.RolId);

        }

    }
}
