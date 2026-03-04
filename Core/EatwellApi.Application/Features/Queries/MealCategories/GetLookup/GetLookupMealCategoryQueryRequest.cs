using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Behaviors.Authorization;
using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using MediatR;

namespace EatwellApi.Application.Features.Queries.MealCategories.GetLookup
{
    [Secured(OperationClaimEnum.Admin)]
    public class GetLookupMealCategoryQueryRequest : IRequest<DataResponse<List<MealCategoryLookupDto>>>, ICacheableQuery
    {
    }
}
