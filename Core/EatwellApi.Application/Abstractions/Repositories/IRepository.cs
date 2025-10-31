using EatwellApi.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace EatwellApi.Application.Abstractions.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        DbSet<T> Table { get; }
    }
}
