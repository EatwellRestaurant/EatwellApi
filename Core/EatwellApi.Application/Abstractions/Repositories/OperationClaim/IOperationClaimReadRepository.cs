using DomainOperationClaim = EatwellApi.Domain.Entities.OperationClaim;

namespace EatwellApi.Application.Abstractions.Repositories.OperationClaim
{
    public interface IOperationClaimReadRepository : IReadRepository<DomainOperationClaim>
    {
    }
}
