using Core.Entities.Abstract;
using Core.ResponseModels;
using Core.Utilities.Results;
using System.Linq.Expressions;

namespace Service.Abstract
{
    public interface IService<TEntity> where TEntity : class, IEntity, new()
    {
        Task<DataResponse<TEntity>> GetByIdAsync(int id, string entityName);
        
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        
        Task<int> CountAsync(Expression<Func<TEntity, bool>> expression);

        Task<List<TEntity>> GetAll();
         
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        
        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

    }
}
