using BackendForDiploma.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendForDiploma.Api.Infrastucture.Configurations
{
    public class PointRecordConfiguration : IEntityTypeConfiguration<PointRecord>
    {
        public void Configure(EntityTypeBuilder<PointRecord> builder)
        {
            builder.HasKey(r => r.Id);
            builder.Property(r => r.PhotoObjectKey)
                .HasMaxLength(512)
                .IsRequired(false); // ← было required, теперь nullable
            builder.Property(r => r.InspectionDate).HasMaxLength(64);
            builder.Property(r => r.State).HasMaxLength(128);

            builder.HasIndex(r => r.PointId);
        }
    }
}
