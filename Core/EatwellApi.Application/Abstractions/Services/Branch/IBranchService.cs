using EatwellApi.Application.Dtos.Branch;

namespace EatwellApi.Application.Abstractions.Services.Branch
{
    public interface IBranchService
    {
        Task<List<BaseBranchDto>> GetLookupAsync();
    }
}
