using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;

namespace EatwellApi.Application.Abstractions.Services.MealCategory
{
    public interface IMealCategoryService
    {
        Task<DataResponse<List<MealCategoryLookupDto>>> GetLookupAsync();

        Task<MealCategoryProductDto> GetByIdForUserAsync(PaginationRequest request, int id);

        Task<PaginationResponse<MealCategoryListDto>> GetAllAsync(PaginationRequest request);

        Task<PaginationResponse<MealCategoryDisplayDto>> GetActiveForUserAsync(PaginationRequest request);

        Task<PaginationResponse<MealCategoryLookupDto>> GetActiveAsync(PaginationRequest request);
    }
}
