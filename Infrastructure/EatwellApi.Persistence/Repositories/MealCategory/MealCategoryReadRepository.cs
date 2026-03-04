using EatwellApi.Application.Abstractions.Repositories.MealCategory;
using EatwellApi.Persistence.Context;
using DomainMealCategory = EatwellApi.Domain.Entities.MealCategory;

namespace EatwellApi.Persistence.Repositories.MealCategory
{
    public class MealCategoryReadRepository : ReadRepository<DomainMealCategory>, IMealCategoryReadRepository
    {
        public MealCategoryReadRepository(RestaurantContext context) : base(context)
        {
        }
    }
}
