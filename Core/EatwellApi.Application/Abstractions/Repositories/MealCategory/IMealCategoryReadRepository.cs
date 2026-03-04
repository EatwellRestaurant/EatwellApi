using DomainMealCategory = EatwellApi.Domain.Entities.MealCategory;

namespace EatwellApi.Application.Abstractions.Repositories.MealCategory
{
    public interface IMealCategoryReadRepository : IReadRepository<DomainMealCategory>
    {
    }
}
