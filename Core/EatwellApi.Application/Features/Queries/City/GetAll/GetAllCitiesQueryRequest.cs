using EatwellApi.Application.Abstractions.Cache;
using EatwellApi.Application.Behaviors.Authorization;
using EatwellApi.Application.Behaviors.Cache;
using EatwellApi.Application.Dtos.City;
using EatwellApi.Application.Parameters;
using EatwellApi.Application.Wrappers;
using EatwellApi.Domain.Enums.OperationClaim;
using MediatR;

namespace EatwellApi.Application.Features.Queries.City.GetAll
{
    [Secured(OperationClaimEnum.Admin)]
    [Cache(90)]
    public class GetAllCitiesQueryRequest : PaginationRequest, IRequest<PaginationResponse<CityListDto>>, ICacheableQuery
    {
    }
}
