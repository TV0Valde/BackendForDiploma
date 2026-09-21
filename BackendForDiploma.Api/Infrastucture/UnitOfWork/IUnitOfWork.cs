using BackendForDiploma.Api.Infrastucture.Repositories.Interfaces;

namespace BackendForDiploma.Api.Infrastucture.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IBuildingRepository Buildings { get; }
        public IPointRepository Points { get; }
        public IPointRecordRepository PointRecords { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);

        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}
