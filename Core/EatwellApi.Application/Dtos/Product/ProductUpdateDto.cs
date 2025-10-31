using Microsoft.AspNetCore.Http;

namespace EatwellApi.Application.Dtos.Product
{
    public class ProductUpdateDto : ProductUpsertDto
    {
        public IFormFile? Image { get; set; }
    }
}
