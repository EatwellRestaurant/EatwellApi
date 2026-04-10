using EatwellApi.Application.Abstractions.Services.MealCategory;
using EatwellApi.Application.Constants.Messages;
using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.MealCategory.GetById
{
    public class GetMealCategoryByIdQueryHandler(IMealCategoryService mealCategoryService) : IRequestHandler<GetMealCategoryByIdQueryRequest, DataResponse<MealCategoryProductDto>>
    {
        readonly IMealCategoryService _mealCategoryService = mealCategoryService;



        public async Task<DataResponse<MealCategoryProductDto>> Handle(GetMealCategoryByIdQueryRequest request, CancellationToken cancellationToken)
            => new(await _mealCategoryService.GetByIdForUserAsync(request, request.Id), CommonMessages.EntityFetched);
    }
}
