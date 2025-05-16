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
    public class FormConfiguration : IEntityTypeConfiguration<Form>
    {
        public void Configure(EntityTypeBuilder<Form> builder)
        {
            builder.HasData(
                new Form {  Id=1,Name="Agendar cita", Description= "Formulario donde se agenda cita",Url= "http://localhost:4200/" },
                new Form { Id = 2, Name = "Register", Description = "Formulario donde se registra una persona ",Url= "http://localhost:4200/" }

                );
        }
    }
}
