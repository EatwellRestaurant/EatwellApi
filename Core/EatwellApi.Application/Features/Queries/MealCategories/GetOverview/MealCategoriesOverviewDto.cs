using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Features.Queries.MealCategories.GetOverview
{
    public class MealCategoriesOverviewDto : IDto
    {
        public int TotalMealCategories { get; set; }

        public int ActiveMealCategories { get; set; }

        public int InactiveMealCategories { get; set; }

        public int ThisMonthAddedMealCategories { get; set; }

        public PaginationResponse<MealCategoryListDto> MealCategories { get; set; }
    }
}
 