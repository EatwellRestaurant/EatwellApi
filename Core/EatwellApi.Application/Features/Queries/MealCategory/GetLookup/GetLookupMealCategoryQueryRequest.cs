using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Behaviors.Authorization;
using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using MediatR;

namespace EatwellApi.Application.Features.Queries.MealCategory.GetLookup
{
    [Secured(OperationClaimEnum.Admin)]
    public class GetLookupMealCategoryQueryRequest : IRequest<DataResponse<List<MealCategoryLookupDto>>>, ICacheableQuery
    {
        string ICacheableQuery.CacheKey => "meal-categories:lookup";
    }
}
