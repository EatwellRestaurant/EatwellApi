namespace EatwellApi.Application.Features.Queries.MealCategory.GetOverview
{
    public sealed record MealCategoriesOverviewStatistics(
        int TotalMealCategories,
        int ActiveMealCategories,
        int InactiveMealCategories,
        int ThisMonthAddedMealCategories
    );
}
