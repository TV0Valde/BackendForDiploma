using BackendForDiploma.Api.Domain.Entities;
using BackendForDiploma.Api.Infrastucture.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendForDiploma.Api.Infrastucture.Repositories
{
    public class PointRepository : Repository<Point>, IPointRepository
    {
        public PointRepository(ApplicationDbContext context) : base(context)
        {
        }

        public Task<List<Point>> GetByBuildingIdAsync(Guid buildingId, CancellationToken cancellationToken = default)
        {
            return Set.Where(p => p.BuildingId == buildingId).ToListAsync(cancellationToken);
        }

        public async Task<Point?> GetWithRecordsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await Set.Include(p=>p.Records).FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
        }
    }
}
