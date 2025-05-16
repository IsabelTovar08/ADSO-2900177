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
    public class FormModuleConfiguration : IEntityTypeConfiguration<FormModule>
    {
        public void Configure(EntityTypeBuilder<FormModule> builder)
        {
            builder.HasData(
                
                new FormModule { Id =1, FormId=1, ModuleId =1},
                new FormModule { Id = 2, FormId = 2, ModuleId = 2 }

                );
        }
    }
}
