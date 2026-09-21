using BackendForDiploma.Api.Infrastucture.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;

namespace BackendForDiploma.Api.Infrastucture.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        private IDbContextTransaction? _transaction;

        public IBuildingRepository Buildings { get; }
        public IPointRepository Points { get; }
        public IPointRecordRepository PointRecords { get; }

        public UnitOfWork(ApplicationDbContext context,
            IBuildingRepository buildingRepository,
            IPointRepository pointRepository,
            IPointRecordRepository pointRecordRepository)
        {
            _context = context;
            Buildings = buildingRepository;
            Points = pointRepository;
            PointRecords = pointRecordRepository;
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
             _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction is null) return;
            await _transaction.CommitAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public void Dispose()
        {
           _context.Dispose();
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction is null) return;
            await _transaction.RollbackAsync(cancellationToken);
            await _transaction.DisposeAsync();
            _transaction = null;
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _context.SaveChangesAsync(cancellationToken);
        }
    }
}
