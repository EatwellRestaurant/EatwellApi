namespace EatwellApi.Application.Dtos.Product
{
    public class ProductListDto : AuditableDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
 