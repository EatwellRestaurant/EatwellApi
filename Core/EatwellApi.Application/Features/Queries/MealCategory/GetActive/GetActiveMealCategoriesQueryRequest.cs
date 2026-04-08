using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.MealCategory.GetActive
{
    public class GetActiveMealCategoriesQueryRequest : PaginationRequest, IRequest<PaginationResponse<MealCategoryLookupDto>>, ICacheableQuery
    {
        string ICacheableQuery.CacheKey => $"meal-categories:active:page:{PageNumber}:size:{PageSize}";
    }
}
