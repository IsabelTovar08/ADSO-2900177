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
    public class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.HasData(
                new Form {  Id=1,Name="Agendar cita", Description= "Formulario donde se agenda cita" },
                new Form { Id = 2, Name = "Register", Description = "Formulario donde se registra una persona " }

                );

            builder.ToTable("Forms", schema: "ModelSecurity");
           
        }
    }
}
