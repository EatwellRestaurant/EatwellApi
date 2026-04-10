using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.MealCategory.GetActiveForDisplay
{
    public class GetActiveMealCategoriesForDisplayQueryRequest : PaginationRequest, IRequest<PaginationResponse<MealCategoryDisplayDto>>, ICacheableQuery
    {
        string ICacheableQuery.CacheKey => $"meal-categories:active-for-display:page:{PageNumber}:size:{PageSize}";
    }
}
