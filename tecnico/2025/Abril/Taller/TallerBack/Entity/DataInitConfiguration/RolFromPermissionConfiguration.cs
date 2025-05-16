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
    public class RolFromPermissionConfiguration : IEntityTypeConfiguration<RolFormPermission>
    {
        public void Configure(EntityTypeBuilder<RolFormPermission> builder)
        {
            builder.HasData(
                new RolFormPermission { Id =1, RolId= 1,FormId =1, PermissionId = 1},
                new RolFormPermission { Id = 2, RolId = 2, FormId = 2, PermissionId = 2 }

                );

            builder.ToTable("RolFormPermissions", schema: "ModelSecurity");
            builder.HasOne(e => e.Rol)
                   .WithMany(c => c.RolFormPermissions)
                   .HasForeignKey(e => e.RolId);

            builder.HasOne(e => e.Form)
               .WithMany(c => c.RolFormPermissions)
               .HasForeignKey(e => e.FormId);

            builder.HasOne(e => e.Permission)
               .WithMany(c => c.RolFormPermissions)
               .HasForeignKey(e => e.PermissionId);
        }
    }
}
