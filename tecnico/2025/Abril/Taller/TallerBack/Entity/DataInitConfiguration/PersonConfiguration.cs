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
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
           

                builder.HasData(
                new Person
                {
                    Id = 1,
                    FirstName = "Mauricio",
                    LastName = "Noscue",
                    Identification = "1084922863",
                    Phone = "3133156032"
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Maria",
                    LastName = "Isabel",
                    Identification = "1084964876",
                    Phone = "3133156032"
                }
                );

            builder.ToTable("People", schema: "ModelSecurity");
        }
    }
}
