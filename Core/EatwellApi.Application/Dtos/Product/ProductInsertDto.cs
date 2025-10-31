using Microsoft.AspNetCore.Http;

namespace EatwellApi.Application.Dtos.Product
{
    public class ProductInsertDto : ProductUpsertDto
    {
        public int MealCategoryId { get; set; }

        public IFormFile Image { get; set; }
    }
}
