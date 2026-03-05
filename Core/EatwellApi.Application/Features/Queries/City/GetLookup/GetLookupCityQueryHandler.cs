using EatwellApi.Application.Abstractions.Services.City;
using EatwellApi.Application.Dtos.City;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.City.GetLookup
{
    public class GetLookupCityQueryHandler(ICityService cityService) : IRequestHandler<GetLookupCityQueryRequest, DataResponse<List<CityLookupDto>>>
    {
        readonly ICityService _cityService = cityService;



        public Task<DataResponse<List<CityLookupDto>>> Handle(GetLookupCityQueryRequest request, CancellationToken cancellationToken)
            => _cityService.GetLookupAsync();
    }
}
