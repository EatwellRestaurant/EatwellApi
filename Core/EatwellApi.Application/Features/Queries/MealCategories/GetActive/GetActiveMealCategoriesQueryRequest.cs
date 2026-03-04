using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.MealCategories.GetActive
{
    public class GetActiveMealCategoriesQueryRequest : PaginationRequest, IRequest<PaginationResponse<MealCategoryLookupDto>>, ICacheableQuery
    {
    }
}
