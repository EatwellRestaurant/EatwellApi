namespace EatwellApi.Application.Features.Queries.MealCategories.GetOverview
{
    public sealed record MealCategoriesOverviewStatistics(
        int TotalMealCategories,
        int ActiveMealCategories,
        int InactiveMealCategories,
        int ThisMonthAddedMealCategories
    );
}
