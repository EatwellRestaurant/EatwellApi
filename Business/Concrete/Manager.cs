using Business.Abstract;
using Business.Constants.Messages;
using Core.DataAccess;
using Core.Entities.Abstract;
using Core.Exceptions.General;
using Core.ResponseModels;
using Service.Abstract;
using System.Linq.Expressions;

namespace Service.Concrete
{
    public class Manager<TEntity> : IService<TEntity> where TEntity : class, IEntity, new()
    {
        readonly IEntityRepository<TEntity> _repository;


        public Manager(IEntityRepository<TEntity> repository) 
            => _repository = repository;




        public async Task AddAsync(TEntity entity)
            => await _repository.AddAsync(entity);




        public async Task AddRangeAsync(IEnumerable<TEntity> entities) 
            => await _repository.AddRangeAsync(entities);




        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression)
            => await _repository.AnyAsync(expression);



         
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null)
            => await _repository.GetAllAsync(expression);




        public IQueryable<TEntity> GetAllQueryable(Expression<Func<TEntity, bool>>? expression = null)
            => _repository.GetAllQueryable(expression);
        
        
        
        public async Task<List<TEntity>> GetAllList(Expression<Func<TEntity, bool>>? expression = null)
            => await _repository.GetAllListAsync(expression);




        public async Task<TEntity> GetByIdAsync(int id, string entityName)
        {
            TEntity? result = await _repository.GetByIdAsync(id);


            if (result == null)
                throw new EntityNotFoundException($"{entityName}");


            return result;
        }




        public Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
            => _repository.GetAsync(filter);
        
        
        
         
        public Task<TEntity?> GetAsNoTrackingAsync(Expression<Func<TEntity, bool>> filter)
            => _repository.GetAsNoTrackingAsync(filter);




        public void Remove(TEntity entity) 
            => _repository.Remove(entity);




        public void RemoveRange(IEnumerable<TEntity> entities) 
            => _repository.RemoveRange(entities);




        public void Update(TEntity entity) 
            => _repository.Update(entity);




        public void UpdateRange(IEnumerable<TEntity> entities) 
            => _repository.UpdateRange(entities);




        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression) 
            => _repository.Where(expression);




        public async Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null) 
            => await _repository.CountAsync(expression);

        
    }
}
