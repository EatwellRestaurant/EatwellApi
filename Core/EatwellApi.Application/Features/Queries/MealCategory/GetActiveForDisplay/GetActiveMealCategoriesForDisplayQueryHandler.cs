using EatwellApi.Application.Abstractions.Services.MealCategory;
using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.MealCategory.GetActiveForDisplay
{
    public class GetActiveMealCategoriesForDisplayQueryHandler(IMealCategoryService mealCategoryService) : IRequestHandler<GetActiveMealCategoriesForDisplayQueryRequest, PaginationResponse<MealCategoryDisplayDto>>
    {
        readonly IMealCategoryService _mealCategoryService = mealCategoryService;



        public Task<PaginationResponse<MealCategoryDisplayDto>> Handle(GetActiveMealCategoriesForDisplayQueryRequest request, CancellationToken cancellationToken)
            => _mealCategoryService.GetActiveForUserAsync(request);
    }
}
