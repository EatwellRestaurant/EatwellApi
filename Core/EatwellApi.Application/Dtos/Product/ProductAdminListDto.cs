namespace EatwellApi.Application.Dtos.Product
{
    public class ProductAdminListDto : EntityAdminDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }
    }
}
