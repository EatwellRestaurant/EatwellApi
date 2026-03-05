using EatwellApi.Application.Dtos.Product;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Features.Queries.Product.GetOverview
{
    public class ProductsOverviewDto : IDto
    {
        public int TotalProducts { get; set; }

        public int ActiveProducts { get; set; }

        public int InactiveProducts { get; set; }

        public int ThisMonthAddedProducts { get; set; }

        public PaginationResponse<ProductListWithMealCategoryDto> Products { get; set; }
    }
}
