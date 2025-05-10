using Core.Entities.Abstract;
using Core.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Extensions
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> ApplyPagination<T>(this IQueryable<T> query, PaginationRequest paginationRequest) where T : class, IEntity, new()
            => query
            .Skip((paginationRequest.PageNumber - 1) * paginationRequest.PageSize)
            .Take(paginationRequest.PageSize);
    }
}
