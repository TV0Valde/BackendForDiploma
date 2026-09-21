using BackendForDiploma.Api.Domain.Entities;
using System;
using Microsoft.EntityFrameworkCore;

namespace BackendForDiploma.Api.Infrastucture
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Building> Buildings => Set<Building>();
        public DbSet<Point> Points => Set<Point>();
        public DbSet<PointRecord> PointRecords => Set<PointRecord>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        }
    }
}
