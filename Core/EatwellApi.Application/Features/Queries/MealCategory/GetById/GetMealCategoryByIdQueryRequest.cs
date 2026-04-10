using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Dtos.MealCategory;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.MealCategory.GetById
{
    public class GetMealCategoryByIdQueryRequest : PaginationRequest, IRequest<DataResponse<MealCategoryProductDto>>, ICacheableQuery
    {
        public int Id { get; set; }

        string ICacheableQuery.CacheKey => $"meal-categories:detail:{Id}:products:page:{PageNumber}:size:{PageSize}";
    }
}
