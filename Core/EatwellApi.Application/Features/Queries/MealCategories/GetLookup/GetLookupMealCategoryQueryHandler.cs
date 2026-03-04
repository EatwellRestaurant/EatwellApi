using EatwellApi.Application.Abstractions.Services.MealCategory;
using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.MealCategories.GetLookup
{
    public class GetLookupMealCategoryQueryHandler(IMealCategoryService mealCategoryService) : IRequestHandler<GetLookupMealCategoryQueryRequest, DataResponse<List<MealCategoryLookupDto>>>
    {
        readonly IMealCategoryService _mealCategoryService = mealCategoryService;



        public async Task<DataResponse<List<MealCategoryLookupDto>>> Handle(GetLookupMealCategoryQueryRequest request, CancellationToken cancellationToken)
            => await _mealCategoryService.GetLookupAsync();
    }
}
