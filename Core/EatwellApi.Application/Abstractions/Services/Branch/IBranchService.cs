using EatwellApi.Application.Dtos.Branch;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;

namespace EatwellApi.Application.Abstractions.Services.Branch
{
    public interface IBranchService
    {
        Task<List<BranchLookupDto>> GetLookupAsync();

        Task<PaginationResponse<BranchListWithCityDto>> GetAllAsync(PaginationRequest request);
    }
}
