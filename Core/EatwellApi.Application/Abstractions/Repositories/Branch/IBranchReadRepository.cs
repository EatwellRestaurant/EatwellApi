using DomainBranch = EatwellApi.Domain.Entities.Branch;

namespace EatwellApi.Application.Abstractions.Repositories.Branch
{
    public interface IBranchReadRepository : IReadRepository<DomainBranch>
    {
    }
}
