using EatwellApi.Application.Abstractions.Repositories.Product;
using EatwellApi.Persistence.Context;
using DomainProduct = EatwellApi.Domain.Entities.Product;

namespace EatwellApi.Persistence.Repositories.Product
{
    public class ProductReadRepository : ReadRepository<DomainProduct>, IProductReadRepository
    {
        public ProductReadRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
