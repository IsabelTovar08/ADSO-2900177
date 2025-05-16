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
    public class ModuleFormConfiguration : IEntityTypeConfiguration<ModuleForm>
    {
        public void Configure(EntityTypeBuilder<ModuleForm> builder)
        {
            builder.HasData(
                new ModuleForm { Id =1, FormId=1, ModuleId =1},
                new ModuleForm { Id = 2, FormId = 2, ModuleId = 2 }
                );

            builder.ToTable("ModuleForms", schema: "ModelSecurity");
            builder.HasOne(e => e.Module)
                   .WithMany(c => c.ModuleForm)
                   .HasForeignKey(e => e.ModuleId);
        }
    }
}
