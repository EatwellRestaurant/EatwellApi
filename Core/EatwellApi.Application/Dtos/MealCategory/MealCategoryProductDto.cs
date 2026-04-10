using EatwellApi.Application.Dtos.Product;
using EatwellApi.Application.Wrappers;

namespace EatwellApi.Application.Dtos.MealCategory
{
    public class MealCategoryProductDto
    {
        public string Name { get; set; }

        public string IconPath { get; set; }

        public string ImagePath { get; set; }

        public PaginationResponse<ProductDisplayDto> Products { get; set; }
    }
}
