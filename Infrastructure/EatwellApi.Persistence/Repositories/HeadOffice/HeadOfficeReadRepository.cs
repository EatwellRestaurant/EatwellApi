using EatwellApi.Application.Abstractions.Repositories.HeadOffice;
using EatwellApi.Persistence.Context;
using DomainHeadOffice = EatwellApi.Domain.Entities.HeadOffice;

namespace EatwellApi.Persistence.Repositories.HeadOffice
{
    public class HeadOfficeReadRepository : ReadRepository<DomainHeadOffice>, IHeadOfficeReadRepository
    {
        public HeadOfficeReadRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
