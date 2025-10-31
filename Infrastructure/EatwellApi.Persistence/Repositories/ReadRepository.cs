using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Domain.Entities.Common;
using EatwellApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EatwellApi.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity
    {
        readonly RestaurantContext _context;

        public ReadRepository(RestaurantContext context)
            => _context = context;



        public DbSet<T> Table
            => _context.Set<T>();


        public async Task<List<T>> GetAllAsync(Expression<Func<T, bool>>? expression = null)
            => expression == null ? await Table.AsNoTracking().ToListAsync() : await Table.Where(expression).AsNoTracking().ToListAsync();


        public async Task<T?> GetByIdAsync(int id)
            => await Table.FindAsync(id);


        public async Task<T?> GetSingleAsync(Expression<Func<T, bool>> expression)
            => await Table.SingleOrDefaultAsync(expression);


        public async Task<T?> GetSingleReadOnlyAsync(Expression<Func<T, bool>> expression)
            => await Table.AsNoTracking().SingleOrDefaultAsync(expression);


        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
            => Table.Where(expression);


        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
            => await Table.AnyAsync(expression);

    }
}
