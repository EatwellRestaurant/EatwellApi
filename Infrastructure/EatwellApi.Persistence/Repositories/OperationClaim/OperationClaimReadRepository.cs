using EatwellApi.Application.Abstractions.Repositories.OperationClaim;
using EatwellApi.Persistence.Context;
using DomainOperationClaim = EatwellApi.Domain.Entities.OperationClaim;

namespace EatwellApi.Persistence.Repositories.OperationClaim
{
    public class OperationClaimReadRepository : ReadRepository<DomainOperationClaim>, IOperationClaimReadRepository
    {
        public OperationClaimReadRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
