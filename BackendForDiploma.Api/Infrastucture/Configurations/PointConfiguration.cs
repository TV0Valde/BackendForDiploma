using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BackendForDiploma.Api.Domain.Entities;

namespace BackendForDiploma.Api.Infrastucture.Configurations
{
    public class PointConfiguration : IEntityTypeConfiguration<Point>
    {
        public void Configure(EntityTypeBuilder<Point> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.SphereObjectName).HasMaxLength(256);
            builder.Property(p => p.CurrentColor).HasMaxLength(32);

            builder.HasIndex(p => p.BuildingId);

            builder.HasMany(p => p.Records)
                .WithOne(r => r.Point)
                .HasForeignKey(r => r.PointId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
