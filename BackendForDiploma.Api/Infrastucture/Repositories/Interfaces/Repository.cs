using Microsoft.EntityFrameworkCore;

namespace BackendForDiploma.Api.Infrastucture.Repositories.Interfaces
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<T> Set;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            Set = _context.Set<T>();
        }

        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Set.AddAsync(entity, cancellationToken);
        }

        public void Delete(T entity)
        {
            Set.Remove(entity);
        }

        public async Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Set.ToListAsync(cancellationToken);
        }

        public async Task<T?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await Set.FindAsync(new object[] { id }, cancellationToken);
        }

        public void Update(T entity)
        {
            Set.Update(entity);
        }
    }
}
