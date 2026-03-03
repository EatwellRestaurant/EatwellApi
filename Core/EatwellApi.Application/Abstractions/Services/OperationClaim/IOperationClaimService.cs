using EatwellApi.Application.Dtos.OperationClaim;

namespace EatwellApi.Application.Abstractions.Services.OperationClaim
{
    public interface IOperationClaimService
    {
        Task<List<OperationClaimListDto>> GetAllAsync();
    }
}
