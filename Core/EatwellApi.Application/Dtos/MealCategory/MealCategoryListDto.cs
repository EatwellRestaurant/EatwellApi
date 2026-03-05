namespace EatwellApi.Application.Dtos.MealCategory
{
    public class MealCategoryListDto : AuditableDto
    {
        public string Name { get; set; }

        public int ProductCount { get; set; }

    }
}
