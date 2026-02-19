using EatwellApi.Application.Parameters;
using EatwellApi.Domain.Entities.Abstract;

namespace EatwellApi.Application.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, PaginationRequest? paginationRequest) where T : class, IEntity, new()
            => paginationRequest != null
            ? query
            .Skip((paginationRequest.PageNumber - 1) * paginationRequest.PageSize)
            .Take(paginationRequest.PageSize)
            : query;
    }
}
