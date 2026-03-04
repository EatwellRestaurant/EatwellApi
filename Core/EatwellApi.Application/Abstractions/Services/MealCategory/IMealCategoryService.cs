using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;

namespace EatwellApi.Application.Abstractions.Services.MealCategory
{
    public interface IMealCategoryService
    {
        Task<DataResponse<List<MealCategoryLookupDto>>> GetLookupAsync();

        Task<PaginationResponse<MealCategoryListDto>> GetAllAsync(PaginationRequest request);

        Task<PaginationResponse<MealCategoryLookupDto>> GetActiveAsync(PaginationRequest request);
    }
}
