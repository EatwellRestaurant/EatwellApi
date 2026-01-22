using EatwellApi.Domain.Entities.Abstract;
using System.Linq.Expressions;

namespace EatwellApi.Application.Abstractions.Services
{
    public interface IReadService<TEntity> where TEntity : class, IEntity, new()
    {
        Task<TEntity> GetByIdAsync(int id, string entityName);

        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter);

        Task<TEntity?> GetAsNoTrackingAsync(Expression<Func<TEntity, bool>> filter);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);

        Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null);

        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null);

        IQueryable<TEntity> GetAllQueryable(Expression<Func<TEntity, bool>>? expression = null);

        Task<List<TEntity>> GetAllList(Expression<Func<TEntity, bool>>? expression = null);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
    }
}
