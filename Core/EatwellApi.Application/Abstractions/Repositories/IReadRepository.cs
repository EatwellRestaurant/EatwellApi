using EatwellApi.Domain.Entities.Abstract;
using System.Linq.Expressions;

namespace EatwellApi.Application.Abstractions.Repositories;

public interface IReadRepository<T> where T : class, IEntity, new()
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null);

    IQueryable<T> GetAllQueryable(Expression<Func<T, bool>>? expression = null);

    Task<List<T>> GetAllListAsync(Expression<Func<T, bool>>? expression = null);

    Task<T?> GetByIdAsync(int id);

    Task<T?> GetAsync(Expression<Func<T, bool>> filter);

    Task<T?> GetAsNoTrackingAsync(Expression<Func<T, bool>> filter);
   
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
    
    IQueryable<T> Where(Expression<Func<T, bool>> expression);
    
    Task<int> CountAsync(Expression<Func<T, bool>>? expression = null);
}
