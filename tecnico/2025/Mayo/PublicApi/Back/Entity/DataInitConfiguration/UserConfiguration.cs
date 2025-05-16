using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Entity.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Entity.context.DataInitConfiguration
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    Id = 1,
                    Email = "mauronoscue@gmail.com",
                    Password = "M1d!Citas2025",
                    RegistrationDate = new DateTime(2024, 5, 13),


                    PersonId = 1,
                }, new User
                {
                    Id = 2,
                    Email = "isaTovarp.18@gmail.com",
                    Password = "M2d!Citas2025",
                    RegistrationDate = new DateTime(2024, 5, 13),
                    PersonId = 1,
                }
                );
        }
    }
}
