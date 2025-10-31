namespace EatwellApi.Application.Dtos.Product
{
    public class ProductListWithMealCategoryDto : ProductAdminListDto
    {
        public int MealCategoryId { get; set; }

        public string MealCategoryName { get; set; }
    }
}
