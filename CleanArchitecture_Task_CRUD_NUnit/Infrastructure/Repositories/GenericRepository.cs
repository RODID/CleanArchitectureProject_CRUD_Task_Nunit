using Application.Interface.RepositoryInterface;
using Infrastructure.Database;
using Microsoft.EntityFrameworkCore;
using System.Formats.Tar;

namespace Infrastructure.Repositories
{
    public class GenericRepository<T, TKey> : IGenericRepository<T, TKey> where T : class
    {

        private readonly RealDatabase _realDatabase;
        private readonly DbSet<T> _dbSet;

        public GenericRepository(RealDatabase realDatabase)
        {
            _realDatabase = realDatabase;
            _dbSet = _realDatabase.Set<T>();
        }

       public async Task<T> AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _realDatabase.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(TKey id)
        {
            if (id is string stringId)
            {
                var entity = await _dbSet.FindAsync(stringId);
                if (entity == null)
                {
                    return false;
                }

                _dbSet.Remove(entity);
                await _realDatabase.SaveChangesAsync();
                return true;
            }
            else if (id is int intId)
            {
                var entity = await _dbSet.FindAsync(intId);
                if (entity == null)
                {
                    return false;
                }

                _dbSet.Remove(entity);
                await _realDatabase.SaveChangesAsync();
                return true;
            }
            else if (id is Guid guidId)
            {
                var entity = await _dbSet.FindAsync(guidId);
                if (entity == null)
                {
                    return false;
                }

                _dbSet.Remove(entity);
                await _realDatabase.SaveChangesAsync();
                return true;
            }
            else
            {
                throw new InvalidOperationException($"Unsupported key type: {typeof(TKey).Name}");
            }
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(TKey id)
        {
            if (id is Guid guidId)
            {
                return await _dbSet.FindAsync(guidId);
            }
            else if (id is int)
            {
                return await _dbSet.FindAsync(id);
            }
            else
            {
                throw new InvalidOperationException($"Unsupported key type: {typeof(TKey).Name}");
            }
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _realDatabase.Set<T>().Update(entity);
            await _realDatabase.SaveChangesAsync();
            return entity;
        }
    }
}
