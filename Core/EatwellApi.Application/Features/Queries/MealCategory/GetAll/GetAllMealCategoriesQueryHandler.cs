using EatwellApi.Application.Abstractions.Services.MealCategory;
using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.MealCategory.GetAll
{
    public class GetAllMealCategoriesQueryHandler(IMealCategoryService mealCategoryService) : IRequestHandler<GetAllMealCategoriesQueryRequest, PaginationResponse<MealCategoryListDto>>
    {
        readonly IMealCategoryService _mealCategoryService = mealCategoryService;



        public async Task<PaginationResponse<MealCategoryListDto>> Handle(GetAllMealCategoriesQueryRequest request, CancellationToken cancellationToken)
            => await _mealCategoryService.GetAllAsync(request);
    }
}
