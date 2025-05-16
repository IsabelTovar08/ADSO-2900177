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
                    DocumentType = "CC",
                    Document = "1084922863",
                    DateBorn = new DateTime(2006, 6, 13),
                    PhoneNumber = "3133156032",
                    Eps = "Sanitas",
                    Genero = "Hombre",
                    RelatedPerson = false
                },
                new Person
                {
                    Id = 2,
                    FirstName = "Maria",
                    LastName = "Isabel",
                    DocumentType = "CC",
                    Document = "1084964876",
                    DateBorn = new DateTime(2006, 10, 8),
                    PhoneNumber = "3133156032",
                    Eps = "Sanitas",
                    Genero = "Mujer",
                    RelatedPerson = false
                }
                );
        }
    }
}
