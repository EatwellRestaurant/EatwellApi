using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Abstractions.Services
{
    public interface IWriteService<TEntity> where TEntity : class, IEntity, new()
    {
        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);
    }
}
