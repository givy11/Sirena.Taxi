using Microsoft.EntityFrameworkCore;

using Sirena.Taxi.Core.Domain;

namespace Sirena.Taxi.Core.Abstractions.Repositories
{
    /// <summary>
    /// Реализация репозитория работы с данными для EntityFramework.
    /// </summary>
    /// <typeparam name="T">Сущность наследник BaseEntity.</typeparam>
    public class EfRepository<T>: IRepository<T> where T: BaseEntity
    {
        private readonly DbContext _dataContext;

        public EfRepository(DbContext dataContext)
        {
            _dataContext = dataContext;
        }

        /// <inheritdoc/>
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dataContext.Set<T>().ToListAsync();

        }

        /// <inheritdoc/>
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        /// <inheritdoc/>
        public async Task AddAsync(T entity)
        {
            await _dataContext.Set<T>().AddAsync(entity);
            await _dataContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task UpdateAsync(T entity)
        {
            await _dataContext.SaveChangesAsync();
        }

        /// <inheritdoc/>
        public async Task DeleteAsync(Guid id)
        {
            var entity = await _dataContext.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            if (entity != null)
            {
                _dataContext.Set<T>().Remove(entity);
                await _dataContext.SaveChangesAsync();
            }
        }
    }
}
