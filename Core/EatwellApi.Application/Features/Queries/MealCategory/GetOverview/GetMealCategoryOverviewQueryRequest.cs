using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Behaviors.Authorization;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using MediatR;

namespace EatwellApi.Application.Features.Queries.MealCategory.GetOverview
{
    [Secured(OperationClaimEnum.Admin)]
    public class GetMealCategoryOverviewQueryRequest : PaginationRequest, IRequest<DataResponse<MealCategoriesOverviewDto>>, ICacheableQuery
    {
        string ICacheableQuery.CacheKey => $"meal-categories:overview:page:{PageNumber}:size:{PageSize}";
    }
}
