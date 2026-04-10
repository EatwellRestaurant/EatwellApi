using EatwellApi.Application.Abstractions.Repositories.Product;
using EatwellApi.Application.Abstractions.Services.Product;
using EatwellApi.Application.Dtos.Product;
using EatwellApi.Application.Extensions;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using Microsoft.EntityFrameworkCore;
using DomainProduct = EatwellApi.Domain.Entities.Product;

namespace EatwellApi.Persistence.Services.Product
{
    public class ProductManager(IProductReadRepository readRepository) : IProductService
    {
        readonly IProductReadRepository _readRepository = readRepository;



        public async Task<PaginationResponse<ProductDisplayDto>> GetAllByMealCategoryIdAsync(PaginationRequest request, int mealCategoryId)
        {
            IQueryable<DomainProduct> query = _readRepository
                .Where(p => p.MealCategoryId == mealCategoryId && !p.IsDeleted && p.IsActive);


            List<ProductDisplayDto> products = await query
                .OrderByDescending(p => p.CreateDate)
                .ApplyPagination(request)
                .Select(p => new ProductDisplayDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    ImagePath = p.ImagePath
                })
                .ToListAsync();


            return new(products, request, await query.CountAsync());
        }
    }
}
