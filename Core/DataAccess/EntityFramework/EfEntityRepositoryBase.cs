using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext
    {

        readonly DbSet<TEntity> _dbSet;

        public EfEntityRepositoryBase(TContext context)
        {
            _dbSet = context.Set<TEntity>();
        }




        public async Task AddAsync(TEntity entity) 
            => await _dbSet.AddAsync(entity);




        public async Task AddRangeAsync(IEnumerable<TEntity> entities) 
            => await _dbSet.AddRangeAsync(entities);




        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression) 
            => await _dbSet.AnyAsync(expression);



         
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null) 
            => expression == null ? await _dbSet.ToListAsync() : await _dbSet.Where(expression).ToListAsync();
        



        public async Task<TEntity?> GetByIdAsync(int id) 
            => await _dbSet.FindAsync(id);




        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter) 
            => await _dbSet.SingleOrDefaultAsync(filter);




        public void Remove(TEntity entity) 
            => _dbSet.Remove(entity);
        



        public void RemoveRange(IEnumerable<TEntity> entities)
            => _dbSet.RemoveRange(entities);




        public void Update(TEntity entity) 
            => _dbSet.Update(entity);
        
        


        public void UpdateRange(IEnumerable<TEntity> entities) 
            => _dbSet.UpdateRange(entities);



         
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression) 
            => _dbSet.Where(expression);
        



        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> expression) 
            => await _dbSet.CountAsync(expression);
        
        
    }
}
