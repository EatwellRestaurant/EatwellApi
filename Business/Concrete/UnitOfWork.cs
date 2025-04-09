using Business.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using System.Transactions;

namespace Business.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        IServiceProvider _serviceProvider;
        public UnitOfWork(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public async Task SaveChangesAsync()
        {
            RestaurantContext context = _serviceProvider.GetRequiredService<RestaurantContext>();
            using var transaction = await context.Database.BeginTransactionAsync();

            try
            {
                await context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();

                throw new TransactionException("Transaction yönetiminde hata oluştu!", ex);
            }

        }
    }
}
