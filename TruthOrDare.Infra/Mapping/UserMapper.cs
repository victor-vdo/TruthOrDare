using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TruthOrDare.Domain.Entities.Models;

namespace TruthOrDare.Infra.Mapping
{
    public class UserMapper : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> modelBuilder)
        {
            modelBuilder.HasKey(x => x.Id);

            modelBuilder
                .Property(x => x.Login)
                .HasMaxLength(30)
                .IsRequired(false);

            modelBuilder
                .Property(x => x.Password)
                .HasMaxLength(255)
                .IsRequired(false);


        }
    }
}
