using BackendForDiploma.Api.Domain.Entities;

namespace BackendForDiploma.Api.Infrastucture.Repositories.Interfaces
{
    public interface IPointRecordRepository: IRepository<PointRecord>
    {
        Task<List<PointRecord>> GetByPointIdAsync(Guid pointId, CancellationToken cancellationToken = default);
    }
}
