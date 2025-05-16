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
    public class RolConfiguration : IEntityTypeConfiguration<Rol>
    {
        public void Configure(EntityTypeBuilder<Rol> builder)
        {
            builder.HasData(
          new Rol { Id = 1, Name = "Admin", Description = "Rol de administrador" },
          new Rol { Id = 2, Name = "Usuario", Description = "Rol estándar" }
      );
        }
    }
}
