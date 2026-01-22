using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Application.Abstractions.Services;
using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Persistence.Services
{
    public class WriteManager<T> : IWriteService<T> where T : class, IEntity, new()
    {
        readonly IWriteRepository<T> _repository;


        public WriteManager(IWriteRepository<T> repository)
            => _repository = repository;



        public async Task AddAsync(T entity)
            => await _repository.AddAsync(entity);




        public async Task AddRangeAsync(IEnumerable<T> entities)
            => await _repository.AddRangeAsync(entities);




        public void Remove(T entity)
           => _repository.Remove(entity);




        public void RemoveRange(IEnumerable<T> entities)
            => _repository.RemoveRange(entities);




        public void Update(T entity)
            => _repository.Update(entity);




        public void UpdateRange(IEnumerable<T> entities)
            => _repository.UpdateRange(entities);
    }
}
