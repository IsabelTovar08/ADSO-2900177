using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Entity.Models;
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
                    PersonId = 1,
                }, new User
                {
                    Id = 2,
                    Email = "isaTovarp.18@gmail.com",
                    Password = "M2d!Citas2025",
                    PersonId = 2,
                }
                );
            builder.ToTable("Users", schema: "ModelSecurity");
            builder.HasOne(e => e.Person)
               .WithMany(c => c.Users)
               .HasForeignKey(e => e.PersonId);
        }
    }
}
