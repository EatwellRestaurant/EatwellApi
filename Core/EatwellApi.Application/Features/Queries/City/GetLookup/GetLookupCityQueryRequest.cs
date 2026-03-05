using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Behaviors.Cache;
using EatwellApi.Application.Dtos.City;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.City.GetLookup
{
    [Cache(120)]
    public class GetLookupCityQueryRequest : IRequest<DataResponse<List<CityLookupDto>>>, ICacheableQuery
    {
    }
}
