using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Application.Abstractions.Services;
using EatwellApi.Domain.Entities.Abstract;
using EatwellApi.Domain.Exceptions.General;
using System.Linq.Expressions;

namespace EatwellApi.Persistence.Services
{
    public class ReadManager<T> : IReadService<T> where T : class, IEntity, new()
    {
        readonly IReadRepository<T> _repository;


        public ReadManager(IReadRepository<T> repository)
            => _repository = repository;



        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
            => await _repository.AnyAsync(expression);




        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null)
            => await _repository.GetAllAsync(expression);




        public IQueryable<T> GetAllQueryable(Expression<Func<T, bool>>? expression = null)
            => _repository.GetAllQueryable(expression);



        public async Task<List<T>> GetAllList(Expression<Func<T, bool>>? expression = null)
            => await _repository.GetAllListAsync(expression);




        public async Task<T> GetByIdAsync(int id, string entityName)
        {
            T? result = await _repository.GetByIdAsync(id);


            if (result == null)
                throw new EntityNotFoundException($"{entityName}");
            return result;
        }




        public Task<T?> GetAsync(Expression<Func<T, bool>> filter)
            => _repository.GetAsync(filter);




        public Task<T?> GetAsNoTrackingAsync(Expression<Func<T, bool>> filter)
            => _repository.GetAsNoTrackingAsync(filter);




        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
            => _repository.Where(expression);




        public async Task<int> CountAsync(Expression<Func<T, bool>>? expression = null)
            => await _repository.CountAsync(expression);

    }
}
