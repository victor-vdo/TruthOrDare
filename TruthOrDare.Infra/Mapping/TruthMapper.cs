using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TruthOrDare.Domain.Entities.Models;

namespace TruthOrDare.Infra.Mapping
{
    public class TruthMapper : IEntityTypeConfiguration<Truth>
    {
        public void Configure(EntityTypeBuilder<Truth> modelBuilder)
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
