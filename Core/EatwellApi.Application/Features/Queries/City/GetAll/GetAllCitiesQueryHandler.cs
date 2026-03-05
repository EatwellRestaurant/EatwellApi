using EatwellApi.Application.Abstractions.Services.City;
using EatwellApi.Application.Dtos.City;
using EatwellApi.Application.Wrappers;
using MediatR;

namespace EatwellApi.Application.Features.Queries.City.GetAll
{
    public class GetAllCitiesQueryHandler(ICityService cityService) : IRequestHandler<GetAllCitiesQueryRequest, PaginationResponse<CityListDto>>
    {
        readonly ICityService _cityService = cityService;



        public Task<PaginationResponse<CityListDto>> Handle(GetAllCitiesQueryRequest request, CancellationToken cancellationToken)
            => _cityService.GetAllAsync(request);
    }
}
