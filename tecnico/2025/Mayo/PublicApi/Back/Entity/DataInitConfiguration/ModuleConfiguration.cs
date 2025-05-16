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
    public class ModuleConfiguration : IEntityTypeConfiguration<Module>
    {
        public void Configure(EntityTypeBuilder<Module> builder)
        {
            builder.HasData(
                
                new Module { Id = 1, Name = "Citas",Description= "Donde se generan todas las funciones de las citas"},
                new Module { Id = 2, Name = "Administrador", Description = "Donde se adminstra el sistema" }


                );
        }
    }
}
