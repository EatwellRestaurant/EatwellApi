using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Dtos.Product
{
    public class ProductUpsertDto : IDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
