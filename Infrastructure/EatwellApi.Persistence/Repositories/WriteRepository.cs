using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Domain.Entities.Abstract;
using EatwellApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace EatwellApi.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : class, IEntity, new()
    {
        readonly DbSet<T> _dbSet;

        public WriteRepository(RestaurantContext context)
            => _dbSet = context.Set<T>();




        public async Task AddAsync(T entity)
           => await _dbSet.AddAsync(entity);

        


        public async Task AddRangeAsync(IEnumerable<T> entities)
            => await _dbSet.AddRangeAsync(entities);




        public void Remove(T entity)
            => _dbSet.Remove(entity);




        public void RemoveRange(IEnumerable<T> entities)
            => _dbSet.RemoveRange(entities);




        public void Update(T entity)
            => _dbSet.Update(entity);




        public void UpdateRange(IEnumerable<T> entities)
            => _dbSet.UpdateRange(entities);
    }
}
