using EatwellApi.Domain.Entities.Common;
using System.Linq.Expressions;

namespace EatwellApi.Application.Abstractions.Repositories;

public interface IReadRepository<T> : IRepository<T> where T : BaseEntity
{
    Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null);

    IQueryable<T> Where(Expression<Func<T, bool>> expression);

    Task<T?> GetSingleAsync(Expression<Func<T, bool>> expression);

    Task<T?> GetSingleReadOnlyAsync(Expression<Func<T, bool>> expression);

    Task<T?> GetByIdAsync(int id);

    Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
}
