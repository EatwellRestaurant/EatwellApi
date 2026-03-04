using EatwellApi.Application.Abstractions.Services.MealCategory;
using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.MealCategories.GetActive
{
    public class GetActiveMealCategoriesQueryHandler(IMealCategoryService mealCategoryService) : IRequestHandler<GetActiveMealCategoriesQueryRequest, PaginationResponse<MealCategoryLookupDto>>
    {
        readonly IMealCategoryService _mealCategoryService = mealCategoryService;



        public async Task<PaginationResponse<MealCategoryLookupDto>> Handle(GetActiveMealCategoriesQueryRequest request, CancellationToken cancellationToken)
            => await _mealCategoryService.GetActiveAsync(request);
    }
}
