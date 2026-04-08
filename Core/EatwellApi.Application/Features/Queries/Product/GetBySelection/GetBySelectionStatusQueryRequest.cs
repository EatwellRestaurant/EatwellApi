using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Dtos.Product;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.Product.GetBySelection
{
    public class GetBySelectionStatusQueryRequest : IRequest<DataResponse<List<ProductDisplayDto>>>, ICacheableQuery
    {
        public bool IsSelected { get; set; }

        string ICacheableQuery.CacheKey => $"products:selected:{IsSelected.ToString().ToLower()}";
    }
}
