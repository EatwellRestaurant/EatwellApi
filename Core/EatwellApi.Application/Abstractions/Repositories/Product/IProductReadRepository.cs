using DomainProduct = EatwellApi.Domain.Entities.Product;

namespace EatwellApi.Application.Abstractions.Repositories.Product
{
    public interface IProductReadRepository : IReadRepository<DomainProduct>
    {
    }
}
