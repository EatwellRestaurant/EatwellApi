using EatwellApi.Application.Abstractions.Repositories.Branch;
using EatwellApi.Persistence.Context;
using DomainBranch = EatwellApi.Domain.Entities.Branch;

namespace EatwellApi.Persistence.Repositories.Branch
{
    public class BranchReadRepository : ReadRepository<DomainBranch>, IBranchReadRepository
    {
        public BranchReadRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
