using EatwellApi.Domain.Entities.Common;

namespace EatwellApi.Application.Abstractions.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity
    {
        Task<bool> AddAsync(T entity);

        Task<bool> AddRangeAsync(List<T> entities);

        bool Remove(T entity);

        Task<bool> RemoveAsync(int id);

        bool Update(T entity);

        Task<int> SaveChangesAsync();

    }
}
