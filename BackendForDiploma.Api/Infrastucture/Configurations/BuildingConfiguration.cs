using BackendForDiploma.Api.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BackendForDiploma.Api.Infrastucture.Configurations
{
    public class BuildingConfiguration : IEntityTypeConfiguration<Building>
    {
        public void Configure(EntityTypeBuilder<Building> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Name).IsRequired().HasMaxLength(256);
            builder.Property(b => b.ModelObjectKey).HasMaxLength(512);
            builder.Property(b => b.ModelFormat).HasMaxLength(32);

            builder.HasMany(b => b.Points)
                .WithOne(p => p.Building)
                .HasForeignKey(p => p.BuildingId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}
