﻿using Core.Entities.Abstract;
using Core.ResponseModels;
using Core.Utilities.Results;
using System.Linq.Expressions;

namespace Service.Abstract
{
    public interface IService<TEntity> where TEntity : class, IEntity, new()
    {
        Task<DataResponse<TEntity>> GetByIdAsync(int id, string entityName);

        Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> expression);
        
        Task<int> CountAsync(Expression<Func<TEntity, bool>>? expression = null);

        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>>? expression = null);

        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>>? expression = null);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression);
        
        Task AddAsync(TEntity entity);

        Task AddRangeAsync(IEnumerable<TEntity> entities);

        void Update(TEntity entity);

        void UpdateRange(IEnumerable<TEntity> entities);

        void Remove(TEntity entity);

        void RemoveRange(IEnumerable<TEntity> entities);

    }
}
