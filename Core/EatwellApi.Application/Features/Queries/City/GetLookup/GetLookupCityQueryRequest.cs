using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Dtos.City;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.City.GetLookup
{
    public class GetLookupCityQueryRequest : IRequest<DataResponse<List<CityLookupDto>>>, ICacheableQuery
    {
        public int CacheDuration => 120;
    }
}
