using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Abstractions.Repositories
{
    public interface IWriteRepository<T> where T : class, IEntity, new()
    {
        Task AddAsync(T entity);

        Task AddRangeAsync(IEnumerable<T> entities);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entities);

        void Update(T entity);

        void UpdateRange(IEnumerable<T> entities);

    }
}
