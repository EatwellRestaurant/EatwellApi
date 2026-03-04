using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Behaviors.Authorization;
using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using MediatR;

namespace EatwellApi.Application.Features.Queries.MealCategories.GetAll
{
    [Secured(OperationClaimEnum.Admin)]
    public class GetAllMealCategoriesQueryRequest : PaginationRequest, IRequest<PaginationResponse<MealCategoryListDto>>, ICacheableQuery
    {
    }
}
