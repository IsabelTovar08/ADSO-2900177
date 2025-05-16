using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Entity.Models.PublicApi;

namespace Entity.DataInitConfiguration.PublicApi
{
    internal class UserPublicConfiguration : IEntityTypeConfiguration<UserPublic>
    {
        public void Configure(EntityTypeBuilder<UserPublic> builder)
        {
          
            builder.ToTable("UsersPublic", schema: "PublicApi");
        }
    }

}
