namespace EatwellApi.Application.Dtos.Product
{
    public class ProductListWithMealCategoryDto : ProductListDto
    {
        public int MealCategoryId { get; set; }

        public string MealCategoryName { get; set; }
    }
}
