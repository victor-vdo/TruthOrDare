using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using TruthOrDare.Domain.Entities.Models;

namespace TruthOrDare.Infra.Mapping
{
    public class DareMapper : IEntityTypeConfiguration<Dare>
    {
        public void Configure(EntityTypeBuilder<Dare> modelBuilder)
        {
            modelBuilder.HasKey(x => x.Id);

            modelBuilder
                .Property(x => x.Type)
                .IsRequired(true);

            modelBuilder
                .Property(x => x.Description)
                .HasMaxLength(255)
                .IsRequired(true);
        }
    }
}
