using EatwellApi.Application.Dtos.Product;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;

namespace EatwellApi.Application.Abstractions.Services.Product
{
    public interface IProductService
    {
        Task<PaginationResponse<ProductDisplayDto>> GetAllByMealCategoryIdAsync(PaginationRequest request, int mealCategoryId);
    }
} 
