using EatwellApi.Application.Abstractions.Repositories.City;
using EatwellApi.Persistence.Context;
using DomainCity = EatwellApi.Domain.Entities.City;

namespace EatwellApi.Persistence.Repositories.City
{
    public class CityReadRepository : ReadRepository<DomainCity>, ICityReadRepository
    {
        public CityReadRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
