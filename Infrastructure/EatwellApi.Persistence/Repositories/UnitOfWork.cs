using EatwellApi.Application.Abstractions.Repositories;
using EatwellApi.Domain.Entities.Common;
using EatwellApi.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Transactions;

namespace EatwellApi.Persistence.Repositories
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
                // Türkiye saatini hesapla
                var turkeyTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Turkey Standard Time");
                var turkeyTime = TimeZoneInfo.ConvertTime(DateTime.UtcNow, turkeyTimeZone);

                // ChangeTracker ile sadece BaseEntity'den türeyen entity’lerini yakalıyoruz.
                var entries = context.ChangeTracker.Entries<BaseEntity>();

                foreach (var entry in entries)
                {
                    if (entry.State == EntityState.Added)
                        entry.Entity.CreateDate = turkeyTime;
                }

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
