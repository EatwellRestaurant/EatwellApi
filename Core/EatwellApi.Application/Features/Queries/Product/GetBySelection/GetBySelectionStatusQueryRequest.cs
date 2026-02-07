using EatwellApi.Application.Dtos.Product;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.Product.GetBySelection
{
    public class GetBySelectionStatusQueryRequest : IRequest<DataResponse<List<ProductDisplayDto>>>
    {
        public bool IsSelected { get; set; }

    }
}
