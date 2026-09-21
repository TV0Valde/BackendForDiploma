using BackendForDiploma.Api.Domain.Entities;
using BackendForDiploma.Api.Infrastucture.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BackendForDiploma.Api.Infrastucture.Repositories
{
    public class BuildingRepository : Repository<Building>, IBuildingRepository
    {

        public BuildingRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<Building?> GetWithPointsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await Set.Include(b => b.Points)
                .FirstOrDefaultAsync(b => b.Id == id, cancellationToken);
        }
    }
}
