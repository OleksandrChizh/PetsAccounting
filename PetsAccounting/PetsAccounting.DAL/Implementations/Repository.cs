using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

using PetsAccounting.DAL.Exceptions;
using PetsAccounting.DAL.Interfaces;

namespace PetsAccounting.DAL.Implementations
{
    public class Repository<T, TKey> : IRepository<T, TKey> where T : class
    {
        protected readonly DbSet<T> DbSet;

        public Repository(ApplicationContext applicationContext)
        {
            DbSet = applicationContext.Set<T>();
        }

        public virtual async Task CreateAsync(T item)
        {
            await Task.Run(() => DbSet.Add(item));
        }

        public virtual async Task DeleteAsync(TKey id)
        {
            var entity = await DbSet.FindAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException("Entity with such id is not found", typeof(T));
            }

            await Task.Run(() => DbSet.Remove(entity));
        }

        public virtual async Task<IQueryable<T>> FindAsync(Expression<Func<T, bool>> expression = null)
        {
            var result = expression == null ? 
                await Task.Run(() => DbSet) : 
                await Task.Run(() => DbSet.Where(expression));

            return result;
        }

        public virtual async Task<T> GetAsync(TKey id)
        {
            var entity = await DbSet.FindAsync(id);

            if (entity == null)
            {
                throw new EntityNotFoundException("Entity with such id is not found", typeof(T));
            }

            return entity;
        }

        public virtual async Task<int> GetCountAsync(Expression<Func<T, bool>> expression = null)
        {
            var result = expression == null ?
                await Task.Run(() => DbSet.Count()) :
                await Task.Run(() => DbSet.Count(expression));

            return result;
        }
    }
}