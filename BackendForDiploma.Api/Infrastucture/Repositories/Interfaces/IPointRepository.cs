using BackendForDiploma.Api.Domain.Entities;

namespace BackendForDiploma.Api.Infrastucture.Repositories.Interfaces
{
    public interface IPointRepository : IRepository<Point>
    {
        Task<List<Point>> GetByBuildingIdAsync(Guid buildingId, CancellationToken cancellationToken = default);
        Task<Point?> GetWithRecordsAsync(Guid id, CancellationToken cancellationToken = default);
    }
}
