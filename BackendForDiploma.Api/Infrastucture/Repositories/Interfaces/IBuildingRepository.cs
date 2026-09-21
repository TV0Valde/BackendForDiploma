using BackendForDiploma.Api.Domain.Entities;

namespace BackendForDiploma.Api.Infrastucture.Repositories.Interfaces
{
    public interface IBuildingRepository : IRepository<Building>
    {
        Task<Building?> GetWithPointsAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
