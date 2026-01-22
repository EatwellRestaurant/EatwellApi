using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Domain.Entities.Abstract;
using EatwellApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EatwellApi.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : class, IEntity, new()
    {
        readonly DbSet<T> _dbSet;

        public ReadRepository(RestaurantContext context)
            => _dbSet = context.Set<T>();



        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null)
           => expression == null ? await _dbSet.AsNoTracking().ToListAsync() : await _dbSet.Where(expression).AsNoTracking().ToListAsync();




        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>>? expression = null)
            => expression == null ? _dbSet.AsNoTracking() : _dbSet.Where(expression).AsNoTracking();




        public async Task<List<T>> GetAllListAsync(Expression<Func<T, bool>>? expression = null)
            => expression == null ? await _dbSet.ToListAsync() : await _dbSet.Where(expression).ToListAsync();




        public async Task<T?> GetByIdAsync(int id)
            => await _dbSet.FindAsync(id);




        public async Task<T?> GetAsync(Expression<Func<T, bool>> filter)
            => await _dbSet.SingleOrDefaultAsync(filter);




        public async Task<T?> GetAsNoTrackingAsync(Expression<Func<T, bool>> filter)
            => await _dbSet.AsNoTracking().SingleOrDefaultAsync(filter);




        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
            => await _dbSet.AnyAsync(expression);




        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
            => _dbSet.Where(expression);




        public async Task<int> CountAsync(Expression<Func<T, bool>>? expression = null)
            => expression != null ? await _dbSet.CountAsync(expression) : await _dbSet.CountAsync();

    }
}
