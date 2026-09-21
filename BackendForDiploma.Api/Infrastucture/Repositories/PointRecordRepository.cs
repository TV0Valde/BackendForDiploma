using BackendForDiploma.Api.Domain.Entities;
using BackendForDiploma.Api.Infrastucture.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendForDiploma.Api.Infrastucture.Repositories
{
    public class PointRecordRepository : Repository<PointRecord>, IPointRecordRepository
    {
        public PointRecordRepository(ApplicationDbContext context) : base(context)
        {
        }
        public Task<List<PointRecord>> GetByPointIdAsync(Guid pointId, CancellationToken cancellationToken = default)
        {
            return Set.Where(pr => pr.PointId == pointId).ToListAsync(cancellationToken);
        }
    }
}
